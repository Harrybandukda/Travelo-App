function loadComments(HotelsId) {
    $.ajax({
        url: '/HotelComments/GetCommentsHotel?HotelsId=' + HotelsId,
        method: 'GET',
        success: function (data) {
            var commentHtml = '';
            data.forEach(function (comment) {
                commentHtml += `
                <div class="card mb-3">
                    <div class="card-header text-muted">
                        Posted on ${new Date(comment.datePosted).toLocaleString()}
                    </div>
                    <div class="card-body">
                        <p class="card-text">${comment.content}</p>
                    </div>
                </div>`;
            });
            $('#commentsList').html(commentHtml);
        }
    });
}


$(document).ready(function () {
    var HotelsId = $('#hotelComments input[name="HotelsId"]').val();

    loadComments(HotelsId);

    $('#addCommentForm').submit(function (e) {
        e.preventDefault();

        var formData = {
            HotelsId: HotelsId,
            Content: $('#hotelComments textarea[name="Content"]').val()
        };


        $.ajax({
            url: '/HotelComments/AddCommentHotel',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),

            success: function (response) {
                if (response.success) {
                    $('#hotelComments textarea[name="Content"]').val(''); //Clear message area
                    loadComments(HotelsId);

                } else {
                    alert(response.message);

                }

            },
            error: function (xhr, status, error) {
                alert("Error " + error);

            }

        });

    });

});