angular.module('app').component('massEdit', {
    templateUrl: '/' + getControllerName() + '/Edit',
    controller: massEditController,
    controllerAs: 'vm'
});
function massEditController($scope, $location, ajax, $routeParams, $timeout) {
    editController.call(this, $scope, $location, ajax, $routeParams);
    var vm = this;
    vm.listMeses = [];
    $timeout(function () {
        ajax.Get('api/combo/mes').then(function (res) {
            vm.listMeses = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion";
            alert(res);
        });
    }, 100);
}