function setElementActive(element) {
    element.addClass('active').siblings().removeClass('active');
    element.siblings().find('.selected-text').hide();
    element.find('.selected-text').show();
}

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

function backgroundChange(backgroundSkinName, tableRow) {
    if (tableRow.hasClass('skin-select')) {
        $.ajax({

            method: "POST",

            url: "/Store/SetCurrentBackground",
            data: {
                backgroundSkinName: backgroundSkinName
            }

        }).done(function (result) {
            setElementActive(tableRow);
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

function shipChange(shipSkinName, tableRow) {
    if (tableRow.hasClass('skin-select')) {
        $.ajax({

            method: "POST",

            url: "/Store/SetCurrentShip",
            data: {
                shipSkinName: shipSkinName
            }

        }).done(function (result) {
            setElementActive(tableRow);
            console.log("Ship changed.");
        }).fail(function (jqXHR, textStatus, errorThrown) {
            Swal.fire({
                type: 'error',
                title: 'Change failed',
                text: 'Server Error',
            })
        }).always(function () {
        });

    }

}