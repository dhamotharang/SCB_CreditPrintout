/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("LoanPryListController",
                    ['$scope', '$state', 'viewModelHelper', 'validator',
                        LoanPryListController]);

    function LoanPryListController($scope, $state, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS_LoanPry_Data';
        vm.view = 'loanpry-list-view';
        vm.viewName = 'Loan Pry Data';

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

 
        vm.loanPry = [];
        vm.init = false;
        vm.serachParam = '';
        vm.defaultCount = 40;
        vm.showInstruction = true;
        vm.instruction = 'Only top ' + vm.defaultCount + ' records loaded. Use the main search fuctionality to find a specific record by RefNo or Account No.';




        var initialize = function () {

            if (vm.init === false) {
                vm.viewModelHelper.apiGet('api/loanPry/availablepryloan/' + vm.defaultCount, null,
                   function (result) {
                       vm.loanPry = result.data;
                       InitialView();
                       vm.init === true;
                   },
                 function (result) {
                     toastr.error(result.data, 'Fintrak');
                 }, null);
            }
        }

        var InitialView = function () {
            InitialGrid();
        }

        var InitialGrid = function () {
            setTimeout(function () {

                // data export
                if ($('#loanPryTable').length > 0) {
                    var exportTable = $('#loanPryTable').DataTable({
                        "lengthMenu": [[20, 50, 100, 200, -1], [20, 50, 100, 200, "All"]],
                        sDom: "T<'clearfix'>" +
                            "<'row'<'col-sm-6'l><'col-sm-6'f>r>" + "RC" +
                            "t" +
                            "<'row'<'col-sm-6'i><'col-sm-6'p>>",
                        "tableTools": {
                            "sSwfPath": "app/assets/js/plugins/datatable/exts/swf/copy_csv_xls_pdf.swf"
                        },
                        "aoColumnDefs": [
                             //{ "bVisible": false, "aTargets": [0] }
                        ],
                        "colVis": {
                            buttonText: 'Show / Hide Columns',
                            restore: "Restore",
                            showAll: "Show all"
                        }
                    });
                }
            }, 20);
        }

        vm.loadPryLoanBySearch = function () {

            if (vm.serachParam === '') {
                toastr.warning('Please input a RefNo or Account No', 'Empty Search')
                return
            }
            else {
               
                vm.viewModelHelper.apiGet('api/loanPry/getloanprybysearch/' + vm.serachParam, null,
                    function (result) {
                        vm.loanPry = result.data;
                       // InitialView();                      
                    },
                    function (result) {
                        toastr.error(result.data, 'Fintrak');
                    }, null);
            }

        }

        vm.refresh = function () {
            vm.init = false;
            vm.serachParam = '';
            vm.viewModelHelper.apiGet('api/loanPry/availablepryloan/' + vm.defaultCount, null,
                     function (result) {
                         vm.loanPry = result.data;
                       //  InitialView();
                       //  vm.init === true;
                     },
                   function (result) {
                       toastr.error(result.data, 'Fintrak');
                   }, null);
        }


        initialize();
    }
}());
