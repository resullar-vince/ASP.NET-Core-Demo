var Bookbox = Bookbox || {};
Bookbox.Utilities = Bookbox.Utilities || {};
Bookbox.Utilities.DeleteWarning = Bookbox.Utilities.DeleteWarning || {};



(function () {
    Bookbox.Utilities.DeleteWarning.Utility = function (_url) {
        $("button#ShowModal").click(function () {
            $("#DeleteModal").modal('show');
            var form = $('#__AjaxAntiForgeryForm');
            var token = form.find('input[name="__RequestVerificationToken"]').val();
            var deleteAnchor = $(this);
            var getId = deleteAnchor.attr('data-id');
            $("button#DeleteConfirmation").click(function () {
                $.ajax({
                    type: "post",
                    url: _url,
                    data: { __RequestVerificationToken: token, id: getId }
                }).done(function (data, textStatus, jqXHR) {
                    if (jqXHR.status === 200) {
                        deleteAnchor.closest('tr').remove();
                    }
                    else {
                        console.log(textStatus + ":" + data.Message);
                    }

                }).fail(function (err) {
                    console.log(err)
                });
                $("#DeleteModal").modal('hide');
            });
        });

        $("button#CancelButton").click(function () {
            $("#DeleteModal").modal('hide');
        });
    }
})();