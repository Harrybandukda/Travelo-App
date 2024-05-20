$(document).ready(function () {
    $('.ajax-link').on('click', function () {
        var url = $(this).data('url');
        $.ajax({
            url: url,
            type: 'GET',
            success: function (data) {
                $('#content-container').html(data);
                bindFormSubmit();
            },
            error: function () {
                $('#content-container').html('<p>Error loading content.</p>');
            }
        });
    });

    function bindFormSubmit() {
        $('#content-container').find('form').submit(function (e) {
            e.preventDefault();
            var form = $(this);
            $.ajax({
                url: form.attr('action'),
                type: 'POST',
                data: form.serialize(),
                success: function (response) {
                    if (response && !response.error) {
                    } else {
                        alert(response.error);
                    }
                },
                error: function (xhr, status, error) {
                    alert('Error: ' + error);
                }
            });
        });
    }

    $('.ajax-link').first().trigger('click');
});