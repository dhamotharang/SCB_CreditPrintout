/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("GLMappingListController",
                    ['$scope', '$state', 'viewModelHelper', 'validator',
                        GLMappingListController]);

    function GLMappingListController($scope,$state, viewModelHelper, validator) {
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'Core';
        vm.view = 'glmapping-list-view';
        vm.viewName = 'GL Mappings';
       
        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];
        
        vm.glMappings = [];

        vm.init = false;
        vm.showInstruction = true;
        vm.instruction = '';
        vm.pageFlag = '';
        var exportTable;
        var tabID;
        vm.searchParam = '';
        vm.instruction = 'Only top 200 records loaded. Use the main search fuctionality to find a specific record by GL Code or GL Desription (Minimum of four(4) characters).';

        var initialize = function () {

            if (vm.init === false) {
                vm.loadRegistriesMapping();
            }
        };

        var InitialView = function (tableID) {
            InitialGrid(tableID);
        };

        var InitialGrid = function (tableID) {
            tabID = '#' + tableID;
            setTimeout(function () {
                    // data export
                    if ($(tabID).length > 0) {
                        exportTable = $(tabID).DataTable({
                            "lengthMenu": [[50, 100, -1], [50, 100, "All"]],
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

        vm.loadOthMapping = function () {
            vm.viewModelHelper.apiGet('api/glMapping/availableglMappings/' + 3,
                null,
                function (result) {
                    vm.glMappings = result.data;
                    InitialView('othGlMappingTable');

                    if (vm.init === true) {
                        exportTable.destroy();
                    } else vm.init = true;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                },
                null);
        };

        vm.loadMgtMapping = function () {
            vm.viewModelHelper.apiGet('api/glMapping/availableglMappings/' + 2,
                null,
                function (result) {
                    vm.glMappings = result.data;
                    InitialView('mgtGlMappingTable');
                    //vm.pageFlag = 2;

                    if (vm.init === true) {
                        exportTable.destroy();
                    } else vm.init = true;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                },
                null);
        };

        vm.loadRegistriesMapping = function () {
            vm.viewModelHelper.apiGet('api/glMapping/availableglMappings/' + 1,
                null,
                function (result) {
                    vm.glMappings = result.data;
                    InitialView('registryGlMappingTable');

                    if (vm.init === true) {
                        exportTable.destroy();
                    } else vm.init = true;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                },
                null);
        };

        vm.flipFlagToDescription = function (flag) {

            if (flag === 1) {
                return 'Conventional';
            } else if (flag === 2) {
                return 'Interim';
            } else if (flag === 3) {
                return 'NIB';
            }
        };

        vm.loadMappingsBySearch = function (flag, tableID) {

            vm.viewModelHelper.apiGet('api/glMapping/availableglmappingsbysearch/' + flag + '/' + vm.searchParam,
                null,
                function (result) {
                    vm.glMappings = result.data;
                    InitialView(tableID);

                    if (vm.init === true) {
                        exportTable.destroy();
                    } else vm.init = true;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                },
                null);
        }

        initialize(); 
    }
}());
