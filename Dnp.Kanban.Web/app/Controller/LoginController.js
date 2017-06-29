(function () {
    var app = angular.module("kanbanBoard");

    var LoginController = function ($scope, $location, accountManager, sharedService) {
        
        var loginData = {
            userName: "",
            loginPassword: "",
            rememberMe: false
        };

        $scope.isAuth = true;
        $scope.loginData = loginData;
        var onLoginComplete = function (data) {
            $scope.isAuth = true;

            sharedService.prepForBroadcast(true);

            $location.url("/Dashboard");
        };
        
        var onError = function (result) {
            alert(JSON.stringify(result));
            $scope.error = result.data.error_description;
            $scope.isAuth = false;
            sharedService.prepForBroadcast(false);
        }

        $scope.login = function () {

            accountManager.login($scope.loginData.userName, $scope.loginData.loginPassword, $scope.loginData.rememberMe)
                          .then(onLoginComplete, onError);
        }
        
    };

    app.controller("LoginController", LoginController);
}());