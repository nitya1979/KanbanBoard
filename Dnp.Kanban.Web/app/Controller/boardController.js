(function () {

    var app = angular.module("kanbanBoard");

    var boardController = function ($scope, $routeParams, projectService, taskService, commonDataService, $uibModal) {

        projectService.getProject($routeParams.projectId).then(function (data) {

            $scope.ProjectName = data.Name;
            $scope.ProjectID = data.ID;
        });

        var getStages = function () {
            projectService.getStages($routeParams.projectId).then(function (data) {

                var stages = new Array(data.length);

                var colValue = 12 / data.length;
                var height = $(document).height() - 150;

                for (var i = 0; i < data.length; i++) {

                    stages[i] = new ProjectStage();
                    stages[i].ID = data[i].ID;
                    stages[i].ProjectID = data[i].ProjectID;
                    stages[i].StageName = data[i].StageName;
                    stages[i].className = "col-sm-" + colValue + " col-md-" + colValue;
                    stages[i].height = { "height": height + "px" };
                }

                $scope.stages = stages;

                $scope.addNew = function () {
                    alert("Add New Stage");
                };

            }, function (result) {
                alert(JSON.stringify(result));
            }
            );
        };
        
        var getPriorities = function () {
            commonDataService.getPriorities().then(function (data) {
                $scope.priorities = data;

            }, function (result) {
                alert(JSON.stringify(result));
            });
        };

        var getTasks = function () {
            
            taskService.getTasks($routeParams.projectId)
                       .then(function (data) {
                           $scope.tasks = data;
                       }, function (result) {
                           alert(JSON.stringify(result));
                       });

        };

        getStages();
        getPriorities();
        getTasks();

        $scope.refreshTasks = getTasks;

        $scope.open = function (size) {
            var modelInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Template/GetAuthTemplate/_taskDetail",
                controller: "taskController",
                size: size,
                resolve: {
                    taskId: function () {
                        return 0;
                    },
                    stages: function () {
                        return $scope.stages;
                    }
                }
            });

            modelInstance.result.then(function (data) {
                getTasks();
            }, function () {
                //Do Nothing
            }).catch(function (err) {
                alert(JSON.stringify(err));
            });
        };

        $scope.newStage = function(){
            var modelInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Template/GetAuthTemplate/_stage",
                controller: "stageController",
                resolve: {
                    projectId: function(){
                        return $routeParams.projectId;
                    },
                    stageId: function () {
                        return 0;
                    },
                    stageName: function () {
                        return "";
                    }
                }
            });

            modelInstance.result.then(function (data) {
                getStages();

            }, function () {
                //Do Nothing
            }).catch(function (err) {
                alert(JSON.stringify(err));
            });
        };

        $scope.doDrop = function (task, newStage) {
            task.ProjectStageID = newStage.ID;
            taskService.saveTask(newStage.ProjectID, task)
                       .then(function (data) {
                           //ToDo
                       });
        };
    };

    app.controller("boardController", boardController);

}());