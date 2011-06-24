(function (p, $, undefined) {
  p.createUrl = function (url) {
    return p.virtualRoot + url;
  };

  p.onPageInit = function () {
    setBodyHeight();
    $(window).resize(function () {
      setBodyHeight();
    });

    if (!Modernizr.borderradius) {
      $("#main").corner();
    }
  };

  function setBodyHeight() {
    $("body").css({ height: '100%' }); // $(window).height() });
  }

  p.setStoredValue = function (key, value) {
    if (Modernizr.localstorage) {
      window.localStorage.setItem(key, value);
    }
    else {
      // fall back to jquery cookie plugin
      $.cookie(key, value);
    }
  };

  p.getStoredValue = function (key) {
    var value = null;

    if (Modernizr.localstorage) {
      value = window.localStorage.getItem(key);
    }
    else {
      // fall back to jquery cookie plugin
      value = $.cookie(key);
    }

    return value;
  };

})(window.pjs = window.pjs || {}, jQuery);