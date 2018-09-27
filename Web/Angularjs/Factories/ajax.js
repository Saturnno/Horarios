angular.module('app').factory('ajax', ['$http', '$q', '$rootScope','$timeout', ajax]);
function ajax($http, $q, $rootScope, $timeout) {
    return {
        Get: Get,
        Post:Post
    }
    function Get(url, data) {
        $rootScope.promises = [];
        var defered = $q.defer();
        var promise = $http.get(url, data);
        function removePromise(p) {
            var index = $rootScope.promises.indexOf(p);
            if (index > -1) {
                $rootScope.promises.splice(p, 1)
            }
        }
        var timeout = $timeout(function () {
            $rootScope.promises.push(promise);
        }, 100);
        promise.then(function (res) {
            $timeout.cancel(timeout);
            removePromise(promise);
            defered.resolve(res);
        }, function (err) {
            $timeout.cancel(timeout);
            removePromise(promise);
            defered.reject(err);
        });
        return defered.promise;
    }
    function Post(url,data) {
        $rootScope.promises = [];
        var defered = $q.defer();
        var promise = $http.post(url, data);
        function removePromise(p) {
            var index = $rootScope.promises.indexOf(p);
            if (index > -1) {
                $rootScope.promises.splice(p, 1)
            }
        }
        var timeout = $timeout(function () {
            $rootScope.promises.push(promise);
        }, 100);
        promise.then(function (res) {
            $timeout.cancel(timeout);
            removePromise(promise);
            defered.resolve(res);
        }, function (err) {
            $timeout.cancel(timeout);
            removePromise(promise);
            defered.reject(err);
        });
        return defered.promise;
    }
}