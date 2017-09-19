$(document).ready(function() {

    loadProducts();
    var dollars = 0;
    var quarters = 0;
    var dimes = 0;
    var nickels = 0;


    $(document).on("click", "#dollarButton", function() {
        var newTotal = Number($('#total').text()) + 1.00;

        $('#returnBtn').show();
        $('#message').empty();
        $('#change').empty();
        $('#total').empty();
        $('#total').append(newTotal.toFixed(2));
        console.log(newTotal);
        console.log($('#total').val());
        dollars++;
    })

    $(document).on("click", "#quarterButton", function() {
        var newTotal = Number($('#total').text()) + 0.25;

        $('#returnBtn').show();
        $('#message').empty();
        $('#change').empty();
        $('#total').empty();
        $('#total').append(newTotal.toFixed(2));
        console.log(newTotal);
        console.log($('#total').val());
        quarters++;
    })

    $(document).on("click", "#dimeButton", function() {
        var newTotal = Number($('#total').text()) + 0.10;

        $('#returnBtn').show();
        $('#message').empty();
        $('#change').empty();
        $('#total').empty();
        $('#total').append(newTotal.toFixed(2));
        console.log(newTotal);
        console.log($('#total').val());
        dimes++;
    })

    $(document).on("click", "#nickelButton", function() {
        var newTotal = Number($('#total').text()) + 0.05;

        $('#returnBtn').show();
        $('#message').empty();
        $('#change').empty();
        $('#total').empty();
        $('#total').append(newTotal.toFixed(2));
        console.log(newTotal);
        console.log($('#total').val());
        nickels++;
    })

    $(document).on("click", "#item1", function() {
        var itemNumber = 1;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#item2", function() {
        var itemNumber = 2;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#item3", function() {
        var itemNumber = 3;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#item4", function() {
        var itemNumber = 4;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#item5", function() {
        var itemNumber = 5;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#item6", function() {
        var itemNumber = 6;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#item7", function() {
        var itemNumber = 7;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#item8", function() {
        var itemNumber = 8;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#item9", function() {
        var itemNumber = 9;

        $('#itemNumber').empty();
        $('#message').empty();
        $('#change').empty();
        $('#itemNumber').append(itemNumber);
    })

    $(document).on("click", "#purchaseButton", function() {
        makePurchase();
    })

    $(document).on("click", "#returnBtn", function() {
        returnChange();

    })

    function returnChange() {

        $("#change").empty();

        if (dollars == 0 && quarters == 0 && dimes == 0 && nickels == 0) {
            $('#change').append('No change for you!');
        }

        if (dollars > 0) {
            $('#change').append(' Dollars: ' + dollars);
        }
        if (quarters > 0) {
            $('#change').append(' Quarters: ' + quarters);
        }
        if (dimes > 0) {
            $('#change').append(' Dimes: ' + dimes);
        }
        if (nickels > 0) {
            $('#change').append(' Nickels: ' + nickels);
        }

        $('#total').empty();
        $('#itemNumber').empty();
        $('#message').empty();
        resetChange();


        //reset dollars, quarters, dimes, nickels
    }

    function resetChange() {
        dollars = 0;
        quarters = 0;
        dimes = 0;
        nickels = 0;
    }

}); //end ready


function loadProducts() {
    var i = 1;
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(data, status) {
            $.each(data, function(index, product) { //can use index +1 instead of i. index starts at 0
                var id = 'item' + i + 'Id';
                var name = 'item' + i + 'Name'; //can also do product.id instead of i
                var price = 'item' + i + 'Price';
                var qty = 'item' + i + 'Qty';

                $('#' + id).append(product.id);
                $('#' + name).append(product.name);
                $('#' + price).append(product.price.toFixed(2));
                $('#' + qty).append(product.quantity);

                i++;
            });
        },
        error: function(data) {
            var errors = data.responseJSON;
            if (errors.message == 'No message available') {
                errors.message = 'Error calling web service.';
            }
            $('#message').empty();
            $('#message').append(errors.message);

        }
    });
}

function makePurchase() {
    $('#change').empty();
    var money = $('#total').text();
    var id = $('#itemNumber').text();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + money + '/item/' + id,
        success: function(data, status) {

            $('#change').empty();
            //console.log(2);

            if (data.quarters > 0) {
                $('#change').append(' Quarters: ' + data.quarters);
            }
            if (data.dimes > 0) {
                $('#change').append(' Dimes: ' + data.dimes);
            }
            if (data.nickels > 0) {
                $('#change').append(' Nickels: ' + data.nickels);
            }
            if (data.pennies > 0) {
                $('#change').append(' Pennies: ' + data.pennies);
            }


            clearProducts();
            loadProducts();
            $('#message').append('Thank you!');
            $('#returnBtn').hide();

        },

        error: function(data) {
            var errors = data.responseJSON;
            if (errors.message == 'No message available') {
                errors.message = 'Please select an item!';
            }
            $('#message').empty();
            $('#message').append(errors.message);


        }
    });

} // fix success response for change, wire up change box, wire up display messages

function clearProducts() {
    for (var i = 1; i < 10; i++) {
        var id = 'item' + i + 'Id';
        var name = 'item' + i + 'Name';
        var price = 'item' + i + 'Price';
        var qty = 'item' + i + 'Qty';

        $('#' + id).empty();
        $('#' + name).empty();
        $('#' + price).empty();
        $('#' + qty).empty();
        $('#total').empty();
        $('#itemNumber').empty();
        $('#message').empty();
    }
}