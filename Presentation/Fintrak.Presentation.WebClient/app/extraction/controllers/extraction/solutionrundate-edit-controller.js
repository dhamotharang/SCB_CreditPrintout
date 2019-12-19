/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("SolutionRunDateEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        SolutionRunDateEditController]);

    function SolutionRunDateEditController($scope,$window, $state, $stateParams, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'Extraction & Process';
        vm.view = 'solutionRunDate-edit-view';
        vm.viewName = 'Run Date';

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.solutionRunDate = {};

        //vm.solutions = [];
        
        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';
        vm.testDate = new Date();
        var solutionRunDateRules = [];

        vm.openedRunDate = false;
        vm.oldRunDate = '';
        vm.enableSave = false;

        var setupRules = function() {

            //solutionRunDateRules.push(new validator.PropertyRule("SolutionId",
            //    {
            //        required: { message: "Solution is required" }
            //    }));

            solutionRunDateRules.push(new validator.PropertyRule("RunDate",
                {
                    mustBeDate: { message: "Please enter a valid date" }
                }));

        };

        var initialize = function() {
            if (vm.init === false) {
                //load lookups
                intialiazeLookUp();

                if ($stateParams.solutionrundateId !== 0) {
                    vm.showPeriod = true;
                    vm.viewModelHelper.apiGet(
                        'api/solutionRunDate/getsolutionrundate/' + $stateParams.solutionrundateId,
                        null,
                        function(result) {
                            vm.solutionRunDate = result.data;
                            vm.oldRunDate = new Date(vm.solutionRunDate.RunDate);
                            initialView();
                            vm.init === true;
                        },
                        function(result) {
                            toastr.error(result.data, 'Fintrak');
                        },
                        null);
                } else
                    vm.solutionRunDate = {
                        Solution: 2,
                        RunDate: new Date(),
                        Active: true
                    };
            }
        };

        var intialiazeLookUp = function() {
            //getSolutions();
            distinctArchiveDate();
        };

        var initialView = function() { };


        vm.save = function () {

            var message = 'This action will close the active rundate and roll-over to this new rundate. Are you sure you want to close the active rundate?';
            
            var closeFlag = $window.confirm(message);

            if (closeFlag) {

                //Validate
                validator.ValidateModel(vm.solutionRunDate, solutionRunDateRules);
                vm.viewModelHelper.modelIsValid = vm.solutionRunDate.isValid;
                vm.viewModelHelper.modelErrors = vm.solutionRunDate.errors;

                if (vm.viewModelHelper.modelIsValid) {

                    vm.viewModelHelper.apiPost('api/solutionRunDate/updatesolutionRunDate',
                        vm.solutionRunDate,
                        function(result) {
                            toastr.success('Rundate changed successfully.', 'Successful');
                            $state.go('core-solutionrundate-list');
                        },
                        function(error) {
                            toastr.error(result.data, 'Fintrak');
                        },
                        null);
                } else {
                    vm.viewModelHelper.modelErrors = vm.solutionRunDate.errors;

                    var errorList = '';

                    angular.forEach(vm.viewModelHelper.modelErrors,
                        function(error) {
                            errorList += error + '<br>';
                        });

                    toastr.error(errorList, 'Fintrak');
                }
            }
        };



        //vm.delete = function () {
        //    var deleteFlag = $window.confirm(' Are you sure you want to delete' );

        //    if (deleteFlag) {
        //        vm.viewModelHelper.apiPost('api/solutionRunDate/deletesolutionRunDate', vm.solutionRunDate.SolutionRunDateId,
        //      function (result) {
        //          toastr.success('Selected item deleted.', 'Fintrak');
        //          $state.go('core-solutionrundate-list');
        //      },
        //      function (result) {
        //          toastr.error(result.data, 'Fintrak');
        //      }, null);
        //    } 
        //}


        vm.cancel = function () {
            $state.go('core-solutionrundate-list');
        };

        vm.openRunDate = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();
            vm.openedRunDate = true;
        }

        //var getSolutions = function () {
        //    vm.viewModelHelper.apiGet('api/solution/availablesolutions', null,
        //         function (result) {
        //             vm.solutions = result.data;
        //             vm.init === true;

        //         },
        //         function (result) {
        //             toastr.error(result.data, 'Fintrak');
        //         }, null);
        //}

        vm.onChangedRundate = function() {
            if (vm.solutionRunDate.RunDate.getTime() !== vm.oldRunDate.getTime()) {
                vm.enableSave = true;
            } else {
                vm.enableSave = false;
            }
        };

        var distinctArchiveDate = function () {
            vm.viewModelHelper.apiGet('api/solutionRunDate/getArchiveDate', null,
                 function (result) {
                     vm.distinctArchiveDate = result.data;
                 },
                 function (result) {
                     toastr.error(result.data, 'Fintrak');
                 }, null);
        }

        vm.restoreArchive = function () {
            var params = { Solutionid: 1, Date: vm.ArchiveDate };
            vm.viewModelHelper.apiPost('api/solutionRunDate/restorearchive', params,
                      function (result) {
                          toastr.success('Restored Successfully.', 'Fintrak');
                      },
                     function (result) {
                         toastr.error(result.data, 'Fintrak Error');
                     }, null);
        }


        setupRules();
        initialize(); 
    }
}());
