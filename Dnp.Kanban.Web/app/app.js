(function () {
    var app = angular.module("kanbanBoard", ["ngRoute", "LocalStorageModule", "ngCookies", "ui.bootstrap","chart.js"]);

    app.config(['$locationProvider', function ($locationProvider) {
        $locationProvider.hashPrefix('');
        $locationProvider.html5Mode(true);
    }]);

    app.config(function ($routeProvider) {
        $routeProvider.when("/Dashboard", {
            templateUrl: "Template/GetAuthTemplate/_dashboard",
            controller: "dashboardController"
        }).
        when("/Login",{
            templateUrl: "Template/GetTemplate/_Login",
            controller: "LoginController"
        }).
        when("/Logout", {
            templateUrl: "Template/GetTemplate/_Logout",
            controller: "logoutController"
        }).
        when("/Register", {
            templateUrl: "/Template/GetTemplate/_Register",
            controller: "registrationController"
        }).
        when("/Project", {
            templateUrl: "/Template/GetAuthTemplate/_projectDetail",
            controller: "projectController"
        }).
        when("/Project/:ID", {
            templateUrl: "/Template/GetAuthTemplate/_projectDetail",
            controller: "projectController"
        }).
        when("/Board/:projectId/:taskId?",{
            templateUrl: "Template/GetAuthTemplate/_Board",
            controller: "boardController"
        }).
        otherwise("/Dashboard");

    }).directive('convertToNumber', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {
                ngModel.$parsers.push(function (val) {
                    return parseInt(val, 10);
                });
                ngModel.$formatters.push(function (val) {
                    return '' + val;
                });
            }
        };
    });

}());