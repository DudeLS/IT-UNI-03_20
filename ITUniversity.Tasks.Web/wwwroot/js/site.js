// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function objectifyForm(formId) {
    var form = $('#' + formId);
    var formArray = form.serializeArray();
    var formObject = {};
    for (var i = 0; i < formArray.length; i++) {
        formObject[formArray[i]['name']] = formArray[i]['value'];
    }
    return formObject;
}