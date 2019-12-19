/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbBankClassificationEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        ScbBankClassificationEditController]);

    function ScbBankClassificationEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'scbbankclassification-edit-view';
        vm.viewName = 'ScbBankClassification';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.allSectors = [];

        var scbbankclassificationRules = [];

        var setupRules = function () {

            scbbankclassificationRules.push(new validator.PropertyRule("contract_no", {
                required: { message: "contract_no  is required" }
            }));

            scbbankclassificationRules.push(new validator.PropertyRule("facility_type", {
                required: { message: "facility_type  is required" }
            }));

            scbbankclassificationRules.push(new validator.PropertyRule("sector", {
                required: { message: "sector  is required" }
            }));

            scbbankclassificationRules.push(new validator.PropertyRule("prev_bank_classification", {
                required: { message: "prev_bank_classification  is required" }
            }));

            scbbankclassificationRules.push(new validator.PropertyRule("curr_bank_classification", {
                required: { message: "curr_bank_classification  is required" }
            }));

        }

        //initialize Dropdowns.... 
        vm.prvClassObj = vm.curClassObj = vm.sectorObj = '';

        vm.classificationObj = [
            { Id: 1, name: 'Performing', title: 'Performing' },
            { Id: 2, name: 'Non-Performing', title: 'Non-Performing' }
        ];

        vm.scbBANKclassification = {};
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        vm.getSubClassOptions = function (obj) {
            if (obj == 'prev_bank') {
                vm.scbBANKclassification.prev_bank_classification = vm.prvClassObj.name;
            } else {
                vm.scbBANKclassification.curr_bank_classification = vm.curClassObj.name;
            }
        };

        //for the sector menu dropdown... 
        vm.loadSectors = function () {
            vm.viewModelHelper.apiGet('api/sector/getsectorsbysource/cbn', null,
                function (result) {
                    
                    var all = result.data;          // vm.scbDATAinfos = result.data;
                    vm.allSectors = [];             //clear the array....

                    for (var i = 0; i < all.length; i++) {
                        vm.allSectors.push({ 'Id': i, 'name': all[i].Description, 'title': all[i].Description });
                    }
                    console.log(vm.subs);
                    vm.spinner = false;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                    vm.spinner = false;
                }, null);

        };

        vm.chgSector = function () {
            vm.scbBANKclassification.sector = vm.sectorObj.name;
        }

        var initialize = function () {
            if (vm.init === false) {

                //load lookups
                intializeLookUp();

                //load available sectors....
                vm.loadSectors();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/scbbankclassification/getscbbankclassification/' + $stateParams.ID, null,
                   function (result) {
                       vm.scbBANKclassification = result.data;
                       initialView();
                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
                }
                else
                    vm.scbBANKclassification = {
                        contract_no: '',
                        facility_type: '',
                        sector: '',
                        prev_bank_classification: '',
                        curr_bank_classification: ''
                    };
            }
        }

        var intializeLookUp = function () {
           
        }

        var initialView = function () {
            
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.scbBANKclassification, scbbankclassificationRules);
            vm.viewModelHelper.modelIsValid = vm.scbBANKclassification.isValid;
            vm.viewModelHelper.modelErrors = vm.scbBANKclassification.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
               vm.viewModelHelper.apiPost('api/scbbankclassification/updatescbbankclassification', vm.scbBANKclassification,
               function (result) {
                   
                   $state.go('ifrs-scbbankclassification-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.scbBANKclassification.errors;

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
                vm.viewModelHelper.apiPost('api/scbbankclassification/deletescbbankclassification', vm.scbBANKclassification.ID,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('ifrs-scbbankclassification-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('ifrs-scbbankclassification-list');
        };

        
        setupRules();
        initialize(); 
    }
}());
