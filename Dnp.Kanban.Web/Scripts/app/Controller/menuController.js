(function () {
    var app = angular.module("kanbanBoard");

    var menuController = function ($scope, $location, sharedService, accountManager) {

        $scope.isAuth = false;

        $scope.$on("handleBroadCast", function () {
            $scope.isAuth = sharedService.isAuth;
        });

        $scope.doLogin = function () {
            $location.url("/Login");
        };

        $scope.doLogout = function () {
            $location.url("/Logout");
        };

        $scope.doRegister = function () {
            $location.url("/Register");
        }

        $scope.addProject = function () {
            $location.url("/Project");
        }
    };

    app.controller("menuController", menuController);
}());