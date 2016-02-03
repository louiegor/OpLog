var myApp = angular.module('myApp', ['ngTable']);

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
http://plnkr.co/edit/TUOYmM?p=preview
*/
myApp.controller('TableCtrl', function ($scope, $http, $filter, ngTableParams, NameService) {

    var data = NameService.data;

    $scope.tableParams = new ngTableParams(
      {
          page: 1,            // show first page
          count: 10,           // count per page
          sorting: {name:'asc'}
      },
      {
          //total: 0, // length of data
          getData: function($defer, params) {
              NameService.getData($defer,params,$scope.filter);
          }
      });

    $scope.$watch("filter.$", function() {
        $scope.tableParams.reload();
    });
});


myApp.service("NameService", function ($http, $filter) {

    function filterData(data, filter) {
        return $filter('filter')(data, filter);
    }

    function orderData(data, params) {
        return params.sorting() ? $filter('orderBy')(data, params.orderBy()) : filteredData;
    }

    function sliceData(data, params) {
        return data.slice((params.page() - 1) * params.count(), params.page() * params.count());
    }

    function transformData(data, filter, params) {
        return sliceData(orderData(filterData(data, filter), params), params);
    }

    var service = {
        cachedData: [],
        getData: function ($defer, params, filter) {
            if (service.cachedData.length > 0) {
                console.log("using cached data");
                var filteredData = filterData(service.cachedData, filter);
                var transformedData = sliceData(orderData(filteredData, params), params);
                params.total(filteredData.length);
                $defer.resolve(transformedData);
            }
            else {

                console.log("fetching data");
                $http.get("/home/GetAllChar").success(function (resp) {
                    angular.copy(resp.data, service.cachedData);
                    params.total(resp.data.length);
                    var filteredData = $filter('filter')(resp.data, filter);
                    var transformedData = transformData(resp.data, filter, params);

                    $defer.resolve(transformedData);
                });
            }

        }
    };
    return service;
});