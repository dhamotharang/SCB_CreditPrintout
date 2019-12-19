/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ClosedPeriodEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        ClosedPeriodEditController]);

    function ClosedPeriodEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'Extraction & Process';
        vm.view = 'closedPeriod-edit-view';
        vm.viewName = 'Activate/De-Activate Period';

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.closedPeriod = {};
        vm.enabled = true;
        vm.solutions = [];
        vm.closedPeriodStateText = "De-Activate this period";
        
        vm.init = false;
        vm.status = true;
        vm.showInstruction = false;
        vm.instruction = '';

        var closedPeriodRules = [];

        vm.openedRunDate = false;
        vm.closedPeriod = {};

        var setupRules = function () {
          
            closedPeriodRules.push(new validator.PropertyRule("SolutionId", {
                notZero: { message: "Solution is required" }
            }));

            closedPeriodRules.push(new validator.PropertyRule("Date", {
                mustBeDate: { message: "Please enter a valid date" }
            }));

        }

        var initialize = function () {
            if (vm.init === false) {
                //load lookups
                intialiazeLookUp();

                if ($stateParams.closedperiodId !== 0) {
                    vm.showPeriod = true;
                    vm.viewModelHelper.apiGet('api/closedPeriod/getclosedperiod/' + $stateParams.closedperiodId, null,
                   function (result) {
                       vm.closedPeriod = result.data;
                       vm.status = false;
                       vm.enabled = true;
                       if (vm.closedPeriod.Status)
                           vm.closedPeriodStateText = "De-Activate this period";
                       else
                           vm.closedPeriodStateText = "Activate this period";

                       initialView();

                       vm.init === true;
                       
                   },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
               }
               else
                    vm.closedPeriod = { SolutionId: 0, Date: new Date(), Status: false, Active: true };
                vm.status = true;
                vm.enabled = false;
                
               
            }
        }

        var intialiazeLookUp = function () {
            getSolutions();
        }

        var initialView = function () {
        
        }

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.closedPeriod, closedPeriodRules);
            vm.viewModelHelper.modelIsValid = vm.closedPeriod.isValid;
            vm.viewModelHelper.modelErrors = vm.closedPeriod.errors;
            if (vm.viewModelHelper.modelIsValid) {
             
                vm.viewModelHelper.apiPost('api/closedPeriod/updateclosedPeriod', vm.closedPeriod,
               function (result) {
                   
                   $state.go('core-closedperiod-list');
               },
               function (result) {
                   toastr.error(result.data, 'Fintrak');
               }, null);
            }
            else
            {
                vm.viewModelHelper.modelErrors = vm.closedPeriod.errors;

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
                vm.viewModelHelper.apiPost('api/closedPeriod/deleteclosedPeriod', vm.closedPeriod.ClosedPeriodId,
              function (result) {
                  toastr.success('Selected item deleted.', 'Fintrak');
                  $state.go('core-closedperiod-list');
              },
              function (result) {
                  toastr.error(result.data, 'Fintrak');
              }, null);
            } 
        }

        vm.cancel = function () {
            $state.go('core-closedperiod-list');
        };

        vm.closePeriod = function () {

            var message = '';
            if (vm.closedPeriod.Status)
                message = 'This action will De-Activate this period and roll-over to a new period or the latest period in the list. Are you sure you want to De-Activate this period?';
            else
                message = 'This action will Activate this period and close any active period. Are you sure you want to Activate this period?';

            var closeFlag = $window.confirm(message);

            if (closeFlag) {
                vm.viewModelHelper.apiPost('api/closedperiod/closeperiod', vm.closedPeriod,
                function (result) {
                    vm.closedPeriod = result.data;

                    if (vm.closedPeriod.Status)
                        vm.closedPeriodStateText = "De-Activate this period";
                    else
                        vm.closedPeriodStateText = "Activate this period";
                    message = 'Operation successfully executed';

                    alert(message);

                    $state.go('core-closedperiod-list');
                    toastr.success('Period De-Activated successfully', 'Fintrak');
                },
                function (result) {
                    toastr.error('Failed to De-Activated period', 'Fintrak');
                }, null);
            }   
        };

        vm.openDate = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();
            vm.openedDate = true;
        }

        var getSolutions = function () {
            vm.viewModelHelper.apiGet('api/solution/availablesolutions', null,
                 function (result) {
                     vm.solutions = result.data;
                     vm.init === true;

                 },
                 function (result) {
                     toastr.error(result.data, 'Fintrak');
                 }, null);
        }


        setupRules();
        initialize(); 
    }
}());
