var myApp = angular.module('myApp', ['ngTable', 'ngResource']);

myApp.controller('OrganizationCtrl', function ($scope, $http) {
    $scope.orgName = "";
    $scope.listAllOrg = [];
    $scope.list_category = "";
    var path = "/home/GetAllOrg";
    $http.get(path).then(function (response) {
        $scope.listAllOrg = response;
    }, function (response) {
    });

    $scope.orgId = "";
    $scope.charaName = "";
    $scope.addChara = function () {
        $http.post("/home/AddCharacter", { orgId: $scope.orgId, charaName: $scope.charaName }).then(function (response) {

        }, function (response) { });
    };

    $scope.addOrg = function () {
        $http.post("/home/AddOrganization", { orgName: $scope.orgName }).then(function (response) {

        }, function (response) { });
    };
});
/*
http://stackoverflow.com/questions/21805734/loading-json-via-ajax-with-ngtable-parameters
*/
myApp.controller('TableCtrl', function ($scope,$http, $filter, ngTableParams) {
    
    //var api = $resource("/home/GetAllChar");
    //$http.get('/home/GetAllChar').success(function(data, status) {
    //    $scope.data = data;
    //});

    var path = '/home/GetAllChar';
    $http.get(path).success(function (data,status) {
        $scope.data = data.data;
    //}, function (response) {
    
        $scope.tableParams = new ngTableParams({
                page: 1,            // show first page
                count: 10,          // count per page
                //sorting: {
                //    name: 'asc'     // initial sorting
                //}
            }, {
                total: $scope.data.length, // length of data
                getData: function($defer, params) {
                    // use build-in angular filter
                    //var orderedData = params.sorting() ?
                    //    $filter('orderBy')($scope.data.data, params.orderBy()) :
                    //    $scope.data.data;
                    var orderedData = $scope.data.data;
                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });
    });
});
    //$scope.tableParams = new ngTableParams({
    //    //paginationMaxBlocks: 13,
    //    //paginationMinBlocks: 2,
    //    page: 1,
    //    count: 10
    //}, {
    //    //total: $scope.data.length, // length of data
    //    getData: function (params) {
    //        return api.get(params.url()).$promise.then(function(data) {
    //            params.total(data.data.length); // recal. page nav controls
    //            return data.data;
    //        });
    //    }
        
    //});
    
    //this.customConfigParams = createUsingFullOptions();

    //function createUsingFullOptions() {
    //    var initialParams = {
    //        count: 5 // initial page size
    //    };
    //    var initialSettings = {
    //        // page size buttons (right set of buttons in demo)
    //        counts: [],
    //        // determines the pager buttons (left set of buttons in demo)
    //        paginationMaxBlocks: 13,
    //        paginationMinBlocks: 2,
    //        dataset: simpleList
    //    };
    //    return new NgTableParams(initialParams, initialSettings);


