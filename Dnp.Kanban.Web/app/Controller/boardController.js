(function () {

    var app = angular.module("kanbanBoard");

    var boardController = function ($scope, $routeParams, projectService) {

        projectService.getStages($routeParams.projectId).then(function (data) {

            var stages = new Array(data.length);

            var colValue = 12 / data.length;
            var height = $(document).height() - 150;

            for (var i = 0; i < data.length; i++) {
                
                stages[i] = new ProjectStage();
                stages[i].ID = data[i].ID;
                stages[i].ProjectID = data[i].ProjectID;
                stages[i].StageName = data[i].StageName;
                stages[i].className = "col-sm-"+colValue+" col-md-" + colValue;
                stages[i].height = {"height" : height + "px"};
            }
            
            $scope.stages = stages;

            $scope.addNew = function () {
                alert("Add New Stage");
            };

        }, function (result) {
            alert(JSON.stringify(result));
        }
        );

        $scope.showDialog = function(){
            $("#myModal").modal();
        };
    };

    app.controller("boardController", boardController);

}());