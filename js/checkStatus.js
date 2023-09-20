function isExist() {
    $.ajax({
        type: "GET",
        url: "CheckStatus.aspx/isExist", // Name of the WebMethod
        data: JSON.stringify({ inputParameter: inputParameter }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Handle the response from the server
            var result = response.d;

            return result;

        },
        error: function (error) {
            alert("Error: " + error.responseText);
        }
    });
}


function authenticate() {
    $.ajax({
        type: "GET",
        url: "CheckStatus.aspx/performAuthenticate", // Name of the WebMethod
        data: JSON.stringify({ inputParameter: inputParameter }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Handle the response from the server
            var result = response.d;

            return responde.d

        },
        error: function (error) {
            alert("Error: " + error.responseText);
        }
    });
}

function sendCode() {
    var exist = isExist();
    if (exist) {
        code = authenticate();
    }
}