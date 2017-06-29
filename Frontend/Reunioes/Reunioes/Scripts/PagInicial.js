(function () {
    
    var app = angular.module('PagInicial', ['ngRoute']);

    app.controller('HomeController', function ($scope) {
        $scope.Mensagem = "Olá.  Esse é nosso primeiro contato com o AgularJS no ASP .NEt MVC.";
    });

    app.controller('ReservasController', function ($scope) {
        $scope.Mensagem = "Teste Ilton Final";
    });

})();