function dataService() {
    var self = this; // this is refering to the function object, we want to store 'this' reference to use later

    // dvds will be our internal dvd array for this mock
    var dvds = [{
        id: 1,
        title: 'Matrix',
        releaseYear: '1999',
        director: 'Lana Wachowski, Lilly Wachowski',
        rating: 'R',
        notes: 'Best Movie!',
    },
    {
        id: 2,
        title: 'Matrix Reloaded',
        releaseYear: '2003',
        director: 'Lana Wachowski, Lilly Wachowski',
        rating: 'R',
        notes: 'Meh CGI!',
    },
    {
        id: 3,
        title: 'Matrix Revolutions',
        releaseYear: '2003',
        director: 'Lana Wachowski, Lilly Wachowski',
        rating: 'R',
        notes: 'Wait is this Dragonball?!',
    }];

    // We are Adding Methods to dataService object. 
    self.AddDvd = function (dvd, callback, errorHandler) {
        var id = 1;
        id = dvds.length + id;
        dvd.id = id;
        dvds.push(dvd);
        callback(dvd);
    };
    self.EditDvd = function (dvd, callback, errorHandler) {
        for (var i = 0; i < dvds.length; i++) {
            if (dvd.id == dvds[i].id) {
                dvds[i] = dvd;
                break;
            }
        }
        //Here we are calling the callback function manually
        callback();
    };
    self.DeleteDvd = function (id, callback, errorHandler) {
        for (var i = 0; i < dvds.length; i++) {
            if (id == dvds[i].id) {
                dvds = dvds.splice(i, 1);
                break;
            }
        }
        callback();
    };
    self.GetDvds = function (callback, errorHandler) {
        //Here we are calling the callback function with our dvd array as a paramater
        callback(dvds);
    };
    self.GetDvdById = function (id, callback, errorHandler) {
        var dvd;
        for (var i = 0; i < dvds.length; i++) {

            if (id == dvds[i].id) {
                dvd = dvds[i];
                break;
            }
        }
        callback(dvd);
    }

}