(function () {
    var app = angular.module("kanbanBoard");

    var menuController = function ($scope, $location, accountManager, projectService) {

        $scope.isAuth = accountManager.isAuthorized();

        projectService.getProjects().then(function (data) {
            $scope.projectList = data;
            $scope.selectedProject = $scope.projectList[0];
        }, function (result) { alert(JSON.stringify(result)); });
        
        
        $scope.$on("handleBroadCast", function () {
            $scope.isAuth = accountManager.isAuthorized();
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