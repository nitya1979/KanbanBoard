(function () {

    var accountManager = function ($http, $cookies) {
        var authStatus = {
            isAuth: false,
            authMessage: 'Not Authenticated'
        };

        var login = function (userName, loginPassword, rememberMe) {

            var data = "grant_type=password&username=" + userName + "&password=" + loginPassword;

            return $http.post("Token", data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                   .then(function (response) {
                       var currentDate = new Date();
                       if (rememberMe == true) {
                           $cookies.put('token', response.data.access_token, { expires: new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 13) });
                           $cookies.put('userName', response.data.userName);
                       }
                       else {
                           $cookies.put('token', response.data.access_token);
                           $cookies.put('userName', response.data.userName);

                       }

                       return response.data;
                   });


        };

        var logout = function () {
            return $http.post("api/Account/Logout").then(function (response) {
                alert(JSON.stringify(response));
                $cookies.remove('token');
                return response.data;
            });
        };

        var register = function (userName, loginPassword, confirmPassword) {
            var data = {
                Email: userName,
                Password: loginPassword,
                ConfirmPassword: confirmPassword
            };

            $http.post("api/Account/Register", JSON.stringify(data))
                 .then(function (response) {
                     return response.data;
                 });
        };

        var isAuth = function () {

            if ($cookies.get('token'))
                return true;
            else
                return false;
        };

        return {
            login: login,
            logout: logout,
            register: register,
            isAuthorized: isAuth
        };
    };

    var module = angular.module("kanbanBoard");
    module.factory("accountManager", accountManager);
}());