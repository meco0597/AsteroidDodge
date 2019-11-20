$(document).ready(function() {
    var containerSize = $(".body-projects").width();
    var gameWindow = $("#game");
    var newWidth = containerSize * 0.9;
    gameWindow.attr('width', newWidth);
    var newHeight = newWidth * (5 / 6);
    gameWindow.attr('height', newHeight);
    console.log(containerSize + " " + newWidth + " " + newHeight);
});

$(window).on("resize", function() {
    var containerSize = $(".body-projects").width();
    var gameWindow = $("#game");
    var newWidth = containerSize * 0.9;
    gameWindow.attr('width', newWidth);
    var newHeight = newWidth * (5 / 6);
    gameWindow.attr('height', newHeight);
});
