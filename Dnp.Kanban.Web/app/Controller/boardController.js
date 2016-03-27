(function () {

    var app = angular.module("kanbanBoard");

    var boardController = function ($scope, $routeParams, projectService) {

        projectService.getStages($routeParams.projectId).then(function (data) {
            alert(JSON.stringify(data));

            var stages = new Array(data.length);

            var colValue = 12/data.length;

            for (var i = 0; i < data.length; i++) {
                
                stages[i] = new ProjectStage();
                stages[i].ID = data[i].ID;
                stages[i].ProjectID = data[i].ProjectID;
                stages[i].StageName = data[i].StageName;
                stages[i].className = "col-md-" + colValue;
            }
            
            $scope.stage = stages;
            
        }, function (result) {
            alert(JSON.stringify(result));
        }
        );

    };

    app.controller("boardController", boardController);

}());