angular.module('app').component('massEdit', {
    templateUrl: '/' + getControllerName() + '/Edit',
    controller: massEditController,
    controllerAs:'vm'
});
function massEditController($scope, $location, ajax, $routeParams,$timeout) {
    editController.call(this, $scope, $location, ajax, $routeParams);
    var vm = this;
    vm.$onInit = inicio;
    vm.listDepartamentos = [];
    vm.listUnidades = [];
    vm.change = change;
    function change() {
        $timeout(function () {
            ajax.Get('api/combo/departamento/'+vm.entidad.UnidadId).then(function (res) {
                vm.listDepartamentos = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error de Conexion";
                alert(res);
            });
        }, 100);
    }
    function inicio() {
        ajax.Get('api/combo/unidad').then(function (res) {
            vm.listUnidades = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion";
            alert(res);
        });
        $timeout(function () {
            ajax.Get(getControllerName() + '/GetEditEntidad/' + $routeParams.id).then(function (res) {
                vm.entidad = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error :Compruebe Su Internet";
                alert(res);
            });
        }, 100);
        $timeout(function () {
            ajax.Get('api/combo/departamento/' + vm.entidad.UnidadId).then(function (res) {
                vm.listDepartamentos = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error de Conexion";
                alert(res);
            });
        }, 150);
    }

}