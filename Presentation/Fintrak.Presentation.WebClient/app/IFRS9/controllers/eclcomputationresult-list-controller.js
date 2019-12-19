/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("EclComputationResultListController",
                    ['$scope', '$state', 'viewModelHelper', 'validator',
                        EclComputationResultListController]);

    function EclComputationResultListController($scope, $state, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'eclcomputationresult-list-view';
        vm.viewName = 'EclComputationResult';

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.eclComputationResults = [];
        vm.stage = 'All';

        vm.stages = [
            { Id: 'All', Name: 'All' },
            { Id: 1, Name: 'Performing' },
            { Id: 2, Name: 'Under-Performing' },
            { Id: 3, Name: 'Non-Performing' },
        ];

        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';
        var exportTable;

        var initialize = function () {

            if (vm.init === false) {
                vm.viewModelHelper.apiGet('api/eclcomputationresult/availableeclComputationResults', null,
                   function (result) {
                       vm.eclComputationResults = result.data;
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
                if ($('#eclComputationResultTable').length > 0) {
                    exportTable = $('#eclComputationResultTable').DataTable({
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
            }, 50);
        }

        vm.loadByStage = function () {
            if (vm.stage === 'All') {

                vm.viewModelHelper.apiGet('api/eclcomputationresult/availableeclComputationResults', null,
                    function (result) {
                        vm.eclComputationResults = result.data;
                        InitialView();
                        exportTable.destroy();

                    },
                    function (result) {
                        toastr.error(result.data, 'Fintrak');
                    }, null);
            }
            else {

            vm.viewModelHelper.apiGet('api/eclcomputationresult/availableeclComputationResultsByStage/' + vm.stage, null,
                function (result) {
                    vm.eclComputationResults = result.data;
                    InitialView();
                    exportTable.destroy();
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
            }
        }

        initialize();
    }
}());
