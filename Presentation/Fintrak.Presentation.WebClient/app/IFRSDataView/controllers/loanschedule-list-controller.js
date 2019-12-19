/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("LoanScheduleListController",
                    ['$scope', '$state', 'viewModelHelper', 'validator',
                        LoanScheduleListController]);

    function LoanScheduleListController($scope,$state, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS_Processed_Data';
        vm.view = 'loanschedule-list-view';
        vm.viewName = 'Loan Schedules';
       
        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];
        
        vm.loanSchedules = [];

        vm.distinctRefNos = [];

        vm.RefNo = '';
        vm.Date = '';
        vm.init = false;
        vm.showInstruction = true;
        vm.instruction = 'Provide a Loan Reference Number and Tentative date to load schedule. Only 31 days will be displayed';
        var exportTable;

        var initialize = function(){

            if (vm.init === false) {

                intializeLookUp();
                //vm.viewModelHelper.apiGet('api/loanschedule/getloanschedule/' + vm.RefNo, null,
                //   function (result) {
                //       vm.loanSchedules = result.data;
                       InitialView();
                       vm.init === true;
                       
                //   },
                // function (result) {
                //     toastr.error(result.data, 'Fintrak');
                // }, null);
                vm.init === true;
            }
        }

        var intializeLookUp = function () {
            getRefNos();
        }

        var InitialView = function () {
            InitialGrid();
        }

        var InitialGrid = function () {
            setTimeout(function () {
                
                // data export
                if ($('#loanScheduleTable').length > 0) {
                    exportTable = $('#loanScheduleTable').DataTable({
                        "lengthMenu": [[20, 50, 50, 100, -1], [20, 50, 50, 100, "All"]],
                        searching: false,
                        scrollX: true,
                        //sDom: "T<'clearfix'>" +
                        //    "<'row'<'col-sm-6'l><'col-sm-6'f>r>" + "RC" +
                        //    "t" +
                        //    "<'row'<'col-sm-6'i><'col-sm-6'p>>",
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
            }, 50);
        }

        var getRefNos = function () {
            vm.viewModelHelper.apiGet('api/loanperiodicschedule/getrefnos', null,
                 function (result) {
                     vm.distinctRefNos = result.data;
                 },
                 function (result) {
                     toastr.error('Loan  Scedule.', 'Fintrak');
                 }, null);
        }
        vm.load = function () {
            var param = { Date: vm.Date.toLocaleDateString('sq-AL'), RefNo: vm.RefNo };
            //url = 'api/loanschedule/getschedulerange/' + vm.RefNo + '/' + vm.Date.toLocaleDateString('sq-AL');

            if (vm.RefNo === '') {
                toastr.warning('Please input a RefNo', 'Empty Reference Number')
                return
            }
            else if (vm.Date === '') {
                toastr.warning('Please provide a date', 'Empty Date')
                return
            }
            else {

                vm.viewModelHelper.apiPost('api/loanschedule/getschedulerange', param,
                    function (result) {
                        vm.loanSchedules = result.data;
                        InitialView();
                        exportTable.destroy();

                        toastr.success('Data for the selected RefNo and Date Range loaded.', 'Fintrak');
                    },
                    function (result) {
                        toastr.error('Fail to load data for the selected RefNo and Date Range.', 'Fintrak');
                    }, null);
            }
        }

              vm.exportToExcel = function (tableId) { 
            $(tableId).tableExport({ type: 'excel', escape: 'false' });
        }

        initialize(); 
    }
}());
