angular.module('app').component('massEdit', {
    templateUrl: '/' + getControllerName() + '/Edit',
    controller: massEditController,
    controllerAs: 'vm'
});
function massEditController($scope, $location, ajax, $routeParams,$timeout) {
    editController.call(this, $scope, $location, ajax, $routeParams);
    var vm = this;
    vm.$onInit = inicio;
    function inicio() {
        ajax.Get(getControllerName() + '/GetEditEntidad/' + $routeParams.id).then(function (res) {
            vm.entidad = res.data;
            vm.HoraInicio = parseInt(vm.entidad.FechaInicio.split(':')[0]);
            vm.MinutoInicio = parseInt(vm.entidad.FechaInicio.split(':')[1]);
            vm.Meridiano = vm.entidad.FechaInicio.split(':')[2];
            vm.HoraFinal = parseInt(vm.entidad.FechaFinal.split(':')[0]);
            vm.MinutoFinal = parseInt(vm.entidad.FechaFinal.split(':')[1]);
            vm.MeridianoFinal = vm.entidad.FechaFinal.split(':')[2];
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error :Compruebe Su Internet";
            alert(res);
        });
    }
    vm.entidad = {};
    vm.Meridiano = "AM";
    vm.cambiar = cambiar;
    vm.MeridianoFinal = "AM";
    vm.cambiarFinal = cambiarFinal;
    vm.guardar = guardar;
    function guardar() {
        vm.entidad = {
            FechaInicio: ((vm.HoraInicio.toString().length == 2) ? vm.HoraInicio : '0' + vm.HoraInicio) + ':' + ((parseInt(vm.MinutoInicio).toString().length == 2) ? vm.MinutoInicio : '0' + vm.MinutoInicio) + ':' + vm.Meridiano,
            FechaFinal: ((vm.HoraFinal.toString().length == 2) ? vm.HoraFinal : '0' + vm.HoraFinal) + ':' + ((parseInt(vm.MinutoFinal).toString().length == 2) ? vm.MinutoFinal : '0' + vm.MinutoFinal) + ':' + vm.MeridianoFinal,
            Id: $routeParams.id
        };
        ajax.Post(getControllerName() + '/Edit', vm.entidad).then(function (res) {
            vm.entidad = {};
            alert("Se Guardo Correctamente");
            $location.path('/');
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion";
            alert(res);
            vm.entidad = {};
        });
    }
    function cambiar() {
        if (vm.Meridiano == "AM") {
            vm.Meridiano = "PM";
        }
        else {
            vm.Meridiano = "AM";
        }
    }
    function cambiarFinal() {
        if (vm.MeridianoFinal == "AM") {
            vm.MeridianoFinal = "PM";
        }
        else {
            vm.MeridianoFinal = "AM";
        }
    }
   
}