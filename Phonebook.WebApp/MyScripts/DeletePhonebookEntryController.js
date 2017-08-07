app.controller("DeletePhonebookEntryController", function ($scope, $location, ShareData, SPACRUDService) {

    deleteEntry();
    function deleteEntry() {

            var promiseDeleteEntry = SPACRUDService.DeletePhonebookEntry(ShareData.value);

            promiseDeleteEntry.then(function (pl) {
                $location.path("/ShowPhonebookEntries");
            },
                function (errorPl) {
                    $scope.error = 'Failure Loading Entry', errorPl;
                });
        }

});  