(function () {

    var projectService = function ($http) {
        
        var getProjects = function () {

            return $http.get("/api/Project/Recent/4").then(function (response) {
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

        var getStages = function (projectId) {

            return $http.get("/api/Project/Stages/" + projectId).then(function (response) {
                return response.data;
            });
        };

        var saveStage = function (projectStage) {
            alert(JSON.stringify(projectStage));
            return $http.post("/api/Project/" + projectStage.ProjectID + "/Stage", JSON.stringify(projectStage))
                        .then(function (response) {
                            return response.data;
                        })
        };



        return {
            getProjects: getProjects,
            getProject: getProject,
            saveProject: saveProject,
            getStages: getStages,
            saveStage: saveStage
        };
    };

    var app = angular.module("kanbanBoard");
    app.factory("projectService", projectService);
}());