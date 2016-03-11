(function () {

    var projectService = function () {
        
        var getProjects = function () {

            var array = new Array('proj1', 'proj2', 'proj3');

            return array;
        };


        return {
            getProjects : getProjects
        };
    };

    var app = angular.module("kanbanBoard");
    app.factory("projectService", projectService);
}());