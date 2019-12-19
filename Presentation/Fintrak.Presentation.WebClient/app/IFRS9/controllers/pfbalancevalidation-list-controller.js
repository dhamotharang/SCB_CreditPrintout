/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("PfBalanceValidationListController",
            ['$scope', '$state', 'viewModelHelper', 'validator',
                PfBalanceValidationListController]);

    function PfBalanceValidationListController($scope, $state, viewModelHelper, validator) {

        var vm = this;

        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS_PfBalanceValidation_Data';
        vm.view = 'pfbalancevalidation-list-view';
        vm.viewName = 'SCB GL Balances List Data';

        //Pagination Proper
        var tabID = 'pfBALANCEValidationTable';
        var exportTable;
        //End

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];


        vm.pfBALANCEValidation = [];
        vm.init = false;
        vm.searchParam = '';
        vm.defaultCount = 2000;
        vm.showInstruction = true;
        vm.instruction = 'Only top ' + vm.defaultCount + ' records loaded. Use the main search fuctionality to find a specific record by RefNo or Account No.';


        var initialize = function () {
            if (vm.init === false) {
                vm.loadDistinctPFBalances();
                vm.loadDistinctGLCodes();
                vm.loaddefault();
            }

        };
        var InitialView = function (tabID) {
            InitialGrid(tabID);
        }

        vm.loaddefault = function () {
            vm.viewModelHelper.apiGet('api/pfBALANCEValidation/availablePfBalanceValidations/' + vm.defaultCount, null,
                function (result) {
                    vm.pfBALANCEValidation = result.data;
                    InitialView('pfBALANCEValidationTable');
                    vm.searchParam = '';
                    if (vm.init === true) {
                        exportTable.destroy();
                    } else vm.init = true;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
        }



        vm.opt_1 = "";      //message on the input...

        vm.pfBalances = [];


        vm.loadDistinctPFBalances = function () {
            vm.errMsgs = [];

            vm.pfBalances = [{ 'Id': 0, 'name': '', 'title': ''}];

            vm.viewModelHelper.apiGet('api/pfBALANCEValidation/getDistinctPfBalances', null,
                function (result) {
                    var all = result.data;
                    for (var i = 1; i < all.length; i++) {
                        vm.pfBalances.push({ 'Id': i, 'name': all[i], 'title': all[i] });
                    }

                    console.log(vm.pfBalances);
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
        }

        vm.opt_2 = "";      //message on the input...
        vm.pfGlCodes = [];

        vm.loadDistinctGLCodes = function () {
            vm.errMsgs = [];
            vm.pfGlCodes = [{ 'Id': 0, 'name': '', 'title': '' }];
            vm.viewModelHelper.apiGet('api/pfBALANCEValidation/getDistinctGLCodes', null,
                function (result) {
                    var all = result.data;
                    for (var i = 0; i < all.length; i++) {
                        vm.pfGlCodes.push({ 'Id': i, 'name': all[i], 'title': all[i] });
                    }

                    console.log(vm.pfGlCodes);
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
        }




        vm.getPFBalanceSum = function () {

            var opts = {                    //using the CaptionModel
                Name: vm.opt_1.name,        //PFBalance
                Code: vm.opt_2.name          //GLCode 
            };

            vm.viewModelHelper.apiPost('api/pfBALANCEValidation/GetPfBalanceValidationList', opts,
                function (result) {
                    console.log(result);
                    vm.pfBALANCEValidation = result.data;
                    InitialView('pfBALANCEValidationTable');
                    if (vm.init === true) {
                        exportTable.destroy();
                    } else vm.init = true;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
        }









        var InitialGrid = function (tabID) {
            tabID = '#' + tabID;
            setTimeout(function () {
                // data export
                if ($(tabID).length > 0) {
                    exportTable = $(tabID).DataTable({
                        "lengthMenu": [[20, 50, 50, 100, -1], [20, 50, 50, 100, "All"]],
                        sDom: "T<'clearfix'>" +
                            "<'row'<'col-sm-6'l><'col-sm-6'f>r>" +
                            "t" +
                            "<'row'<'col-sm-6'i><'col-sm-6'p>>",
                        "tableTools": {
                            "sSwfPath": "app/assets/js/plugins/datatable/exts/swf/copy_csv_xls_pdf.swf"
                        }
                    });
                }
            },
                50);
        };

        vm.loadPfBalanceValidationBySearch = function () {

            if (vm.searchParam === '') {
                toastr.warning('Please input a RefNo ', 'Empty Search');
                return
            } else {

                vm.viewModelHelper.apiGet('api/pfBALANCEValidation/getpfbalancevalidationbysearch/' + vm.searchParam, null,
                    function (result) {
                        vm.pfBALANCEValidation = result.data;
                        console.log(vm.pfBALANCEValidation);
                        InitialView('pfBALANCEValidationTable');
                        if (vm.init === true) {
                            exportTable.destroy();
                        } else vm.init = true;
                    },
                    function (result) {
                        toastr.error(result.data, 'Fintrak');
                    }, null);
            }
        };

        vm.refresh = function () {

            //other inits... 
            vm.init = false;
            initialize();

            //vm.searchParam = '';
            exportTable.destroy();
        }



        initialize();
    }
}());
