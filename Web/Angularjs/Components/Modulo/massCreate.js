angular.module('app').component('massCreate', {
    templateUrl: '/' + getControllerName() + '/Create',
    controller: massCreateController,
    controllerAs:'vm'
});
function massCreateController($scope, $location, ajax) {
    createController.call(this, $scope, $location, ajax);
    var vm = this;
    vm.entidad = {};
    vm.Meridiano = "AM";
    vm.cambiar = cambiar;
    vm.MeridianoFinal = "AM";
    vm.cambiarFinal = cambiarFinal;
    vm.guardar = guardar;
    function guardar() {
        vm.entidad = {
            FechaInicio: ((vm.HoraInicio.toString().length == 2) ? vm.HoraInicio : '0' + vm.HoraInicio) + ':' + ((parseInt(vm.MinutoInicio).toString().length == 2) ? vm.MinutoInicio : '0' + vm.MinutoInicio) + ':' + vm.Meridiano,
            FechaFinal: ((vm.HoraFinal.toString().length == 2) ? vm.HoraFinal : '0' + vm.HoraFinal) + ':' + ((parseInt(vm.MinutoFinal).toString().length == 2) ? vm.MinutoFinal : '0' + vm.MinutoFinal) +':'+ vm.MeridianoFinal
        };
        ajax.Post(getControllerName() + '/Create', vm.entidad).then(function (res) {
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