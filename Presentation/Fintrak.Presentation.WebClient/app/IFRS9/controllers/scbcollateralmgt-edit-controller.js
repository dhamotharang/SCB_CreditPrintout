/**
 * Created by Deb on 8/20/2014.
 */

(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbCollateralMgtEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        ScbCollateralMgtEditController]);

    function ScbCollateralMgtEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'scbcollateralmgt-edit-view';
        vm.viewName = 'SCB Collateral Management Edit Page';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.scbCOLLATERALmgt = {};
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var scbcollateralmgtRules = [];

        var setupRules = function () {

            scbcollateralmgtRules.push(new validator.PropertyRule("SCID", {
                required: { message: "SCID  is required" }
            }));

            scbcollateralmgtRules.push(new validator.PropertyRule("Customer_ID", {
                required: { message: "Customer_ID  is required" }
            }));

            scbcollateralmgtRules.push(new validator.PropertyRule("contract_no", {
                required: { message: "contract_no  is required" }
            }));

            scbcollateralmgtRules.push(new validator.PropertyRule("total_obligor_collateral_value", {
                required: { message: "total_obligor_collateral_value  is required" }
            }));

            scbcollateralmgtRules.push(new validator.PropertyRule("facility_coverage_value", {
                required: { message: "facility_coverage_value  is required" }
            }));


        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intializeLookUp();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/scbcollateralmgt/getscbcollateralmgt/' + $stateParams.ID, null,
                   function (result) {
                       vm.scbCOLLATERALmgt = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.scbCOLLATERALmgt = {
                        SCID: '',
                        Customer_ID: '',
                        contract_no: '',
                        total_obligor_collateral_value: '',
                        facility_coverage_value: ''
                    };
            }
        }

        var intializeLookUp = function () {
           
        }

        var initialView = function () {
            
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.scbCOLLATERALmgt, scbcollateralmgtRules);
            vm.viewModelHelper.modelIsValid = vm.scbCOLLATERALmgt.isValid;
            vm.viewModelHelper.modelErrors = vm.scbCOLLATERALmgt.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/scbcollateralmgt/updatescbcollateralmgt', vm.scbCOLLATERALmgt,
               function (result) {
                   
                   $state.go('ifrs-scbcollateralmgt-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.scbCOLLATERALmgt.errors;

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
                vm.viewModelHelper.apiPost('api/scbcollateralmgt/deletescbcollateralmgt', vm.scbCOLLATERALmgt.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs-scbcollateralmgt-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-scbcollateralmgt-list');
        };

        
        setupRules();
        initialize(); 
    }
}());
