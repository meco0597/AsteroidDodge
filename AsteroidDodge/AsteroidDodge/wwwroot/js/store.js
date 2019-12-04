function purchaseShip(shipSkinName)
{
    $.ajax({

        method: "POST",

        url: "/Store/PurchaseShip",
        data: {
            shipSkinName: shipSkinName
        }

    }).done(function(result) {
        Swal.fire(
          'Success!',
          'Ship purchased',
          'success'
        )
    }).fail(function(jqXHR, textStatus, errorThrown) {
        Swal.fire({
          type: 'error',
          title: 'Purchase Failed',
          text: 'Not enough coins',
        })
    }).always(function() {
        console.log("always")
    });
}

function shipChange(shipSkinName) {
    $.ajax({

        method: "POST",

        url: "/Store/SetCurrentShip",
        data: {
            shipSkinName: shipSkinName
        }

    }).done(function (result) {
        Swal.fire(
            'Success!',
            'Ship changed',
            'success'
        )
    }).fail(function (jqXHR, textStatus, errorThrown) {
        Swal.fire({
            type: 'error',
            title: 'Change failed',
            text: 'Server Error',
        })
    }).always(function () {
        console.log("always")
    });
}