/**
 * Created by Deb on 8/20/2014.
 */

(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("CreditCollateralMgtEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        CreditCollateralMgtEditController]);

    function CreditCollateralMgtEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'creditcollateralmgt-edit-view';
        vm.viewName = 'CreditCollateralMgt';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.creditCOLLATERALmgt = {};
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var creditcollateralmgtRules = [];

        var setupRules = function () {

            creditcollateralmgtRules.push(new validator.PropertyRule("DETAILS_OF_SECURITIES_OTHERS ", {
                required: { message: "DETAILS_OF_SECURITIES_OTHERS  is required" }
            }));

            creditcollateralmgtRules.push(new validator.PropertyRule("COLLATERAL_VALUE ", {
                required: { message: "COLLATERAL_VALUE  is required" }
            }));

            creditcollateralmgtRules.push(new validator.PropertyRule("COLLATERAL_STATUS	 ", {
                required: { message: "COLLATERAL_STATUS	  is required" }
            }));

            creditcollateralmgtRules.push(new validator.PropertyRule("BANK_CLASSIFICATION ", {
                required: { message: "BANK_CLASSIFICATION  is required" }
            }));

            creditcollateralmgtRules.push(new validator.PropertyRule("LAST_EXAMINERS_CLASSIFICATION ", {
                required: { message: "LAST_EXAMINERS_CLASSIFICATION  is required" }
            }));

            creditcollateralmgtRules.push(new validator.PropertyRule("SCI_ID ", {
                required: { message: "SCI_ID  is required" }
            }));


        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intializeLookUp();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/creditcollateralmgt/getcreditcollateralmgt/' + $stateParams.ID, null,
                   function (result) {
                       vm.creditCOLLATERALmgt = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.creditCOLLATERALmgt = {
                        DETAILS_OF_SECURITIES_OTHERS: '',
                        COLLATERAL_VALUE: '',
                        COLLATERAL_STATUS: '',
                        BANK_CLASSIFICATION: '',
                        LAST_EXAMINERS_CLASSIFICATION: '',
                        SCI_ID: ''
                    };
            }
        }

        var intializeLookUp = function () {
           
        }

        var initialView = function () {
            
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.creditCOLLATERALmgt, creditcollateralmgtRules);
            vm.viewModelHelper.modelIsValid = vm.creditCOLLATERALmgt.isValid;
            vm.viewModelHelper.modelErrors = vm.creditCOLLATERALmgt.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/creditcollateralmgt/updatecreditcollateralmgt', vm.creditCOLLATERALmgt,
               function (result) {
                   
                   $state.go('ifrs-creditcollateralmgt-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.creditCOLLATERALmgt.errors;

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
                vm.viewModelHelper.apiPost('api/creditcollateralmgt/deletecreditcollateralmgt', vm.creditCOLLATERALmgt.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs9-creditcollateralmgt-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-creditcollateralmgt-list');
        };

        
        setupRules();
        initialize(); 
    }
}());
