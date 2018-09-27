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
    vm.listTrimestres = [];
    vm.listMaterias = [];
    vm.listMateriasCargadas = [];
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
   
    vm.cambiarMateria = cambiarMateria;

    function cambiarMateria(i) {
        var index = vm.listMaterias.indexOf(i.i);
        if (index > -1) {
            var cont = 0;
            angular.forEach(vm.listMateriasCargadas, function (e) {
                if (e.Id == i.i.Id) {
                    cont++;
                }
            });
            if (cont == 0) {
                vm.listMaterias.splice(index, 1);
                vm.listMateriasCargadas.push(i.i);
            }
        }
    }
    vm.cambiarMateriaCargada = cambiarMateriaCargada;
    function cambiarMateriaCargada(i) {
        var index = vm.listMateriasCargadas.indexOf(i.i);
        if (index > -1) {
            var cont = 0;
            angular.forEach(vm.listMaterias, function (e) {
                if (e.Id == i.i.Id) {
                    cont++;
                }
            });
            if (cont == 0) {
                vm.listMateriasCargadas.splice(index, 1);
                vm.listMaterias.push(i.i);
            }
        }
    }
    vm.guardar = guardar;
    function guardar() {
        ajax.Post(getControllerName() + '/Guardar', { materias: vm.listMateriasCargadas, trimestre: vm.entidad.TrimestreId,programa:vm.entidad.ProgramaEducativoId }).then(function (res) {
            vm.entidad = {};
            vm.listMaterias = [];
            vm.listMateriasCargadas = [];
            alert("Se Guardo Correctamente");
            $location.path('massList');
        }, function (err) {
            var res = (err.data) ? err.data.Message : "Error de Conexion";
            alert(res);
            vm.entidad = {};
            vm.listMaterias = [];
            vm.listMateriasCargadas = [];
        });
    }
    vm.changeTrimestre = changeTrimestre;
    function changeTrimestre() {
        ajax.Get('api/combo/materiaprogramaeducativo/?id='+vm.entidad.ProgramaEducativoId+'&trimestre='+vm.entidad.TrimestreId).then(function (res) {
            vm.listMateriasCargadas = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
        ajax.Get('api/combo/materia').then(function (res) {
            vm.listMaterias = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
    }
}