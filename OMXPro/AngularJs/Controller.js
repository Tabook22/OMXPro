/// <reference path="angular.js" />
/// <reference path="Module.js" />
app.controller('menuController', ['$scope', '$http', function ($scope, $http) {
    $scope.SiteMenu = [];
    $http.get('/home/GetSiteMenu').then(function (data) {
        $scope.SiteMenu = data.data;
    }, function (error) {
        alert('Error');
    })
}])
//var app = angular.module('MyApp', []);
//app.controller('menuController', ['$scope', '$http', function ($scope, $http) {
//    $scope.SiteMenu = [];
//    $http.get('/home/GetSiteMenu').then(function (data) {
//        $scope.SiteMenu = data.data;
//    }, function (error) {
//        alert('Error');
//    })
//}])