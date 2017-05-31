(function () {
    var app = angular.module("kanbanBoard");

    var dashboardController = function ($scope, projectService, taskService) {

        var onSuccess = function (data) {
            
            $scope.projects = data;
        };

        var onError = function (result) {
            alert(result.data.Message);
        };

        projectService.getProjects().then(onSuccess, onError);

        taskService.getDueTasks().then(function (data) {
            $scope.dueTasks = data;
        }, function (result) {
            alert(result.data.Message);
        }
        );
    };

    app.controller("dashboardController", dashboardController);
}());