/**
 * Created by Deb on 8/20/2014.
 */

(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbProductEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        ScbProductEditController]);

    function ScbProductEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'scbproduct-edit-view';
        vm.viewName = 'ScbProduct';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.scbPROduct = {};
        
        vm.init = false;

        vm.showInstruction = false;
        vm.instruction = '';

        var scbproductRules = [];

        var setupRules = function () {
            
            scbproductRules.push(new validator.PropertyRule("PsfAccNum", {
                required: { message: "PsfAccNum  is required" }
            }));

            scbproductRules.push(new validator.PropertyRule("Description", {
                required: { message: "Description  is required" }
            }));

            scbproductRules.push(new validator.PropertyRule("ProductCode", {
                required: { message: "ProductCode  is required" }
            }));

            scbproductRules.push(new validator.PropertyRule("ProductcodeDescription", {
                required: { message: "ProductcodeDescription  is required" }
            }));

        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intializeLookUp();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/scbproduct/getscbproduct/' + $stateParams.ID, null,
                   function (result) {
                       vm.scbPROduct = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.scbPROduct = { 
                        PsfAccNum: '',
                        Description: '',
                        ProductCode: '',
                        ProductcodeDescription: ''
                    };
            }
        }

        var intializeLookUp = function () {
           
        }

        var initialView = function () {
            
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.scbPROduct, scbproductRules);
            vm.viewModelHelper.modelIsValid = vm.scbPROduct.isValid;
            vm.viewModelHelper.modelErrors = vm.scbPROduct.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/scbproduct/updatescbproduct', vm.scbPROduct,
               function (result) {
                   
                   $state.go('ifrs-scbproduct-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.scbPROduct.errors;
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
                vm.viewModelHelper.apiPost('api/scbproduct/deletescbproduct', vm.scbPROduct.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs-scbproduct-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-scbproduct-list');
        };

        
        setupRules();
        initialize(); 


    }
}());
