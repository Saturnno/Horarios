angular.module('app', ['ngRoute', 'ngAnimate','ui.bootstrap']).controller('layoutController', ['$scope', layoutController]);
function layoutController($scope) {
    var vm = this;
    vm.isCollapsed = false;
}
document.addEventListener('DOMContentLoaded', load);
function load() {
    angular.bootstrap(document, ['app']);
}