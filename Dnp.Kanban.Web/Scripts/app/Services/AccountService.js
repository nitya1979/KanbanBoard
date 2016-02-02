﻿(function () {

    var accountManager = function ($http) {

        var login = function (userName, loginPassword) {

            var data = {
                grant_type : "password",
                username: userName,
                password: loginPassword
            };

            $http.post("/Token", JSON.stringify( data))
                 .then(function (response) {
                return response.data;
            });
        }

        var register = function (userName, loginPassword, confirmPassword) {

            var data = {
                Email: userName,
                Password: loginPassword,
                ConfirmPassword: confirmPassword
            };

            $http.post("/api/Account/Register", JSON.stringify(data))
                 .then(function (response) {
                     return response.data;
                 });
        }

        return {
            login : login
        };
    };

    var module = angular.module("kanbanBoard");
    module.factory("accountManager", accountManager);
}());