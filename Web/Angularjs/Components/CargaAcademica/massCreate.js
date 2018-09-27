angular.module('app').component('massCreate', {
    templateUrl: '/' + getControllerName() + '/Create',
    controller: massCreateController,
    controllerAs: 'vm'
});
function massCreateController($scope, $location, ajax) {
    createController.call(this, $scope, $location, ajax);
    var vm = this;
    vm.$onInit = inicio;
    vm.listUnidades = [];
    vm.listDepartamentos = [];
    vm.listProgramasEducativos = [];

}