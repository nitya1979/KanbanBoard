(function () {
    var app = angular.module("kanbanBoard", ["ngRoute", "LocalStorageModule"]);

    app.config(function ($routeProvider) {
        $routeProvider.when("/", {
            templateUrl: "/Dashboard/",
            controller: "DashboardController"
        }).
        when("/Login",{
            templateUrl: "/Template/GetTemplate/_Login",
            controller: "LoginController"
        }).
        when("/Register", {
            templateUrl: "/Template/GetTemplate/_Register",
            controller: "registrationController"
        })
        .otherwise("/");

    });

}());