(function () {
    var taskService = function ($http) {

        var getTask = function (taskId) {
            return $http.get("api/Task/" + taskId)
                    .then(function (response) {
                        return response.data;
                    });
        };

        var getAllTasks = function (projectId) {
            return $http.get("api/Project/" + projectId + "/Task/1")
                        .then(function (response) {
                            return response.data;
                        });
        };

        //var saveTask = function (dnpTask) {
        //    return $http.post("api/Task")
        //};

        return {
            getTask: getTask,
            getTasks : getAllTasks
        };
    };

    var module = angular.module("kanbanBoard");
    module.factory("taskService", taskService);
}());