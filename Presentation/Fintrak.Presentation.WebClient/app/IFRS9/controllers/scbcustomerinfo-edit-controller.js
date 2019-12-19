/**
 * Created by Deb on 8/20/2014.
 */

(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbCustomerInfoEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        ScbCustomerInfoEditController]);

    function ScbCustomerInfoEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'scbcustomerinfo-edit-view';
        vm.viewName = 'ScbCustomerInfo';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.ScbCUSTOMERInfo = {};
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var scbcustomerinfoRules = [];

        var setupRules = function () {

            scbcustomerinfoRules.push(new validator.PropertyRule("Contract_Number ", {
                required: { message: "Contract_Number  is required" }
            }));

            scbcustomerinfoRules.push(new validator.PropertyRule("customer_id ", {
                required: { message: "customer_id  is required" }
            }));

            scbcustomerinfoRules.push(new validator.PropertyRule("Facility_type ", {
                required: { message: "Facility_type  is required" }
            }));

            scbcustomerinfoRules.push(new validator.PropertyRule("Sector ", {
                required: { message: "Sector  is required" }
            }));

            scbcustomerinfoRules.push(new validator.PropertyRule("Sub_sector ", {
                required: { message: "Sub_sector  is required" }
            }));

            scbcustomerinfoRules.push(new validator.PropertyRule("Repayment_Frequency ", {
                required: { message: "Repayment_Frequency  is required" }
            }));

            scbcustomerinfoRules.push(new validator.PropertyRule("Repayment_Frequency_in_words ", {
                required: { message: "Repayment_Frequency_in_words  is required" }
            }));

            scbcustomerinfoRules.push(new validator.PropertyRule("Tin_number ", {
                required: { message: "Tin_number  is required" }
            }));

            scbcustomerinfoRules.push(new validator.PropertyRule("BVN ", {
                required: { message: "BVN  is required" }
            }));

        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intializeLookUp();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/scbcustomerinfo/getscbcustomerinfo/' + $stateParams.ID, null,
                   function (result) {
                       vm.ScbCUSTOMERInfo = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.ScbCUSTOMERInfo = {
                        Contract_Number: '',
                        customer_id: '',
                        Facility_type: '',
                        Sector: '',
                        Sub_sector: '',
                        Repayment_Frequency: '',
                        Repayment_Frequency_in_words: '',
                        Tin_number: '',
                        BVN: ''
                    };
            }
        }

        var intializeLookUp = function () {
           
        }

        var initialView = function () {
            
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.ScbCUSTOMERInfo, scbcustomerinfoRules);
            vm.viewModelHelper.modelIsValid = vm.ScbCUSTOMERInfo.isValid;
            vm.viewModelHelper.modelErrors = vm.ScbCUSTOMERInfo.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/scbcustomerinfo/updatescbcustomerinfo', vm.ScbCUSTOMERInfo,
               function (result) {
                   
                   $state.go('ifrs-scbcustomerinfo-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.ScbCUSTOMERInfo.errors;

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
                vm.viewModelHelper.apiPost('api/scbcustomerinfo/deletescbcustomerinfo', vm.ScbCUSTOMERInfo.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs-scbcustomerinfo-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-scbcustomerinfo-list');
        };

        
        setupRules();
        initialize(); 
    }
}());
