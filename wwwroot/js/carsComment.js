function loadComments(CarId) {
    $.ajax({
        url: '/ListingComments/GetCommentsCar?CarId=' + CarId,
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
    var CarId = $('#listingComments input[name="CarId"]').val();

    loadComments(CarId);

    $('#addCommentForm').submit(function (e) {
        e.preventDefault();

        var formData = {
            CarId: CarId,
            Content: $('#listingComments textarea[name="Content"]').val()
        };


        $.ajax({
            url: '/ListingComments/AddCommentCar',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),

            success: function (response) {
                if (response.success) {
                    $('#listingComments textarea[name="Content"]').val(''); //Clear message area
                    loadComments(CarId);

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