﻿(function () {

    var accountManager = function ($http, localStorageService) {
        var authStatus = {
            isAuth: false,
            authMessage : 'Not Authenticated'
        };

        var login = function (userName, loginPassword) {

            var data = "grant_type=password&username=" + userName + "&password=" + loginPassword;

          return $http.post("/Token", data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                 .then(function (response) {
                     return response.data;
                 });


        };

        var logout = function () {
            localStorageService.clearAll();
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
        };

        return {
            login: login,
            logout: logout,
            register : register
        };
    };

    var module = angular.module("kanbanBoard");
    module.factory("accountManager", accountManager);
}());