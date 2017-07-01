(function () {
    
    var app = angular.module('PagInicial', ['ngRoute']);

    app.controller('HomeController', function ($scope) {
        $scope.Mensagem = "Olá.  Esse é nosso primeiro contato com o AgularJS no ASP .NEt MVC.";
    });

    app.controller('ReservasController', function ($scope, $http) {
        $scope.Mensagem = "Teste Ilton Final";

        $scope.lista = [
           {
               name: 'Nexus S',
               snippet: 'Fast just got faster with Nexus S.'
           }, {
               name: 'Motorola XOOM™ with Wi-Fi',
               snippet: 'The Next, Next Generation tablet.'
           }, {
               name: 'MOTOROLA XOOM™',
               snippet: 'The Next, Next Generation tablet.'
           }
        ];


    });

})();
