$(function () {
    var useAjax = false;

    var shoutbox = $('.shoutbox');
    var messageList = $('.message-list');

    if (shoutbox.length > 0) {
        shoutbox[0].focus();
        shoutbox[0].select();
    }

    function appendMessage(message) {
        messageList.append('<li>' + message.Text + '</li>');
    };

    if (useAjax) {
        /* Ajax goes here */

        $('.shoutform').submit(function () {
            var fields = $('input', this);
            $.post($(this).attr('action'), $(this).serialize())
                .done(function (data) {
                    appendMessage(data);
                    fields.removeAttr('disabled');
                });
            fields.attr('disabled', 'disabled');
            shoutbox.val('');
            return false;
        });
    } else {
        /* SignalR goes here */

        var connection = $.connection('/chat');

        connection.received(function (data) {
            appendMessage(data);
        });

        connection.start().done(function () {
            $('.shoutform').submit(function () {
                var message = { Text: shoutbox.val() };
                connection.send(JSON.stringify(message));
                return false;
            });
        });
    }
});