$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-exst-target"));
            $target.replaceWith(data);
        });

        return false;
    };

    $("form[data-exst-ajax='true']").submit(ajaxFormSubmit);

});