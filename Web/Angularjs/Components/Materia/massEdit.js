angular.module('app').component('massEdit', {
    templateUrl: '/' + getControllerName() + '/Edit',
    controller: massEditController,
    controllerAs:'vm'
});
function massEditController($scope, $location, ajax,$routeParams,$timeout) {
    editController.call(this, $scope, $location, ajax, $routeParams);
    var vm = this;
    vm.listCategorias = [];
    $timeout(function () {
        ajax.Get('api/combo/categoria').then(function (res) {
            vm.listCategorias = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion :Compruebe su internet";
            alert(res);
        });
    }, 100);
}