﻿//$('#skin-table').on('click', '.skin-select', function (e) {
//    $(this).addClass('active').siblings().removeClass('active');
//});

function setElementActive(element) {
    element.addClass('active').siblings().removeClass('active');
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

function shipChange(shipSkinName, tableRow) {
    $.ajax({

        method: "POST",

        url: "/Store/SetCurrentShip",
        data: {
            shipSkinName: shipSkinName
        }

    }).done(function (result) {
        setElementActive(tableRow);

        Swal.fire(
            'Success!',
            'Ship changed',
            'success'
        );


    }).fail(function (jqXHR, textStatus, errorThrown) {
        Swal.fire({
            type: 'error',
            title: 'Change failed',
            text: 'Server Error',
        })
    }).always(function () {
    });
}