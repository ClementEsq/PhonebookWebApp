app.controller('AddPhonebookEntryController', function ($scope, $location, SPACRUDService) {
    $scope.Id = 0;

    $scope.save = function () {
        var Entry = {
            Id: $scope.Id,
            Name: $scope.Name,
            MobileNumber: $scope.MobileNumber,
            HomeNumber: $scope.HomeNumber,
            EmailAddress: $scope.EmailAddress
        };

        var promisePost = SPACRUDService.PostPhonebookEntry(Entry);

        promisePost.then(function (pl) {
            $location.path("/ShowPhonebookEntries");
        },
            function (errorPl) {
                $scope.error = 'Failure Loading Entry', errorPl;
            });

    };

});  