angular.module('app').component('massList', {
    templateUrl: '/' + getControllerName() + '/MassList',
    controller: massListController,
    controllerAs:'vm'
});
function massListController($scope, $location, ajax) {
    listController.call(this, $scope, $location, ajax);
    var vm = this;
    vm.listDias = [];
    vm.listUnidades = [];
    vm.listDepartamentos = [];
    vm.listProgramasEducativos = [];
    vm.listGruposDisponibilidad = [];
    vm.listGrupos = [];
    vm.entidad = {};
    vm.$onInit = inicio;
    vm.listTrimestres = [];
    function inicio() {
        ajax.Get('api/combo/unidad').then(function (res) {
            vm.listUnidades = res.data;
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
        ajax.Get('api/combo/departamento/'+vm.entidad.UnidadId).then(function (res) {
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
        
    }
    vm.changeDias = changeDias;
    function changeDias() {
        ajax.Get(getControllerName() + '/listgrupodisponibilidad/?grupo=' + vm.entidad.GrupoId + '&dia=' + vm.entidad.Dia+'&trimestre='+vm.entidad.TrimestreId).then(function (res) {
            vm.listGruposDisponibilidad = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
    }
    vm.changeTrimestre = changeTrimestre;
    function changeTrimestre() {
        ajax.Get(getControllerName()+'/Grupos/?id='+vm.entidad.ProgramaEducativoId+'&trimestre='+vm.entidad.TrimestreId).then(function (res) {
            vm.listGrupos = res.data;
        }, function (err) {
            var res = (err.data) ? err.data.Message : 'Error de Conexion : Combruebe su Internet';
            alert(res);
        });
    }
}
angular.module('app').filter('filterDias', Dias);
function Dias() {
    var dias = [{
        id:1,Dia:"Lunes"
    }, {
        id: 2, Dia: "Martes"
    }, {
        id: 3, Dia: "Miercoles"
    }, {
        id: 4, Dia: "Jueves"
    }, {
        id: 5, Dia: "Viernes"
    }, {
        id: 6, Dia: "Sabado"
    }]
    return function (item) {
        var res="No se encontro dia";
        dias.map(function (e) {
            if (e.id == item)
                res = e.Dia;
        });
        return res;
    }
}