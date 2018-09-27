angular.module('app').component('massCreate', {
    templateUrl: '/' + getControllerName() + '/Create',
    controller: massCreateController,
    controllerAs: 'vm'
});
function massCreateController($scope, $location, ajax,$timeout) {
    createController.call(this, $scope, $location, ajax);
    var vm = this;
    vm.listDepartamentos = [];
    vm.change = change;
    function change() {
        $timeout(function () {
            ajax.Get('api/combo/departamento/' + vm.entidad.UnidadId).then(function (res) {
                vm.listDepartamentos = res.data;
            }, function (err) {
                var res = (err.data) ? err.data.Message : "Error de Conexion";
                alert(res);
            });
        }, 100);
    }
}