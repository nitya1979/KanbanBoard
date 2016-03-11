(function () {
    var app = angular.module("kanbanBoard");

    var logoutController = function ($scope, accountManager, sharedService) {

        var onLogoutSuccess = function (data) {
            sharedService.prepForBroadcast(false);
        };

        var onLogoutError = function (result) {
            $scope.error = result.data.error_description;
        };

        $scope.logout = function () {
            accountManager.logout().then(onLogoutSuccess, onLogoutError);
        };

        $scope.logout();
    };

    app.controller("logoutController", logoutController);
}());