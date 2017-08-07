app.controller("EditPhonebookEntryController", function ($scope, $location, ShareData, SPACRUDService) {
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

    $scope.save = function () {
        var Entry = {
            Id: $scope.Entry.Id,
            Name: $scope.Entry.Name,
            MobileNumber: $scope.Entry.MobileNumber,
            HomeNumber: $scope.Entry.HomeNumber,
            EmailAddress: $scope.Entry.EmailAddress
        };

        var promisePutEntry = SPACRUDService.PutPhonebookEntry($scope.Entry.Id, Entry);

        promisePutEntry.then(function (pl) {
            $location.path("/ShowPhonebookEntries");
        },
            function (errorPl) {
                $scope.error = 'Failure Loading Entries', errorPl;
            });
    };

}); 