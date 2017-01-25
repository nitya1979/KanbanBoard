(function () {
    var app = angular.module("kanbanBoard");

    var taskInfoCard = function () {
        return {
            restrict: "E",
            scope: {
                task: '=',
                stages: '=',
                priorities: '=',
                stageChange : '&onStageChanged'
            },
            templateUrl: "/app/directive/template/taskInfoCard.html",
            controller: function ($scope, $uibModal) {
                $scope.open = function (size) {
                    var modelInstance = $uibModal.open({
                        animation: true,
                        templateUrl: "/Template/GetAuthTemplate/_taskDetail",
                        controller: "taskController",
                        size: size,
                        resolve: {
                            taskId: function () {
                                return $scope.task.TaskID;
                            },
                            stages: function () {
                                return $scope.stages;
                            }
                        }
                    });

                    modelInstance.result.then(function (data) {
                        $scope.stageChange();
                    }, function () {

                        //Do Nothing
                    })
                };

                $scope.updatePriority = function (selectedPriority) {

                    $scope.task.Priority = selectedPriority;


                }
            }
        }
    };


    var priorityUpdater = function () {
        return {
            restrict: 'E',
            scope: {
                priorities: '=',
                selectedPriority: '=selected',
                priorityUpdate: '&onPriorityUpdate'
            },
            templateUrl: "/app/directive/template/priority-updater.html",
            controller: function ($scope, $filter) {

                function setPriority() {

                    $scope.selectedValue = parseInt($scope.selectedPriority);
                    $scope.showOption = false;

                    var found = $filter('filter')($scope.priorities, {
                        PriorityID: $scope.selectedValue
                    }, true);
                    $scope.selectedText = found[0].Name;

                };

                setPriority();

                $scope.updatePriority = function () {
                    $scope.selectedPriority = $scope.selectedValue;
                    $scope.priorityUpdate();
                    $scope.showOption = false;
                };

                $scope.changePriority = function (id, text) {

                    $scope.selectedValue = id;
                    $scope.selectedText = text;
                };

                $scope.cancel = function () {
                    setPriority();
                };

            }
        }
    };

    app.directive('taskInfoCard', taskInfoCard);
    app.directive('priorityUpdater', priorityUpdater);
}());