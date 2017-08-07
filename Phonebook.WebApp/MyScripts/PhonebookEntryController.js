app.controller("PhonebookEntryController", function ($scope, $location, ShareData, SPACRUDService) {
    getEntry();

    function getEntry() {
        var promiseGetEntry = SPACRUDService.GetPhonebookEntry(ShareData.value);

        promiseGetEntry.then(function (pl) {
            $scope.Entry = pl.data;
        },
            function (errorPl) {
                $scope.error = 'Failure Loading Entry', errorPl;
            });
    }

}); 