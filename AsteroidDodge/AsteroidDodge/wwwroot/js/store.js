$('#skin-table').on('click', '.skin-select', function (e) {
    $(this).addClass('active').siblings().removeClass('active');
});

function purchaseBackground(backgroundSkinName) {
    $.ajax({

        method: "POST",

        url: "/Store/PurchaseBackground",
        data: {
            backgroundSkinName: backgroundSkinName
        }

    }).done(function (result) {
        Swal.fire(
            'Success!',
            'Background purchased',
            'success'
        ).then(() => {
            window.location.reload(true);
        })
    }).fail(function (jqXHR, textStatus, errorThrown) {
        Swal.fire({
            type: 'error',
            title: 'Purchase Failed',
            text: 'Not enough coins',
        })
    }).always(function () {
        console.log("always")
    });
}

function backgroundChange(backgroundSkinName) {
    $.ajax({

        method: "POST",

        url: "/Store/SetCurrentBackground",
        data: { 
            backgroundSkinName: backgroundSkinName
        }

    }).done(function (result) {
        console.log("Background changed.");
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
        ).then(() => {
            window.location.reload(true);
        })
    }).fail(function(jqXHR, textStatus, errorThrown) {
        Swal.fire({
          type: 'error',
          title: 'Purchase Failed',
          text: 'Not enough coins',
        })
    }).always(function () {

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
        console.log("Ship changed.");
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