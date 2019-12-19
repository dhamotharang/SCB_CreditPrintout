/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("IfrsCorporateEclListController",
                    ['$scope', '$state', 'viewModelHelper', 'validator',
                        IfrsCorporateEclListController]);

    function IfrsCorporateEclListController($scope, $state, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'ifrscorporateecl-list-view';
        vm.viewName = 'Corporate ECL';
       
        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];
        
        vm.ifrsCorporateEcls = [];
        vm.disabled = false;
        vm.search;
        var exportTable;

        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var initialize = function(){

            if (vm.init === false) {
                vm.viewModelHelper.apiGet(
                    'api/ifrscorporateecl/getAllIfrsCorporateEcls',
                    null,
                    function (result) {
                        vm.ifrsCorporateEcls = result.data;
                        InitialView();
                        vm.init = true;
                    },
                    function (result) {
                        toastr.error(result.data, 'Fintrak');
                    },
                    null
                );
            }
        }

        vm.getIfrsCorporateEcl = function (refNo) {
            vm.disabled = true;
            if (refNo) {
                vm.viewModelHelper.apiGet('api/ifrscorporateecl/getIfrsCorporateEclByRefNo/' + refNo, null,
                   function (result) {
                       vm.ifrsCorporateEcls = result.data;
                       InitialView();
                       exportTable.destroy();
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
                if ($('#ifrsCorporateEclTable').length > 0) {
                        exportTable = $('#ifrsCorporateEclTable').DataTable({
                        "lengthMenu": [[20, 50, 100, -1], [20, 50, 100, "All"]],
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

        initialize();

        vm.reloadPage = function () {
            vm.search = false;
            vm.init = false;
            vm.refNo = null;
            initialize();
            exportTable.destroy();
        };
    }
}());
