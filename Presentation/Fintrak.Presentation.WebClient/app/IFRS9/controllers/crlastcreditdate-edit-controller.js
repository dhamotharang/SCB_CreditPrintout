/**
 * Created by Deb on 8/20/2014.
 */

(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("CRLastCreditDateEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        CRLastCreditDateEditController]);

    function CRLastCreditDateEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'crlastcreditdate-edit-view';
        vm.viewName = 'CRLastCreditDate';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.crLASTcreDITDATE = {};
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var crlastcreditdateRules = [];

        var setupRules = function () {

            crlastcreditdateRules.push(new validator.PropertyRule("LAST_CREDIT_DATE ", {
                required: { message: "LAST_CREDIT_DATE  is required" }
            }));

            crlastcreditdateRules.push(new validator.PropertyRule("facility_type ", {
                required: { message: "facility_type  is required" }
            }));

            crlastcreditdateRules.push(new validator.PropertyRule("Customer_Id ", {
                required: { message: "Customer_Id  is required" }
            }));

            crlastcreditdateRules.push(new validator.PropertyRule("sector ", {
                required: { message: "sector  is required" }
            }));

            crlastcreditdateRules.push(new validator.PropertyRule("subsector ", {
                required: { message: "subsector  is required" }
            }));

        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intializeLookUp();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/crlastcreditdate/getcrlastcreditdate/' + $stateParams.ID, null,
                   function (result) {
                       vm.crLASTcreDITDATE = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.crLASTcreDITDATE = {
                        LAST_CREDIT_DATE: '',
                        facility_type: '',
                        Customer_Id: '',
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
            validator.ValidateModel(vm.crLASTcreDITDATE, crlastcreditdateRules);
            vm.viewModelHelper.modelIsValid = vm.crLASTcreDITDATE.isValid;
            vm.viewModelHelper.modelErrors = vm.crLASTcreDITDATE.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/crlastcreditdate/updatecrlastcreditdate', vm.crLASTcreDITDATE,
               function (result) {
                   
                   $state.go('ifrs-crlastcreditdate-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.crLASTcreDITDATE.errors;

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
                vm.viewModelHelper.apiPost('api/crlastcreditdate/deletecrlastcreditdate', vm.crLASTcreDITDATE.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs-crlastcreditdate-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-crlastcreditdate-list');
        };

        
        setupRules();
        initialize(); 
    }
}());
