(function () {
    var app = angular.module("kanbanBoard", ["ngRoute"]);

    app.config(function ($routeProvider) {
        $routeProvider.when("/", {
            templateUrl: "/Dashboard/",
            controller: "DashboardController"
        }).
        when("/Login",{
            templateUrl: "/Template/GetTemplate/_Login",
            controller: "AccountController"
        }) 
        .otherwise("/");

    });
}());