function loadComments(FlightId) {
    $.ajax({
        url: '/FlightComments/GetCommentsFlight?FlightId=' + FlightId,
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
    var FlightId = $('#flightComments input[name="FlightId"]').val();

    loadComments(FlightId);

    $('#addCommentForm').submit(function (e) {
        e.preventDefault();

        var formData = {
            FlightId: FlightId,
            Content: $('#flightComments textarea[name="Content"]').val()
        };


        $.ajax({
            url: '/FlightComments/AddCommentFlight',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),

            success: function (response) {
                if (response.success) {
                    $('#flightComments textarea[name="Content"]').val(''); //Clear message area
                    loadComments(FlightId);

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