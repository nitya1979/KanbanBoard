(function () {
    var app = angular.module("kanbanBoard");

    var LoginController = function ($scope, $location, accountManager) {
        
        var loginData = {
            userName: "",
            loginPassword: ""
        };

        $scope.loginData = loginData;

        var onLoginComplete = function (data) {
            alert(data);
            //$location.url("/");
        };
        
        var onError = function (reason) {
            alert(reason);
            $scope.error = reason;
        }

        $scope.login = function () {

            accountManager.login($scope.loginData.userName, $scope.loginData.loginPassword);
                           //.then(onLoginComplete, onError);
        }
        
    };

    app.controller("LoginController", LoginController);
}());