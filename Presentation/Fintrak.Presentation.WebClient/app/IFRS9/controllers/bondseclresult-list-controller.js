/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("BondsECLResultListController",
        ['$scope', '$state', 'viewModelHelper', 'validator',
            BondsECLResultListController]);

    function BondsECLResultListController($scope, $state, viewModelHelper, validator) {

        var vm = this;

        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS_BondsECLResult_Data';
        vm.view = 'bondseclresult-list-view';
        vm.viewName = 'Bonds ECL Result Data';

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

 
        vm.bondsECLresult = [];
        vm.init = false;
        vm.searchParam = '';
        vm.defaultCount = 5000;
        vm.showInstruction = true ;
        vm.instruction = 'Only top ' + vm.defaultCount + ' records loaded. Use the main search fuctionality to find a specific record by RefNo or Account No.';


        var initialize = function () {

            if (vm.init === false) {
                vm.viewModelHelper.apiGet('api/bondsECLresult/availableBondsECLResults/' + vm.defaultCount, null,
                    function (result) {
                        vm.bondsECLresult = result.data;
                        InitialView();
                        vm.init === true;
                    },
                    function (result) {
                        toastr.error(result.data, 'Fintrak');
                    }, null);
            }
        };

        var InitialView = function () {
            InitialGrid();
        };

        var InitialGrid = function () {
            setTimeout(function () {

                // data export
                if ($('#bondsECLresultTable').length > 0) {
                    var exportTable = $('#bondsECLresultTable').DataTable({
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
        };

        vm.loadBondsECLResultBySearch = function () {

            if (vm.searchParam === '') {
                toastr.warning('Please input a RefNo ', 'Empty Search');
                return
            }else{

                vm.viewModelHelper.apiGet('api/bondsECLresult/getbondseclresultbysearch/' + vm.searchParam, null,
                    function (result) {
                        vm.bondsECLresult = result.data;
                        // InitialView();                      
                    },
                    function (result) {
                        toastr.error(result.data, 'Fintrak');
                    }, null);
            }
        };

        //};   

        vm.refresh = function () {
            vm.init = false;
            vm.searchParam = '';
            vm.viewModelHelper.apiGet('api/bondsECLresult/availablebondseclresults/' + vm.defaultCount, null,
                function (result) {
                    vm.bondsECLresult = result.data;
                    //  InitialView();
                    //  vm.init === true;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
        };


        initialize();
    }
}());
