(function () {
    var app = angular.module("kanbanBoard");

    var logoutController = function ($scope, accountManager, sharedService) {
        
        $scope.logout = function () {
            accountManager.logout();
            sharedService.prepForBroadcast(false);
        };

        $scope.logout();
    };

    app.controller("logoutController", logoutController);
}());