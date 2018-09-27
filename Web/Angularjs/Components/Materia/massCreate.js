angular.module('app').component('massCreate', {
    templateUrl: '/' + getControllerName() + '/Create',
    controller: massEditController,
    controllerAs:'vm'
});
function massEditController($scope, $location, ajax) {
    createController.call(this, $scope, $location, ajax);
    var vm = this;
    vm.listCategorias = [];
    vm.$onInit = inicio;
    function inicio() {
        ajax.Get('api/combo/categoria').then(function (res) {
            vm.listCategorias = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion :Compruebe su internet";
            alert(res);
        });
    }
}