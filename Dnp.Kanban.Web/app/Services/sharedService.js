(function () {
    var sharedService = function ($rootScope) {
        var mySharedServive = {};
        mySharedServive.isAuth = false;

        mySharedServive.prepForBroadcast = function (msg) {
            this.isAuth = msg;
            this.broadCastItem();
        };

        mySharedServive.broadCastItem = function () {
            $rootScope.$broadcast("handleBroadCast");
        };


        return mySharedServive;
    };

    var module = angular.module("kanbanBoard");
    module.factory("sharedService", sharedService);
}());