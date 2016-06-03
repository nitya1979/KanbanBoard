(function () {
    var app = angular.module("kanbanBoard");

    var taskController = function ($scope, $uibModalInstance) {
        $scope.Message = "This is model from template (NEW)";
        $scope.ok = function () {
            $uibModalInstance.close("Modal Data");
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss("cancel");
        };
    };

    app.controller("taskController", taskController);
}());