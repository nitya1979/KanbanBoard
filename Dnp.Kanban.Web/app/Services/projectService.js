(function () {

    var projectService = function ($http) {
        
        var getProjects = function () {

            return $http.get("/api/Project").then(function (response) {
                return response.data;
            });
        };

        var getProject = function (id) {
            return $http.get("/api/Project/" + id).then(function (response) {
                return response.data;
            });
        };

        var saveProject = function (project) {
            var url = "/api/Project";

            if (project.ID != 0)
                url = url + "/" + project.ID;

            return $http.post(url, JSON.stringify(project)).then(function (response) {
                return response.data;
            });

        };

        return {
            getProjects: getProjects,
            getProject: getProject,
            saveProject : saveProject
        };
    };

    var app = angular.module("kanbanBoard");
    app.factory("projectService", projectService);
}());