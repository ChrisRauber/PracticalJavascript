(function (p, $) {
  var salesPeople;

  p.searchSalesPerson = function () {
    var searchOn, filteredList;

    $("#dlgSalesPeople").show().centerOnScreen();
    $("#txtSearchSalesPerson").keyup(function (event) {
      searchOn = $("#txtSearchSalesPerson").val();
      filteredList =
         _.select(salesPeople, function (sp) {
           var isFound =
            _.startsWith(sp.SalesPersonId.toString(), searchOn) ||
            _.contains(sp.Name, searchOn);
           debug.log(isFound + "ID=" + sp.SalesPersonId + ", " + sp.Name);
           return isFound;
         });
      showSalesPeople(filteredList);
    });
  };

  p.loadSalesPeople = function () {
    $.ajax({
      url: pjs.createUrl('api/SalesPersons/List'),
      dateType: 'json',
      cache: false,
      success: function (data, status) {
        if (status === 'success') {
          salesPeople = data;
          showSalesPeople(salesPeople);
        }
      }
    });
  };

  p.closeSalesPeopleDialog = function () {
    $("#dlgSalesPeople").hide();
  };

  function showSalesPeople(filteredList) {
    var trs = $("#salesPersonTemplate").tmpl(filteredList);
    $("#tbodySalesPeople").html(trs).zebraStripe();
  }

} (window.pjs = window.pjs || {}, jQuery));