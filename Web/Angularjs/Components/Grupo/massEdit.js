angular.module('app').component('massEdit', {
    templateUrl: '/' + getControllerName() + '/Edit',
    controller: massEditController,
    controllerAs: 'vm'
});
function massEditController($scope, $location, ajax, $routeParams, $timeout) {
    editController.call(this, $scope, $location, ajax, $routeParams);
    var vm = this;
    vm.listTrimestres = [];
    vm.listProgramasEducativos = [];
    vm.listTurnos = [];
    vm.listUnidades = [];
    vm.$onInit = inicio;
    function inicio() {
        ajax.Get('api/combo/unidad').then(function (res) {
            vm.listUnidades = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error De Conexion";
            alert(res);
        });
        ajax.Get('api/combo/trimestre').then(function (res) {
            vm.listTrimestres = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error De Conexion";
            alert(res);
        });
        ajax.Get('api/combo/turno').then(function (res) {
            vm.listTurnos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error De Conexion";
            alert(res);
        });
        $timeout(function () {
            ajax.Get(getControllerName() + '/GetEditEntidad/' + $routeParams.id).then(function (res) {
                vm.entidad = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error :Compruebe Su Internet";
                alert(res);
            });
        }, 50);
        $timeout(function () {
            ajax.Get('api/combo/programaeducativo/' + vm.entidad.UnidadId).then(function (res) {
                vm.listProgramasEducativos = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error De Conexion";
                alert(res);
            });
        }, 150);
    }
    vm.changeUnidad = changeUnidad;
    function changeUnidad() {
        ajax.Get('api/combo/programaeducativo/' + vm.entidad.UnidadId).then(function (res) {
            vm.listProgramasEducativos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error De Conexion";
            alert(res);
        });
    }
}