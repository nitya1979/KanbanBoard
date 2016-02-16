(function () {
    var app = angular.module("kanbanBoard");

    var LoginController = function ($scope, $location, accountManager, localStorageService, sharedService) {
        
        var loginData = {
            userName: "",
            loginPassword: ""
        };

        $scope.isAuth = true;
        $scope.loginData = loginData;
        var onLoginComplete = function (data) {
            $scope.isAuth = true;
            localStorageService.set('authorizationData', { token: data.access_token, userName: $scope.loginData.userName });
            sharedService.prepForBroadcast(true);
            $location.url("/Dashboard");
        };
        
        var onError = function (result) {
            $scope.error = result.data.error_description;
            $scope.isAuth = false;
            sharedService.prepForBroadcast(false);
        }

        $scope.login = function () {

            accountManager.login($scope.loginData.userName, $scope.loginData.loginPassword)
                          .then(onLoginComplete, onError);
        }
        
    };

    app.controller("LoginController", LoginController);
}());