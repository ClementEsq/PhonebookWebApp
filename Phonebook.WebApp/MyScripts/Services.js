app.service("SPACRUDService", function ($http) {

    this.GetPhonebookEntries = function () {

        return $http.get("/api/phonebook/entries");
    };

    this.GetPhonebookEntry = function (id) {
        return $http.get("/api/phonebook/entries/" + id);
    };

    this.PostPhonebookEntry = function (Entry) {
        var request = $http({
            method: "post",
            url: "/api/phonebook/new",
            data: Entry
        });
        return request;
    };

    this.PutPhonebookEntry = function (id, Entry) {
        var request = $http({
            method: "put",
            url: "/api/phonebook/edit/" + id,
            data: Entry
        });
        return request;
    };

    this.DeletePhonebookEntry = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/phonebook/delete/" + id
        });
        return request;
    };
}); 