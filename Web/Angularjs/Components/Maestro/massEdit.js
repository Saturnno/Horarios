angular.module('app').component('massEdit', {
    templateUrl:'/'+getControllerName()+'/Edit',
    controller: massEditController,
    controllerAs:'vm'
});
function massEditController($scope,$location,ajax,$routeParams,$timeout) {
    editController.call(this,$scope,$location,ajax,$routeParams);
    var vm = this;
    vm.listUnidades = [];
    vm.listDepartamentos = [];
    vm.listProgramasEducativos = [];
    vm.listNombramientos = [];
    vm.$onInit = inicio;
    function inicio(){
        ajax.Get(getControllerName() + '/GetEditEntidad/' + $routeParams.id).then(function (res) {
            vm.entidad = res.data;
            ajax.Get('api/combo/unidad').then(function (res) {
                vm.listUnidades = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error de Conexion : Combruebe su internet";
                alert(res);
            });
            ajax.Get("api/combo/nombramiento").then(function (res) {
                vm.listNombramientos = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error de Conexion";
                alert(res);
            });
            ajax.Get("api/combo/departamento/" + vm.entidad.UnidadId).then(function (res) {
                vm.listDepartamentos = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error de Conexion";
                alert(res);
            });
            ajax.Get("api/combo/programaeducativo/" + vm.entidad.DepartamentoId).then(function (res) {
                vm.listProgramasEducativos = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error de Conexion";
                alert(res);
            });
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error :Compruebe Su Internet";
            alert(res);
        });
    }
    
    vm.changeUnidad = changeUnidad;
    function changeUnidad() {
        ajax.Get("api/combo/departamento/" + vm.entidad.UnidadId).then(function (res) {
            vm.listDepartamentos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion";
            alert(res);
        });
    }
    vm.changeDepartamento = changeDepartamento;
    function changeDepartamento() {
        ajax.Get("api/combo/programaeducativo/" + vm.entidad.DepartamentoId).then(function (res) {
            vm.listProgramasEducativos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion";
            alert(res);
        });
    }
    
}