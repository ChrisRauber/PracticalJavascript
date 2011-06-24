(function (p, $, undefined) {
  var stores;

  function resetCheckboxes() {
    var isFuelChecked = p.getStoredValue("cboFuel.isChecked") === 'true';
    var isMaintenanceChecked = p.getStoredValue("cboMaintenance.isChecked") === 'true';

    if (!isFuelChecked) {
      $("#cboFuel").removeAttr('checked');
    }
    if (!isMaintenanceChecked) {
      $("#cboMaintenance").removeAttr('checked');
    }
  }

  function showStores(stores) {
    var trs;
    if (stores) {
      trs = $("#storeTemplate").tmpl(stores);
      $("#tbodyStores").html(trs).zebraStripe();
    }
  }

  function filterByStoreType() {
    var filteredStores;
    var isFuel = $("#cboFuel").attr('checked');
    var isMaintenance = $("#cboMaintenance").attr('checked');

    filteredStores =
      filterUsingUnderscore(isFuel, isMaintenance);
    //filterUsingJSLINQ(isFuel, isMaintenance);

    showStores(filteredStores);
  }

  function filterUsingUnderscore(isFuelChecked, isMaintChecked) {
    var filteredStores, orderedStores;
    filteredStores =
    _.select(stores, function (store) {
      var isShown =
          isFuelShown(isFuelChecked, store.StoreTypeId) ||
          isMaintenanceShown(isMaintChecked, store.StoreTypeId);
      return isShown;
    });
    orderedStores =
      _.sortBy(filteredStores, function (store) { return store.StoreId; });
    return orderedStores;
  }

  function filterUsingJSLINQ(isFuelChecked, isMaintChecked) {
    var orderedStores =
      JSLINQ(stores)
        .Where(function (store) {
          var isShown =
            isFuelShown(isFuelChecked, store.StoreTypeId) ||
            isMaintenanceShown(isMaintChecked, store.StoreTypeId);
          return isShown;
        })
        .OrderBy(function (store) { return store.StoreId; })
        .ToArray();
    return orderedStores;
  }

  function isFuelShown(isFuelChecked, storeTypeId) {
    return isFuelChecked &&
      (storeTypeId === pjs.storeType.fuel || storeTypeId === pjs.storeType.fuelAndMaintenance);
  }

  function isMaintenanceShown(isMaintChecked, storeTypeId) {
    return isMaintChecked &&
      (storeTypeId === pjs.storeType.maintenance || storeTypeId === pjs.storeType.fuelAndMaintenance);
  }

  p.storeListInit = function () {
    //resetCheckboxes();
    $("input[name=cboFuelMaintenance]").click(function () {
      // store the value locally
      p.setStoredValue(this.id + ".isChecked", $(this).attr('checked'));
      filterByStoreType();
    });
    $.ajax({
      url: p.createUrl('api/Stores/List'),
      dateType: 'json',
      cache: false,
      success: function (data, status) {
        if (status === 'success') {
          // locally cache the stores
          stores = data;
          filterByStoreType();
        }
      }
    });
  };

} (window.pjs = window.pjs || {}, jQuery));