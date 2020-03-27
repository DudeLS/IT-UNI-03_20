var task = task || {};

task.delete = function (id, invoker) {
    $.ajax({
        url: "/Task/Delete",
        dataType: "json",
        method: "POST",
        data: { "id": id },
        success: function () {
            invoker.closest('tr').remove();
        }
    });
}

task.create = function (formId, returnUrl) {
    var form = $('#' + formId);
    if (!form.valid()) {
        return;
    }
    var postData = objectifyForm(formId);
    $.ajax({
        url: "/api/services/task/create",
        dataType: "json",
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify(postData),
        success: function () {
            window.location.href = returnUrl;
        }
    });
}

task.update = function (formId, returnUrl) {
    var postData = objectifyForm(formId);
    $.ajax({
        url: "/api/services/task/update",
        dataType: "json",
        contentType: "application/json",
        method: "PUT",
        data: JSON.stringify(postData),
        success: function () {
            window.location.href = returnUrl;
        }
    });
}