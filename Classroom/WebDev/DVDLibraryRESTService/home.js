$(document).ready(function() {

    loadDVDs();

    $('#create-dvd-button').click(function(event) {
        $('#dvdTable').hide();
        $('#buttonRow').hide();
        $("#createFormDiv").show();
    })

    function loadDVDs() {
        var contentRows = $('#contentRows');

        $.ajax({
            type: 'GET',
            url: 'http://localhost:8080/dvds',
            success: function(data, status) {
                $.each(data, function(index, dvd) {
                    var title = dvd.title;
                    var releaseYear = dvd.realeaseYear;
                    var id = dvd.dvdId;
                    var director = dvd.director;
                    var rating = dvd.rating;

                    var row = '<tr>';
                    row += '<td>' + title + '</td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td onclick="showEditForm(' + id + ')"><a>Edit</a></td>';
                    row += '<td onclick="deleteDvd(' + id + ')"><a>Delete</a></td>';
                    row += '</tr>';
                    contentRows.append(row);
                });
            },
            error: function() {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling web service.  Please try again later.'));
            }
        });
    }
})