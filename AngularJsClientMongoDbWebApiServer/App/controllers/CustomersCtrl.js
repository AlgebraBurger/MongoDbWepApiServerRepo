angular.module("app")    
    .constant("baseurl", "http://localhost:54445/api/customers/")
    .controller("CustomersCtrl", function ($scope, $http, baseurl) {
    $scope.customers = [];
    

    var loadCustomers = function () {
        $http.get(baseurl).success(function (data, status, headers, config) {
            $scope.customers = data;            
        }).error(function (data, status, headers, config) { });
    }
    loadCustomers();

    $scope.deleteCustomer = function (customer) {

        var id = customer._id;
        $http.delete(baseurl + id).success(function (data) {

            $.each($scope.customers, function (i) {
                if ($scope.customers[i]._id === customer._id) {
                    $scope.customers.splice(i, 1);
                    return false;
                }
            });

        }).error(function (data) {

        });
    }

    $scope.CreateCustomer = function (customer) {
        $http.post(baseurl, customer).success(function (data) {
            loadCustomers();
            $('#CustomerModal').modal('toggle');
            $scope.customer = [];
        }).error(function (error) {
         
        }).finally(function () {

        });
    }

    $scope.editCustomer = function (customer) {
        $scope.data = [];
        $('#EditCustomerModal').modal('toggle');
        $scope.data.customer = customer;
        
        
    }

    $scope.UpdateCustomer = function (customer) {
        
        var id = customer._id;
        $http.put(baseurl + id, customer).success(function (data) {
            loadCustomers();
            $('#EditCustomerModal').modal('toggle');
            $scope.customer = [];

        }).error(function (data) {

        });
    }

    
});