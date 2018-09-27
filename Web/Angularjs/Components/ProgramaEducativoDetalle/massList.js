angular.module('app').component('massList', {
    templateUrl: '/' + getControllerName() + '/MassList',
    controller: massListController,
    controllerAs: 'vm'
});
function massListController($scope, $location, ajax) {
    listController.call(this, $scope, $location, ajax);
    var vm = this;
    vm.listUnidades = [];
    vm.listDepartamentos = [];
    vm.listProgramasEducativos = [];
    vm.listTrimestres = [];
    vm.listProgramasEducativosDetalles = [];
    vm.changeUnidad = changeUnidad;
    vm.$onInit = inicio;
    function inicio() {
        ajax.Get('api/combo/unidad').then(function (res) {
            vm.listUnidades = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
        ajax.Get('api/combo/trimestre').then(function (res) {
            vm.listTrimestres = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
    }
    function changeUnidad() {
        ajax.Get('api/combo/departamento/' + vm.entidad.UnidadId).then(function (res) {
            vm.listDepartamentos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
    }
    vm.changeDepartamento = changeDepartamento;
    function changeDepartamento() {
        ajax.Get('api/combo/programaeducativo/' + vm.entidad.DepartamentoId).then(function (res) {
            vm.listProgramasEducativos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
    }
    vm.changeProgramaEducativo = changeProgramaEducativo;
    function changeProgramaEducativo() {
        ajax.Get('api/combo/maestro/' + vm.entidad.ProgramaEducativoId).then(function (res) {
            vm.listMaestros = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
    }
    vm.changeTrimestre = changeTrimestre;
    function changeTrimestre() {
        ajax.Get(getControllerName()+'/Buscar/?programa='+vm.entidad.ProgramaEducativoId+'&trimestre='+vm.entidad.TrimestreId).then(function (res) {
            vm.listProgramasEducativosDetalles = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion";
            alert(res);
        });
    }
}
