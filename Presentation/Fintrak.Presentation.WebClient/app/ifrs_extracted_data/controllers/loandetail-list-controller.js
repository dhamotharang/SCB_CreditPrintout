/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("LoanDetailListController",
                    ['$scope', '$state', 'viewModelHelper', 'validator',
                        LoanDetailListController]);

    function LoanDetailListController($scope,$state, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS_LoanDetail_Data';
        vm.view = 'loandetail-list-view';
        vm.viewName = 'Loan Detail Data';
       
        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        
        vm.loanDetail = [];
        vm.serachParam = '';
        vm.init = false;
        vm.showInstruction = true;
        vm.instruction = 'Only top 200 records loaded. Use the main search fuctionality to find a specific record by RefNo or Account No.';
        var exportTable;

        var initialize = function(){

            if (vm.init === false) {
                vm.viewModelHelper.apiGet('api/rawloandetail/availablerawloandetail', null,
                   function (result) {
                       vm.loanDetail = result.data;
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
                if ($('#loanDetailTable').length > 0) {
                    exportTable = $('#loanDetailTable').DataTable({
                        "lengthMenu": [[20, 50, 50, 100, -1], [20, 50, 50, 100, "All"]],
                        searching: false,
                        scrollX: true,
                        //"deferRender": true,
                        //sDom: "T<'clearfix'>" +
                        //"<'row'<'col-sm-6'l><'col-sm-6'f>r>" +
                        //"t" +
                        //"<'row'<'col-sm-6'i><'col-sm-6'p>>",
                        "tableTools": {
                            "sSwfPath": "app/assets/js/plugins/datatable/exts/swf/copy_csv_xls_pdf.swf"
                        }
                    });
                }
            }, 50);
        }

        vm.loadLoanDetailBySearch = function () {

            if (vm.serachParam === '') {
                toastr.warning('Please input a RefNo or Account No', 'Empty Search')
                return
            }
            else {

            vm.viewModelHelper.apiGet('api/rawloandetail/getloandetailbysearch/' + vm.serachParam, null,
                function (result) {
                    vm.loanDetail = result.data;
                    InitialView();
                    exportTable.destroy();
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
            }

        }

        vm.refresh = function () {
            vm.init = false;
            vm.serachParam = '';
            initialize();
            exportTable.destroy();
        }

        initialize(); 
    }
}());
