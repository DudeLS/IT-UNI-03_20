var user = user || {};

user.block = function (id, invoker) {
    $.ajax({
        url: "/api/services/user/block",
        dataType: "json",
        method: "POST",
        data: { id: id },
        success: function (data) {
            if (data) {
                invoker.closest('tr').remove();
            } else {
                alert('Что-то пошло не так...');
            }
        }
    });
}

user.update = function (formId, returnUrl) {
    debugger;
    var postData = objectifyForm(formId);
    $.ajax({
        url: "/api/services/user/update",
        dataType: "json",
        contentType: "application/json",
        method: "PUT",
        data: JSON.stringify(postData),
        success: function (data) {
            debugger;
            window.location.href = returnUrl;
        }
    });
}