
async function sendImageToAPI() {
    return new Promise(function (resolve, reject) {
        var formData = new FormData();
        formData.append('image', $('#resultImage')[0].files[0]);

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



async function getText() {
    try {
        const response = await sendImageToAPI();
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

async function sendImageToEnhance() {
    

    const formData = new FormData();
    formData.append("upscale_factor", "6");
    formData.append("image", $('#resultImage')[0].files[0]);

    const settings = {
        async: true,
        crossDomain: true,
        url: 'https://api.picsart.io/tools/1.0/upscale/enhance',
        method: 'POST',
        headers: {
            accept: 'application/json',
            'x-picsart-api-key': 'xD0QVHRUeSz4jth4xKNR4JSZ0VjhQGwT'
        },
        processData: false,
        contentType: false,
        mimeType: 'multipart/form-data',
        data: formData
    };

    $.ajax(settings).done(function (response) {
        console.log(response);
        
    });
}




