/**
 * Created by Deb on 8/20/2014.
 */

(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbCreditSanctionEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        ScbCreditSanctionEditController]);

    function ScbCreditSanctionEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'scbcreditsanction-edit-view';
        vm.viewName = 'Edit Scb Credit Sanction Data';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.scbCREDITsanction = {};
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var scbcreditsanctionRules = [];

        var setupRules = function () {

            scbcreditsanctionRules.push(new validator.PropertyRule("Contract_number ", {
                required: { message: "Contract_number  is required" }
            }));

            scbcreditsanctionRules.push(new validator.PropertyRule("SANCTION_LIMIT ", {
                required: { message: "SANCTION_LIMIT  is required" }
            }));

            scbcreditsanctionRules.push(new validator.PropertyRule("PREVIOUS_LIMIT ", {
                required: { message: "PREVIOUS_LIMIT  is required" }
            }));

            scbcreditsanctionRules.push(new validator.PropertyRule("Customer_Id ", {
                required: { message: "Customer_Id  is required" }
            }));

            scbcreditsanctionRules.push(new validator.PropertyRule("facility_type ", {
                required: { message: "facility_type  is required" }
            }));

            scbcreditsanctionRules.push(new validator.PropertyRule("sector ", {
                required: { message: "sector  is required" }
            }));

            scbcreditsanctionRules.push(new validator.PropertyRule("subsector ", {
                required: { message: "subsector  is required" }
            }));

        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intializeLookUp();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/scbcreditsanction/getscbcreditsanction/' + $stateParams.ID, null,
                   function (result) {
                       vm.scbCREDITsanction = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.scbCREDITsanction = {
                        Contract_number: '',
                        SANCTION_LIMIT: '',
                        PREVIOUS_LIMIT: '',
                        Customer_Id: '',
                        facility_type: '',
                        sector: '',
                        subsector: ''
                    };
            }
        }

        var intializeLookUp = function () {
           
        }

        var initialView = function () {
            
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.scbCREDITsanction, scbcreditsanctionRules);
            vm.viewModelHelper.modelIsValid = vm.scbCREDITsanction.isValid;
            vm.viewModelHelper.modelErrors = vm.scbCREDITsanction.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/scbcreditsanction/updatescbcreditsanction', vm.scbCREDITsanction,
               function (result) {
                   
                   $state.go('ifrs-scbcreditsanction-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.scbCREDITsanction.errors;

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
                vm.viewModelHelper.apiPost('api/scbcreditsanction/deletescbcreditsanction', vm.scbCREDITsanction.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs-scbcreditsanction-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-scbcreditsanction-list');
        };

        
        setupRules();
        initialize(); 
    }
}());
