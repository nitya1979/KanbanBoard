(function () {
    var app = angular.module("kanbanBoard");

    var projectController = function ($scope, $location) {
        $('#startDate').datetimepicker({
            format: 'MM/DD/YYYY'
        });
        $scope.Name = "Test@ms.com";
        var currentDate = new Date();
        $scope.startDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate());
    };

    app.controller("projectController", projectController);
}());