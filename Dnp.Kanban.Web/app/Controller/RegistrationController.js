(function () {

    var app = angular.module("kanbanBoard");

    var registrationController = function ($scope, $location, accountManager) {

        var regData = {
            Email: "",
            Password: "",
            ConfirmPassword: ""
        };

        $scope.regData = regData;

        var onRegComplete = function (data) {
            alert(data.message);
        };

        var onError = function (reason) {
            alert(reason);
            $scope.error = reason;
        };

        $scope.register = function () {
            alert($scope.regData.Email);
            accountManager.register($scope.regData.Email, $scope.regData.Password, $scope.regData.ConfirmPassword)
                           .then(onRegComplete, onError);
        };

    };

    app.controller("registrationController", registrationController);
}());