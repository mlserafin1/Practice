function dataService() {
    var self = this; // this is refering to the function object, we want to store 'this' reference to use later

    // Summary - Attaching AddDvd Method to DataService, used to create a new Dvd
    // param: dvd - dvd to be added in our POST
    // param: callback - on success, run the function callback
    // param: errorHandler - on error, run the function errorHandler
    self.AddDvd = function(dvd, callback, errorHandler) {

        var settings = {
            url: 'http://localhost:50771/dvds',
            method: 'POST',
            data: dvd

        }
        $.ajax(settings).done(callback).error(errorHandler);
    };
    // Summary - Attaching EditDvd Method to DataService, used to Edit a Dvd
    // param: dvd - dvd to be added in our PUT
    // param: callback - on success, run the function callback
    // param: errorHandler - on error, run the function errorHandler
    self.EditDvd = function(dvd, callback, errorHandler) {
        var settings = {
            url: 'http://localhost:50771/dvd/' + dvd.Id,
            method: 'PUT',
            data: dvd

        }
        $.ajax(settings).done(callback).error(errorHandler);
    };

    // Summary - Attaching DeleteDvd Method to DataService, used to Delete a Dvd
    // param: id - id of the Dvd to DELETE
    // param: callback - on success, run the function callback
    // param: errorHandler - on error, run the function errorHandler
    self.DeleteDvd = function(id, callback, errorHandler) {
        var settings = {
            url: 'http://localhost:50771/dvd/' + id,
            method: 'DELETE'

        }
        $.ajax(settings).done(callback);
    };

    // Summary - Attaching DeleteDvd Method to DataService, used to Delete a Dvd
    // param: callback - on success, run the function callback
    // param: errorHandler - on error, run the function errorHandler
    self.GetDvds = function(callback, errorHandler) {
        var settings = {
            url: 'http://localhost:50771/dvds',
            method: 'GET'

        }
        $.ajax(settings).done(callback).error(errorHandler);
    };

    // Summary - Attaching DeleteDvd Method to DataService, used to Delete a Dvd
    // param: id - id of the Dvd to GET
    // param: callback - on success, run the function callback
    // param: errorHandler - on error, run the function errorHandler
    self.GetDvdById = function(id, callback, errorHandler) {
        var settings = {
            url: 'http://localhost:50771/dvd/' + id,
            method: 'GET'

        }
        $.ajax(settings).done(callback).error(errorHandler);
    }

}