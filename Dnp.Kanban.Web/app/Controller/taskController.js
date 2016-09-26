(function () {
    var app = angular.module("kanbanBoard");

    var taskController = function ($scope, $uibModalInstance, commonDataService, taskId) {
        $scope.dnpTaskViewModel = new DnpTask();

        commonDataService.getPriorities().then(function (data) {
            $scope.priorityList = data;
        },
        function (result) {
            alert(JSON.stringify(result));
        });

        $scope.ok = function () {
            $uibModalInstance.close("Modal Data");
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss("cancel");
        };
    };

    app.controller("taskController", taskController);
}());