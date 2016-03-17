(function () {
    var app = angular.module("kanbanBoard");

    var dashboardController = function ($scope, projectService) {

        var onSuccess = function (data) {
            $scope.projects = data;
        };

        var onError = function (result) {
        };

        projectService.getProjects().then(onSuccess, onError);
    };

    app.controller("dashboardController", dashboardController);
}());