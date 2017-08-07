var app = angular.module("ApplicationModule", ["ngRoute"]);

app.factory("ShareData", function () {
    return { value: 0 }
});

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    //debugger;
    $routeProvider.when('/ShowPhonebookEntries',
        {
            templateUrl: 'Phonebook/ShowPhonebookEntries',
            controller: 'PhonebookEntriesController'
        });
    $routeProvider.when('/AddPhonebookEntry',
        {
            templateUrl: 'Phonebook/AddPhonebookEntry',
            controller: 'AddPhonebookEntryController'
        });
    $routeProvider.when("/EditPhonebookEntry",
        {
            templateUrl: 'Phonebook/EditPhonebookEntry',
            controller: 'EditPhonebookEntryController'
        });
    $routeProvider.when('/DeletePhonebookEntry',
        {
            templateUrl: 'Phonebook/DeletePhonebookEntry',
            controller: 'DeletePhonebookEntryController'
        });
    $routeProvider.when('/ShowPhonebookEntry',
        {
            templateUrl: 'Phonebook/ShowPhonebookEntry',
            controller: 'PhonebookEntryController'
        });
    $routeProvider.otherwise(
        {
            redirectTo: '/'
        });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false,
        rewriteLinks: true
    });
}]); 