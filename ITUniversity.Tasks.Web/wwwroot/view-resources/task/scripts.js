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