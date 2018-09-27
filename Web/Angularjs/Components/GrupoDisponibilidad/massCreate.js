angular.module('app').component('massCreate', {
    templateUrl: '/' + getControllerName() + '/Create',
    controller: massCreateController,
    controllerAs:'vm'
});
function massCreateController($scope, $location, ajax) {
    createController.call(this, $scope, $location, ajax);
    var vm = this;
    vm.$onInit = inicio;
    vm.listUnidades = [];
    vm.listDepartamentos = [];
    vm.listProgramasEducativos = [];
    vm.listMaterias = [];
    vm.listModulos = [];
    vm.listGrupos = [];
    vm.listMaestros = [];
    vm.listDias = [];
    vm.listTrimestres = [];
    vm.listDisponibilidades = [];
    function inicio() {
        ajax.Get('api/combo/unidad').then(function (res) {
            vm.listUnidades = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion';
            alert(res);
        });
        
        ajax.Get('api/combo/modulo').then(function (res) {
            vm.listModulos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion';
            alert(res);
        });
        ajax.Get('api/combo/dia').then(function (res) {
            vm.listDias = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion';
            alert(res);
        });
        ajax.Get('api/combo/trimestre').then(function (res) {
            vm.listTrimestres = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion';
            alert(res);
        });
    }
    vm.changeUnidad = changeUnidad;
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
    vm.changeMaestro = changeMaestro;
    function changeMaestro() {
        ajax.Get('api/combo/maestrodisponibilidad/' + vm.entidad.MaestroId).then(function (res) {
            vm.Disponibilidad = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
        
    }
    vm.changeTrimestre = changeTrimestre;
    function changeTrimestre() {
        ajax.Get(getControllerName() + '/MateriaAsignada/?maestro=' + vm.entidad.MaestroId + '&programa=' + vm.entidad.ProgramaEducativoId + '&&trim=' + vm.entidad.TrimestreId).then(function (res) {
            vm.listMaterias = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion';
            alert(res);
        });
        ajax.Get(getControllerName() + '/BuscaDisponibilidades/?maestro=' + vm.entidad.MaestroId + '&trimestre=' + vm.entidad.TrimestreId).then(function (res) {
            vm.listDisponibilidades = res.data;
        }, function (err) {
            console.log(err);
        });
        ajax.Get(getControllerName()+'/Grupos/?id=' + vm.entidad.ProgramaEducativoId + '&trimestre=' + vm.entidad.TrimestreId).then(function (res) {
            vm.listGrupos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
    }
    vm.guardar = guardar;
    function guardar() {
        ajax.Post(getControllerName() + '/Create', vm.entidad).then(function (res) {
            vm.listDisponibilidades.push(res.data);
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error Compruebe su conexion ";
            alert(res);
        });
    }
    vm.limpiar = limpiar;
    function limpiar() {
        vm.entidad = {};
    }
}