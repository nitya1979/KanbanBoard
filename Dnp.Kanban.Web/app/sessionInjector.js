(function () {
    var app = angular.module("kanbanBoard");

    var sessionInjector = function ($q, $cookies, $location) {

        var sessionInj = {
            request: function (config) {
                config.headers.Authorization = 'Bearer ' + $cookies.get('token');
                return config;
            },

            response: function (response) {

                return response;
            },

            responseError: function (response) {

                if (response.status == 401)
                    $location.url("/Login");

                return $q.reject( response);
            }
        };

        return sessionInj;
    };


    app.factory('sessionInjector', ['$q', '$cookies', '$location', sessionInjector]);

    app.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('sessionInjector');
    }]);
}());