(function () {
    var app = angular.module("kanbanBoard");

    var projectController = function ($scope, $location, $routeParams, projectService) {
        
        var onError = function(result){
            alert(JSON.stringify(result));
        };

        if ($routeParams.ID > 0) {
            projectService.getProject($routeParams.ID).then(function (data) {
                alert(JSON.stringify(data));
                $scope.project = data;
                $scope.project.StartDate = new Date(data.StartDate);
                $scope.project.EndDate = new Date(data.EndDate);

                
            }, onError);
        } else {
            $scope.project = new Project();
        }


        $scope.startDateOptions = {
            //dateDisabled: disabled,
            formatYear: 'yy',
            startingDay: 1
        };

        $scope.endDateOptions = {
            formatYear: 'yy',
            minDate: new Date(),
            startingDay: 1
        };

        $scope.startDatePopup = {
            opened: false
        };

        $scope.endDatePopup = {
            opened: false
        };
        //function disabled(data) {
        //    var date = data.date,
        //      mode = data.mode;
        //    return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        //};
        
        $scope.startDateOpen = function () {
            $scope.startDatePopup.opened = true;
        };

        $scope.endDateOpen = function () {
            $scope.endDatePopup.opened = true;
            $scope.endDateOptions.minDate = $scope.project.StartDate;
            alert($scope.project.StartDate);
        };
        
        $scope.save = function () {
            projectService.saveProject($scope.project).then(function (data) {
                alert(JSON.stringify(data));
            }, onError);
            
        };
    };

    app.controller("projectController", projectController);
}());