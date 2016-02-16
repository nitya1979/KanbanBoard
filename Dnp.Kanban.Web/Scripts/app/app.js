(function () {
    var app = angular.module("kanbanBoard", ["ngRoute", "LocalStorageModule"]);

    app.config(function ($routeProvider) {
        $routeProvider.when("/Dashboard", {
            templateUrl: "/Template/GetAuthTemplate/_dashboard",
            controller: "DashboardController"
        }).
        when("/Login",{
            templateUrl: "/Template/GetTemplate/_Login",
            controller: "LoginController"
        }).
        when("/Logout", {
            templateUrl: "/Template/GetTemplate/_Logout",
            controller: "logoutController"
        }).
        when("/Register", {
            templateUrl: "/Template/GetTemplate/_Register",
            controller: "registrationController"
        }).
        when("/Project", {
            templateUrl: "/Template/GetAuthTemplate/_projectDetail",
            controller: "projectController"
        })    
        .otherwise("/Dashboard");

    });

}());