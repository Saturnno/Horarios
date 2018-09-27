angular.module('app').component('massCreate', {
    templateUrl: '/' + getControllerName() + '/Create',
    controller: massCreateController,
    controllerAs: 'vm'
});
function massCreateController($scope, $location, ajax, $timeout) {
    createController.call(this, $scope, $location, ajax);
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
    }
    vm.changeUnidad = changeUnidad;
    function changeUnidad() {
        ajax.Get('api/combo/programaeducativo/'+vm.entidad.UnidadId).then(function (res) {
            vm.listProgramasEducativos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error De Conexion";
            alert(res);
        });
    }
}