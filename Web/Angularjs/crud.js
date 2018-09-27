
angular.module('app').config(['$routeProvider', config]);
function config($routeProvider) {
    $routeProvider.when('/', {
        template: '<list></list>'
    }).when('/create', {
        template:'<create></create>'
    }).when('/massCreate', {
        template:'<mass-create></mass-create'
    }).when('/edit/:id', {
        template: '<edit></edit>'
    }).when('/massEdit/:id', {
        template:'<mass-edit></mass-edit>'
    }).otherwise({
        redirectTo: '/'
    });
}
angular.module('app').component('list', {
    templateUrl: '/' + getControllerName() + '/List',
    controller: listController,
    controllerAs: 'vm'
});
function listController($scope, $location, ajax) {
    var vm = this;
    vm.items = [];
    vm.totalItems = 0;
    vm.itemsPerPage = 13;
    vm.currentPage = 1;
    vm.pageChanged = pageChanged;
    vm.$onInit = inicio;
    function inicio() {
        ajax.Get(getControllerName() + '/GetList/?page='+vm.currentPage).then(function (res) {
            vm.items = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion : Compruebe Su conexion de Internet";
            alert(res);
        });

        ajax.Get(getControllerName() + '/GetRows').then(function (res) {
            vm.totalItems = res.data;
            console.log(res.data);
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion : Compruebe Su conexion de Internet";
            alert(res);
        });
    }
    function pageChanged() {
        ajax.Get(getControllerName() + '/GetList/?page='+vm.currentPage).then(function (res) {
            vm.items = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion : Compruebe Su conexion de Internet";
            alert(res);
        });
    }
    vm.create = create;
    vm.edit = edit;
    vm.massEdit = massEdit;
    vm.massCreate = massCreate;
    function edit(id) {
        $location.path('edit/' + id);
    }
    function create() {
        $location.path('create');
    }
    function massEdit(id) {
        $location.path('massEdit/'+id);
    }
    function massCreate(){
        $location.path('massCreate');
    }
}
angular.module('app').component('create', {
    templateUrl: '/' + getControllerName() + '/Create',
    controller: createController,
    controllerAs:'vm'
});
function createController($scope, $location, ajax) {
    var vm = this;
    vm.entidad = {};
    vm.guardar = guardar;
    function guardar() {
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
    vm.list = list;
    function list() {
        $location.path('/');
    }
}
angular.module('app').component('edit', {
    templateUrl: '/' + getControllerName() + '/Edit',
    controller: editController,
    controllerAs:'vm'
});
function editController($scope, $location, ajax,$routeParams) {
    var vm = this;
    vm.entidad = {};
    vm.$onInit = inicio;
    function inicio() {
        ajax.Get(getControllerName() + '/GetEditEntidad/'+$routeParams.id).then(function (res) {
            vm.entidad = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error :Compruebe Su Internet";
            alert(res);
        });
    }
    vm.list = list;
    vm.guardar = guardar;
    function guardar() {
        ajax.Post(getControllerName() + '/Edit', vm.entidad).then(function (res) {
            vm.entidad = {};
            alert("Se Guardo Correctamente");
            list();
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion";
            alert(res);
        });
    }
    function list() {
        $location.path('/');
    }
}
function getControllerName() {
    return window.location.pathname.split('/')[1];
}
angular.module('app').directive('numbersOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^0-9,.]/g, '');

                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                return text;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});
angular.module('app').directive('capitalize', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, modelCtrl) {
            var capitalize = function (inputValue) {
                if (inputValue == undefined) inputValue = '';
                var capitalized = inputValue.toUpperCase();
                if (capitalized !== inputValue) {
                    modelCtrl.$setViewValue(capitalized);
                    modelCtrl.$render();
                }
                return capitalized;
            }
            modelCtrl.$parsers.push(capitalize);
            capitalize(scope[attrs.ngModel]); // capitalize initial value
        }
    };
});
angular.module('app').component('combo', {
    bindings: {
        model: '=',
        combo: '@?',
        parent: '=?',
    },
    controller: comboController,
    controllerAs: 'vm',
    template: '<select class="form-control" ng-model="vm.object" ng-options="i.Nombre for i in vm.items" ng-change="vm.select()"></select>'
});
function comboController($scope, ajax, $element) {
    var vm = this;
    vm.items = [];
    vm.$onInit = function () {
        //angular.element($element).bind('click', vm.click);
        console.log(vm.parent);
        if (vm.parent == undefined && vm.combo == "unidad") {
            vm.click();
        }
    }
    vm.click = click;
    function click() {
        ajax.Get('api/combo/' + vm.combo).then(function (res) {
            vm.items = res.data;
        }, function (err) {
            console.log(err);
            angular.element($element).append('<select class="form-control"><option>${err.data.Message}</option></select>');
        });
    }
    vm.select = select;
    function select() {
        if (vm.object) {
            vm.model = vm.object.Id;
        }
    }
    $scope.$watch('vm.parent', function (n, v) {
        if (n != v) {
            ajax.Get('api/combo/' + vm.combo + '/' + vm.parent).then(function (res) {
                vm.items = res.data;
            }, function (err) {
                console.log(err);
                angular.element($element).html('<select class="form-control"><option>' + err.data.Message + '</option></select>');
            });
        }
    });
}
angular.module('app').directive('lengthMax', function () {
    return {
        require:"ngModel",
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {

                    var len = text.length;

                    if (len <= attr.lengthMax) {
                        ngModelCtrl.$setViewValue(text);
                        ngModelCtrl.$render();
                    }
                    else {
                        var type = typeof text;
                        text = text.toString().substr(0, attr.lengthMax);

                        if (type == "number") text = parseFloat(text);
                        ngModelCtrl.$setViewValue(text);
                        ngModelCtrl.$render();
                    }
                    return text;
                }
                return text;
            }
            ngModelCtrl.$parsers.push(fromUser);


        }
    };
});