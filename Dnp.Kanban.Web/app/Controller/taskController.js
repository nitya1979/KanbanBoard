(function () {
    var app = angular.module("kanbanBoard");

    var taskController = function ($scope, $uibModalInstance, commonDataService, taskId, stages, taskService) {

        $scope.Stages = stages;

        var onError = function (result) {
            alert(JSON.stringify(result));
        };

        if (taskId == 0) {
            $scope.dnpTaskViewModel = new DnpTask();
            $scope.dnpTaskViewModel.StageID = stages[0].ID;
        }
        else {
            taskService.getTask(taskId).then(function (data) {
                $scope.dnpTaskViewModel = data;
            }, onError);
        }
        
        $scope.dueDateOptions = {
            //dateDisabled: disabled,
            formatYear: 'yy',
            startingDay: 1
        };

        $scope.dueDatePopup = {
            opened: false
        };

        $scope.dueDateOpen = function () {
            $scope.dueDatePopup.opened = true;
        };

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