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

myApp.controller('TableCtrl', function ($scope, ngTableParams) {
    $scope.data = [
     { name: "Louiegor", age: 50 },
     { name: "Tiancum", age: 43 },
     { name: "Jacob", age: 27 },
     { name: "Nephi", age: 29 },
     { name: "Enos", age: 34 },
     { name: "Tiancum", age: 43 },
     { name: "Jacob", age: 27 },
     { name: "Nephi", age: 29 },
     { name: "Enos", age: 34 },
     { name: "Tiancum", age: 43 },
     { name: "Jacob", age: 27 },
     { name: "Nephi", age: 29 },
     { name: "Enos", age: 34 },
     { name: "Tiancum", age: 43 },
     { name: "Jacob", age: 27 },
     { name: "Nephi", age: 29 },
     { name: "Enos", age: 34 }
    ];

    $scope.tableParams = new ngTableParams({
        page: 1,            // show first page
        count: 10           // count per page
    }, {
        total: $scope.data.length, // length of data
        getData: function ($defer, params) {
            $defer.resolve($scope.data.slice((params.page() - 1) * params.count(), params.page() * params.count()));
        }
    });
});
