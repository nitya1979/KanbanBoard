(function () {
    var app = angular.module("kanbanBoard");

    var dashboardController = function ($scope, projectService, taskService) {

        var onSuccess = function (data) {
            $scope.colors = ['#F7464A', // red
                            '#FDB45C', // yellow
                            '#46BFBD'];
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

        $scope.filterOverDue = function (value, index, array) {
            var today = new Date();
            today = Date.parse((today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear());
            return value.DueDate < today;
        };

        $scope.filterToday = function (value, index, array) {
            var today = new Date();
            today = Date.parse((today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear());
            return value.DueDate == today;

        };

        $scope.filterThisWeek = function (value, index, array) {
            var today = new Date();
            today = Date.parse((today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear());
            var dueDate = Date.parse(value.DueDate);
            return value.DueDate > today;

        };

       
    };

    app.controller("dashboardController", dashboardController);
}());