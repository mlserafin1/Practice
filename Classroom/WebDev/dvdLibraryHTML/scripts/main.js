//Summary - applies the div html template with the dvd model
function formatDvdRow(dvd) {
    // uses ES6 Template literals which is like C# string interpolation
    var dvdRow = `<div class="col-md-4 dvdItem" data-dvdId="${dvd.id}">
                        <h2 class="title">${dvd.title}</h2>
                        <h3 class="releaseYear">${dvd.releaseYear}</h3>
                        <p class="director">${dvd.directorName}</p>
                        <p class="rating">${dvd.ratingType}</p>
                        <p class="notes hidden">${dvd.notes}</p>
                    </div>`;
    return dvdRow;
}

//Summary - Resets the form, hides Edit Button, and Shows Add button
function resetFrm() {
    //console.log('reset');

    //clear the form
    $("#frmAddDvd")[0].reset();

    //Set the focus to the first text box 
    $("#title").focus();

    //Hide & show buttons
    $("#frmAddBtn").show();
    $("#frmEditBtn").hide();

    //Re-enable the delete button
    $("#deleteDvd").attr('disabled', false);
}

//Summary - Used to handle misc errors from our data service
function ErrorHandlerCode(eventData) {
    alert('Something happened');
}

//Summary - Clears our dvdList div, and adds the dvds back in
//param: dvds - array of dvds
function ShowDvds(dvds) {
    $("#dvdList").empty();
    $.each(dvds, function(item, dvd) {
        $("#dvdList").append(formatDvdRow(dvd));
    });
    resetFrm();

}

//Summary - This method will call the function defined in the paramater when the document has finished loading
$(document).ready(function() {

    //declare a local instance of our dataservice
    var service = new dataService();

    // call GetDvds and point the callback to ShowDvds, which will get passed our dvds from our service
    service.GetDvds(ShowDvds, ErrorHandlerCode);

    //Here we are subscribing to an event on the document object where the element meets the second paramater "#frmAddBtn", then running the inline function
    //NOTE: Remember # is used for element's by ID, where . is used for element(s) by class
    $(document).on("click", "#frmAddBtn", function(e) {
        e.preventDefault();

        // Creating a object literal https://www.w3schools.com/js/js_objects.asp
        var dvd = {
            title: $("#dvdId").val(),
            title: $("#title").val(),
            releaseYear: $("#releaseYear").val(),
            director: $("#director").val(),
            rating: $("#rating").val(),
            notes: $("#notes").val(),
        };
        console.log($("#rating").val());
        // calling AddDvd and passing our dvd we created, then providing a inline function
        service.AddDvd(dvd, function(data) {
            //calls getDvds then shows them
            service.GetDvds(ShowDvds, ErrorHandlerCode);

        }, ErrorHandlerCode);


    });

    //Here we are subscribing to an event on the document object where the element meets the second paramater "div.dvdItem h2.title", 
    //then running the inline function
    //NOTE: we are using any valid CSS selector for the second paramater of our subscribe function
    $(document).on("click", "div.dvdItem h2.title", function(e) {
        e.preventDefault();
        // Select the element by Id of dvdInfo, then store our selection in this variable
        var dvdInfo = $("#dvdInfo");

        // Since we clicked on the h2 tag, we want the div the h2 tag is in. Thus we call the parent and store it in the variable
        var currentDvd = $(this).parent();

        // The title's div we clicked on has a data attribute with the value of the dvd id, which we store in the id variable.
        // https://www.w3schools.com/tags/att_global_data.asp
        var id = currentDvd.attr('data-dvdId');

        service.GetDvdById(id, function(data) {
            dvdInfo.attr("data-dvdId", data.id);
            dvdInfo.find(".title").text(data.title);
            dvdInfo.find(".releaseYear").text(data.releaseYear);
            dvdInfo.find(".director").text(data.directorName);
            dvdInfo.find(".rating").text(data.ratingType);
            dvdInfo.find(".notes").text(data.notes);
            $("#deleteDvd").attr('disabled', false);
            resetFrm();
        }, ErrorHandlerCode);




    })

    //Here we are subscribing to an event on the document object where the element meets the second paramater "#frmEditBtn", 
    //then running the inline function
    $(document).on("click", "#frmEditBtn", function(e) {
        e.preventDefault();

        var dvd = {
            id: $("#dvdId").val(),
            title: $("#title").val(),
            releaseYear: $("#releaseYear").val(),
            director: $("#director").val(),
            rating: $("#rating").val(),
            notes: $("#notes").val(),
        };
        var editDvd = $(".dvdItem[data-DvdID='" + dvd.id + "']")
        service.EditDvd(dvd, function(data) {
            editDvd.find(".title").text(dvd.title);
            editDvd.find(".releaseYear").text(dvd.releaseYear);
            editDvd.find(".director").text(dvd.directorName);
            editDvd.find(".rating").text(dvd.ratingType);
            editDvd.find(".notes").text(dvd.notes);
            resetFrm();
        }, ErrorHandlerCode);
    });

    //Here we are subscribing to an event on the document object where the element meets the second paramater "#deleteDvd", 
    //then running the inline function
    $(document).on("click", "#deleteDvd", function(e) {
        e.preventDefault();
        var currentDvd = $(this).parent();
        var id = currentDvd.attr('data-dvdId');

        service.DeleteDvd(id, function(data) {
            var removeDvd = $(".dvdItem[data-DvdID='" + id + "']")
            removeDvd.remove();
        }, ErrorHandlerCode);

    });

    //Here we are subscribing to an event on the document object where the element meets the second paramater "#deleteDvd", 
    //then running the inline function
    $(document).on("click", "#editDvd", function(e) {
        e.preventDefault();
        $("#deleteDvd").attr('disabled', true);
        var currentDvd = $(this).parent();
        var dvd = {
            id: currentDvd.attr('data-dvdId'),
            title: currentDvd.find(".title").text(),
            releaseYear: currentDvd.find(".releaseYear").text(),
            director: currentDvd.find(".director").text(),
            rating: currentDvd.find(".rating").text(),
            notes: currentDvd.find(".notes").text()
        };

        $("#dvdId").val(dvd.id);
        $("#title").val(dvd.title);
        $("#releaseYear").val(dvd.releaseYear);
        $("#director").val(dvd.directorName);
        $("#rating").val(dvd.ratingType);
        $("#notes").val(dvd.notes);
        $("#frmAddBtn").hide();
        $("#frmEditBtn").show();
    })
});