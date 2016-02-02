(function () {
    var app = angular.module("kanbanBoard", []);

    var LoginController = function ($scope, $location, accountManager, access_token) {
        
        var loginData = {
            userName: "",
            loginPassword: ""
        };

        $scope.loginData = loginData;

        var onLoginComplete = function (data) {
            access_token = data.access_token;
            $location.url("/");
        };
        
        var onError = function (reason) {
            alert(reason);
            $scope.error = reason;
        }
    };

    app.controller("LoginController", LoginController);
}());