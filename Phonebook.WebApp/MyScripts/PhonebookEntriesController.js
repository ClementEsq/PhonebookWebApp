app.controller('PhonebookEntriesController', function ($scope, $location, SPACRUDService, ShareData) {
    loadAllPhonebookEntries();

    function loadAllPhonebookEntries() {
        var promiseGetEntries = SPACRUDService.GetPhonebookEntries();

        promiseGetEntries.then(function (pl) { $scope.Entries = pl.data },
            function (errorPl) {
                $scope.error = errorPl;
            });
    }

    //Details 
    $scope.showEntry = function (id) {
        ShareData.value = id;
        $location.path("/ShowPhonebookEntry");
    }

    //Edit entry 
    $scope.editEntry = function (id) {
        ShareData.value = id;
        $location.path("/EditPhonebookEntry");
    }

    //Delete entry  
    $scope.deleteEntry = function (id) {
        ShareData.value = id;
        $location.path("/DeletePhonebookEntry");
    }
})