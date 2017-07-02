(function () {
    
    var app = angular.module('PagInicial', ['ngRoute']);

    app.controller('HomeController', function ($scope) {
    });

    app.controller('ReservasController', ['$scope',function ($scope) {
        $scope.function1 = function (msg) {
            alert(msg + ' first function call!');
        }
    }]);

})();
