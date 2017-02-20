(function () {
    var app = angular.module("kanbanBoard");

    var DROP = "drop";
    var DRAGGABLE = "draggable";
    var DRAGOVER = "dragover";
    var DRAGSTART = "dragstart";
    var $DESTROY = "$destroy";

    var dragDropService = function () {
        var Service = function()
        {
            this.counter = 0;
            this.data = {};
        }

        Service.prototype.setData = function (id, dataItem) {
            this.data[id] = dataItem;
        };

        Service.prototype.getData = function (id) {
            return this.data[id];
        };

        Service.prototype.removeData = function (id) {
            if (this.data[id]) {
                delete this.data[id];
            }
        };

        Service.prototype.hasData = function (id) {

            return this.data[id] != null;
        }

        return new Service();
    };

    var drag = function ($rootScope, dragDropService) {

        return {
            restrict: 'A',
            link: function (scope, element, attrs) {

                element.attr(DRAGGABLE, "true");
                
                var fnDrag = function (event) {

                    if (event.originalEvent)
                        event.dataTransfer = event.originalEvent.dataTransfer;

                    event.dataTransfer.setData("text", event.target.id);
                    
                    dragDropService.setData(event.target.id, scope.$eval(attrs.dragModel));
                };

                var fnDrop = function (event) {

                    if( !dragDropService.hasData(event.target.id))
                    {
                        event.preventDefault();

                    }
                };

                element.on(DRAGSTART, fnDrag);
                element.on(DROP, fnDrop);

                scope.$on($DESTROY, function () {
                    element.unbind(DRAGSTART, fnDrag);
                    element.unbind(DROP, fnDrop);
                });
            }
        };
    };

    var drop = function ($rootScope, dragDropService) {

        return {
            restrict: 'A',
            link: function (scope, element, attrs) {

                var fnAllowDrop = function (event) {

                    if (event.target.tagName == "TD") {
                        event.preventDefault();
                    }
                };

                var fnDrop = function (event) {

                    if (event.originalEvent)
                        event.dataTransfer = event.originalEvent.dataTransfer;

                    if (!dragDropService.hasData(event.target.id)) {
                        var sourceId = event.dataTransfer.getData("text");
                        var data = dragDropService.getData(sourceId);
                        var dropData = scope.$eval(attrs.dropModel);

                        if (attrs.dropCallback)
                        {
                            var dropCallback = scope.$eval(attrs.dropCallback);

                            if (angular.isFunction(dropCallback))
                                dropCallback(data, dropData);
                            
                        }

                        dragDropService.removeData(sourceId);
                        event.target.appendChild(document.getElementById(sourceId));
                    }

                };

                element.on(DROP, fnDrop);
                element.on(DRAGOVER, fnAllowDrop);
                scope.$on($DESTROY, function () {
                    element.unbind(DRAGOVER, fnAllowDrop);
                    element.unbind(DROP, fnDrop);
                });
            }
        };
    };

    app.factory("dragDropService", dragDropService);
    app.directive("drag", drag);
    app.directive("drop", drop);
}());