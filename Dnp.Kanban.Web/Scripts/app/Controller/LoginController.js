(function () {
    var app = angular.module("kanbanBoard");

    var LoginController = function ($scope, $location, accountManager, access_token) {
        
        var loginData = {
            userName: "",
            loginPassword: ""
        };

        $scope.loginData = loginData;

        var onLoginComplete = function (data) {
            access_token = data.access_token;
            alert(data.access_token);
            $location.url("/");
        };
        
        var onError = function (reason) {
            alert(reason);
            $scope.error = reason;
        }

        $scope.login = function () {
            alert(JSON.stringify($scope.loginData));

            accountManager.login($scope.loginData.userName, $scope.loginData.loginPassword)
                           .then(onLoginComplete, onError);
        }
        
    };

    app.controller("LoginController", LoginController);
}());