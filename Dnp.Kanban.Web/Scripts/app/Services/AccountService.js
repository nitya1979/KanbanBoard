(function () {

    var accountManager = function ($http) {

        var login = function (userName, loginPassword) {

//            var data = "grant_type=password&username=" + userName + "&password=" + loginPassword;

            var data = {
                grant_type: "password",
                username: userName,
                password: loginPassword
            };

            alert("account Manager : " + data);

            //$http.post("/Token", data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                //localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });

                //_authentication.isAuth = true;
                //_authentication.userName = loginData.userName;
            //    return response;

            //}).error(function (err, status) {
            //    alert(JSON.stringify( err));
            //});

            $http.post("/Token", data)
                 .then(function (response) {
                     alert(JSON.stringify( response.data));
                     return response.data;
                 });

        };

        var register = function (userName, loginPassword, confirmPassword) {
            var data = {
                Email: userName,
                Password: loginPassword,
                ConfirmPassword: confirmPassword
            };

            alert(JSON.stringify(data));

            $http.post("/api/Account/Register", JSON.stringify(data))
                 .then(function (response) {
                     return response.data;
                 });
        };

        return {
            login: login,
            register : register
        };
    };

    var module = angular.module("kanbanBoard");
    module.factory("accountManager", accountManager);
}());