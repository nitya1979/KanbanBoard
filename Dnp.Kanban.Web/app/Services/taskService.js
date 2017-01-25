(function () {
    var taskService = function ($http) {

        var getTask = function (projectId, taskId) {
            return $http.get("api/Project/" + projectId + "/Task/" + taskId)
                    .then(function (response) {
                        var task = response.data;
                        task.DueDate = new Date(task.DueDate);
                        return task;
                    });
        };

        var getAllTasks = function (projectId) {
            return $http.get("api/Project/" + projectId + "/Tasks")
                        .then(function (response) {
                            return response.data;
                           
                        });
        };

        var saveTask = function (projectId, dnpTask) {
            if (dnpTask.TaskID == 0){
                return $http.post("api/Project/" + projectId + "/Task", JSON.stringify(dnpTask))
                                 .then(function (response) {
                                     return response;
                                 });
            }
            else {

                return $http.put("api/Project/" + projectId + "/Task/"+dnpTask.TaskID, JSON.stringify(dnpTask))
                                 .then(function (response) {
                                     return response;
                                 });
            }
        };

        return {
            getTask: getTask,
            getTasks : getAllTasks,
            saveTask : saveTask
        };
    };

    var module = angular.module("kanbanBoard");
    module.factory("taskService", taskService);
}());