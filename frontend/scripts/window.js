$( document ).ready(function() {
    var windowSize = $(window).width();
  if (windowSize < 991) {
    $(".navbar").css("background-color", "black");
    $(".navbar-collapse").css("background-color", "black");
    $("#main-text").css("font-size", "57px");
  } else {
    $(".navbar").css("background-color", "rgba(0, 0, 0, 0)");
    $(".navbar-collapse").css("background-color", "rgba(0, 0, 0, 0)");
    $("#main-text").css("font-size", "75px");
  }
});

$(window).on("resize", function(e) {
  var windowSize = $(this).width();
  if (windowSize < 991) {
    $(".navbar").css("background-color", "black");
    $(".navbar-collapse").css("background-color", "black");
    $("#main-text").css("font-size", "57px");
  } else {
    $(".navbar").css("background-color", "rgba(0, 0, 0, 0)");
    $(".navbar-collapse").css("background-color", "rgba(0, 0, 0, 0)");
    $("#main-text").css("font-size", "75px");
  }
});
