/**
 * Created by Deb on 8/20/2014.
 */

(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbGLBalanceEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        ScbGLBalanceEditController]);

    function ScbGLBalanceEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'scbglbalance-edit-view';
        vm.viewName = 'ScbGLBalance';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.SCBGLBALance = {};
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var scbglbalanceRules = [];

        var setupRules = function () {

            scbglbalanceRules.push(new validator.PropertyRule("Glcode", {
                required: { message: "Glcode  is required" }
            }));

            scbglbalanceRules.push(new validator.PropertyRule("glcode_description", {
                required: { message: "glcode_description  is required" }
            }));

            scbglbalanceRules.push(new validator.PropertyRule("ProductCode", {
                required: { message: "ProductCode  is required" }
            }));

            scbglbalanceRules.push(new validator.PropertyRule("Product_description", {
                required: { message: "Product_description  is required" }
            }));

            scbglbalanceRules.push(new validator.PropertyRule("Amount", {
                required: { message: "Amount  is required" }
            }));

            scbglbalanceRules.push(new validator.PropertyRule("ReportDate", {
                required: { message: "ReportDate  is required" }
            }));

        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intializeLookUp();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/scbglbalance/getscbglbalance/' + $stateParams.ID, null,
                   function (result) {
                       vm.SCBGLBALance = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.SCBGLBALance = {
                        Glcode: '',
                        glcode_description: '',
                        ProductCode: '',
                        Product_description: '',
                        Amount: '',
                        ReportDate: ''
                    };
            }
        }

        var intializeLookUp = function () {
           
        }

        var initialView = function () {
            
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.SCBGLBALance, scbglbalanceRules);
            vm.viewModelHelper.modelIsValid = vm.SCBGLBALance.isValid;
            vm.viewModelHelper.modelErrors = vm.SCBGLBALance.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/scbglbalance/updatescbglbalance', vm.SCBGLBALance,
               function (result) {
                   
                   $state.go('ifrs-scbglbalance-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.SCBGLBALance.errors;

                var errorList = '';

                angular.forEach(vm.viewModelHelper.modelErrors, function (error) {
                    errorList += error + '<br>';
                });
                toastr.error(errorList, 'Fintrak');
            }
                
        }

        vm.delete = function () {
            var deleteFlag = $window.confirm(' Are you sure you want to delete' );

            if (deleteFlag) {
                vm.viewModelHelper.apiPost('api/scbglbalance/deletescbglbalance', vm.SCBGLBALance.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs-scbglbalance-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-scbglbalance-list');
        };

        
        setupRules();
        initialize(); 
    }
}());
