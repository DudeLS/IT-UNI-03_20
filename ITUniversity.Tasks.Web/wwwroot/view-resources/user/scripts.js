var user = user || {};

user.block = function (id, invoker) {
    $.ajax({
        url: "/api/services/user/block",
        dataType: "json",
        //contentType: "application/json",
        method: "POST",
        data: { id: id },//JSON.stringify({ id: id }),
        success: function () {
            debugger;
            invoker.closest('tr').remove();
        }
    });
}