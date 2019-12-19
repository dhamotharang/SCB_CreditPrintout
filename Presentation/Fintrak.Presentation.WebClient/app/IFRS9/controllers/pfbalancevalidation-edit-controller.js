/**
 * Created by Deb on 8/20/2014.
 */

(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("PfBalanceValidationEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        PfBalanceValidationEditController]);

    function PfBalanceValidationEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'pfbalancevalidation-edit-view';
        vm.viewName = 'PfBalanceValidation';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.pfBALANCEValidation = {};
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var pfbalancevalidationRules = [];

        var setupRules = function () {

            pfbalancevalidationRules.push(new validator.PropertyRule("Productcode", {
                required: { message: "Productcode  is required" }
            }));

            pfbalancevalidationRules.push(new validator.PropertyRule("Glcode", {
                required: { message: "Glcode  is required" }
            }));

            pfbalancevalidationRules.push(new validator.PropertyRule("GL_Balance", {
                required: { message: "GL_Balance  is required" }
            }));

            pfbalancevalidationRules.push(new validator.PropertyRule("Loan_balance", {
                required: { message: "Loan_balance  is required" }
            }));

            pfbalancevalidationRules.push(new validator.PropertyRule("Differences", {
                required: { message: "_Differences  is required" }
            }));

        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intializeLookUp();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/pfbalancevalidation/getpfbalancevalidation/' + $stateParams.ID, null,
                   function (result) {
                       vm.pfBALANCEValidation = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.pfBALANCEValidation = {
                        Productcode: '',
                        Glcode: '',
                        GL_Balance: '',
                        Loan_balance: '',
                        Differences: ''
                    };
            }
        }

        var intializeLookUp = function () {
           
        }

        var initialView = function () {
            
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.pfBALANCEValidation, pfbalancevalidationRules);
            vm.viewModelHelper.modelIsValid = vm.pfBALANCEValidation.isValid;
            vm.viewModelHelper.modelErrors = vm.pfBALANCEValidation.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/pfbalancevalidation/updatepfbalancevalidation', vm.pfBALANCEValidation,
               function (result) {
                   
                   $state.go('ifrs-pfbalancevalidation-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.pfBALANCEValidation.errors;

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
                vm.viewModelHelper.apiPost('api/pfbalancevalidation/deletepfbalancevalidation', vm.pfBALANCEValidation.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs-pfbalancevalidation-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-pfbalancevalidation-list');
        };

        
        setupRules();
        initialize(); 
    }
}());
