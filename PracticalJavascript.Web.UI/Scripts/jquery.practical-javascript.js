(function ($) {

  $.fn.zebraStripe = function () {
    return $(this).find("tr:odd").css({ "background-color": "#ffffcc" });
  }

  $.fn.centerOnScreen = function (loaded) {
    var obj = $(this);
    var page = $(window);
    if (!loaded) {
      obj.css('top', page.height() / 2 - $(this).height() / 2);
      obj.css('left', page.width() / 2 - $(this).width() / 2);
      $(window).resize(function () {
        obj.centerOnScreen(!loaded);
      });
    }
    else {
      obj.stop();
      obj.animate({
        top: page.height() / 2 - $(this).height() / 2,
        left: page.width() / 2 - $(this).width() / 2
      }, 200, 'linear');
    }
    return $(this);
  }
}(window.jQuery));