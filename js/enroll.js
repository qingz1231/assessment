
async function sendImageToAPI(file) {
    return new Promise(function (resolve, reject) {
        var formData = new FormData();
        formData.append('image', file);

        $.ajax({
            method: 'POST',
            url: 'https://api.api-ninjas.com/v1/imagetotext',
            headers: { 'X-Api-Key': 'AtBRLxMS6py6QtpS1KVykw==tBCScWZWUhaaUMQi' },
            data: formData,
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            success: function (result) {
                console.log(result);
                resolve(result); // Resolve the promise with the result
            },
            error: function ajaxError(jqXHR, textStatus, errorThrown) {
                console.error(jqXHR.responseText);
                reject(new Error("An error occurred")); // Reject the promise with an error
            }
        });
    });
}



async function getText(file) {
    try {
        const response = await sendImageToAPI(file);
        // Proceed with your code that depends on the response
        jsonData = JSON.stringify(response)
        $.ajax({
            type: "POST",
            url: "enrollment.aspx/processJson", // Name of the WebMethod
            data: JSON.stringify({ jsonData: jsonData }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                // Handle the response from the server
                var result = response.d;

                alert("success2")

               
            },
            error: function (error) {
                alert("Error: " + error.responseText);
            }
        });
    } catch (error) {
        console.error("Error:", error);
        alert("Failed");
    }
}

async function sendImageToEnhance(imageUrl) {
    
    return new Promise((resolve, reject) => {
    const formData = new FormData();
    formData.append("upscale_factor", "3");
    formData.append("image_url", imageUrl);

    const settings = {
        async: true,
        crossDomain: true,
        url: 'https://api.picsart.io/tools/1.0/upscale/enhance',
        method: 'POST',
        headers: {
            accept: 'application/json',
            'x-picsart-api-key': '1llhxThEgqzB9M5XNxlv6fBLLLw1Wtzy'
        },
        processData: false,
        contentType: false,
        mimeType: 'multipart/form-data',
        data: formData
    };

        $.ajax(settings)
            .done(function (response) {
                console.log("success enhance");
                jsonResponse = JSON.parse(response);
                console.log(jsonResponse);
                resolve(jsonResponse.data.url); // Resolve the promise with the data
            })
            .fail(function (error) {
                console.error("error", error);
                reject(error); // Reject the promise with the error
            });
    });
}

async function sendImageToEffect() {
    return new Promise((resolve, reject) => {
        console.log($('#resultImage')[0].files[0]);
        const formData = new FormData();
        formData.append("image", $('#resultImage')[0].files[0]);
        formData.append('effect_name', 'sketcher2');
        const settings = {
            async: true,
            crossDomain: true,
            url: 'https://api.picsart.io/tools/1.0/effects',
            method: 'POST',
            headers: {
                accept: 'application/json',
                'X-Picsart-API-Key': '1llhxThEgqzB9M5XNxlv6fBLLLw1Wtzy'
            },
            processData: false,
            contentType: false,
            mimeType: 'multipart/form-data',
            data: formData
        };

        $.ajax(settings)
            .done(function (response) {
                
                console.log("success effect");
                jsonResponse = JSON.parse(response);
                console.log(jsonResponse.data.url)
                resolve(jsonResponse.data.url); // Resolve the promise with the data
            })
            .fail(function (error) {
                console.error("error", error);
                reject(error); // Reject the promise with the error
            });
    });
}

async function processImage() {
    try {
        imageUrl = await sendImageToEffect();
        enhancedImageUrl = await sendImageToEnhance(imageUrl);
        file = await createFileFromImageUrl(imageUrl)
        getText(file);

    } catch (error) {
        console.error("Error in processImage:", error);
    }
}

async function createFileFromImageUrl(imageUrl) {
    try {
        // Fetch the image data from the URL
        const response = await fetch(imageUrl);
        const blob = await response.blob();

        // Create a File object with a unique name (e.g., "image.jpg")
        const fileName = imageUrl.substring(imageUrl.lastIndexOf("/") + 1);
        const file = new File([blob], fileName, { type: blob.type });

        return file;
    } catch (error) {
        console.error("Error creating File object from URL:", error);
        return null;
    }
}







