(function () {

    var commonDataService = function ($http) {
        var getPriorities = function () {
            return $http.get("/api/Common/Priorities").then(function (response) {
                return response.data;
            });
        };

        return {
            getPriorities : getPriorities
        };

    };

    var app = angular.module("kanbanBoard");
    app.factory("commonDataService", commonDataService);
}());