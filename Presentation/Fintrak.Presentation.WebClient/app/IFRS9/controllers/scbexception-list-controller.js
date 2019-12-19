/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbExceptionListController",
            ['$scope', '$state', 'viewModelHelper', 'validator',
                ScbExceptionListController]);

    function ScbExceptionListController($scope, $state, viewModelHelper, validator) {

        var vm = this;

        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS_ScbException_Data';
        vm.view = 'scbexception-list-view';
        vm.viewName = 'SCB Exceptions List Data';

        //Pagination Proper
        var tabID = 'scbEXCEPtionTable';
        var exportTable;
        //End

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];


        vm.scbEXCEPtion = [];
        vm.init = false;
        vm.searchParam = '';
        vm.defaultCount = 2000;
        vm.showInstruction = true;
        vm.instruction = 'Only top ' + vm.defaultCount + ' records loaded. Use the main search fuctionality to find a specific record by RefNo or Account No.';


        var initialize = function () {
            if (vm.init === false) {
                vm.loaddefault();
                vm.loadDistinctMsgs();
            }

        };
        var InitialView = function (tabID) {
            InitialGrid(tabID);
        }


        vm.scbExpData = []
        vm.prepareData = function (data) {
            vm.scbExpData = [];
            for (var i = 0; i < data.length; i++) {
                vm.scbExpData.push({
                    'ID': data[i].ID,
                    'REFNO': data[i].REFNO,
                    'MESSAGE': data[i].MESSAGE,
                    'REF_ID': data[i].REFNO
                });
            }
           // return vm.scbExpData;

            InitialView('scbEXCEPtionTable');
            vm.searchParam = '';
            if (vm.init === true) {
                exportTable.destroy();
            } else vm.init = true;

        }

        vm.loaddefault = function () {
            vm.viewModelHelper.apiGet('api/scbEXCEPtion/availableScbExceptions/' + vm.defaultCount, null,
                function (result) {
                    vm.prepareData(result.data);
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
        }


        vm.opt_1 = "";      //message on the input...
        vm.errMsgs = [];

        vm.loadDistinctMsgs = function () {
            vm.errMsgs = [];
            vm.viewModelHelper.apiGet('api/scbEXCEPtion/getDistinctExpMessages', null,
            function (result) {
                var all = result.data;
                for (var i = 0; i < all.length; i++) {
                    vm.errMsgs.push({ 'Id': i, 'name': all[i], 'title': all[i] });
                }

               // console.log(vm.errMsgs);
            },
            function (result) {
                toastr.error(result.data, 'Fintrak');
            }, null);
        }

        vm.DelExceptionObjRef = function (refno) {
            vm.viewModelHelper.apiGet('api/scbEXCEPtion/RevertExceptionById/' + refno, null,
            function (result) {
                vm.prepareData(result.data);
            },
            function (result) {
                toastr.error(result.data, 'Fintrak');
            }, null);
        }


        vm.delAllExceptionsObj = function () {
            vm.viewModelHelper.apiGet('api/scbEXCEPtion/DelAllExceptionsObj/', null,
                function (result) {
                    vm.prepareData(result.data);
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
        }

   
        vm.getExpMsg = function () {
            //chosen exception message...
            vm.viewModelHelper.apiGet('api/scbEXCEPtion/getExceptionMessageByFilter/'+ vm.opt_1.name, null,
                function (result) {
                    vm.prepareData(result.data);
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


        vm.loadScbExceptionBySearch = function () {
            if (vm.searchParam === '') {
                toastr.warning('Please input a Ref No', 'Empty Search');
                return
            } else {
                vm.viewModelHelper.apiGet('api/scbEXCEPtion/getscbexceptionbysearch/' + vm.searchParam, null,
                function (result) {
                    vm.prepareData(result.data);
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
            }
        };

        vm.refresh = function () {
            vm.init = false;
            vm.searchParam = '';
            initialize();
            exportTable.destroy();
        }



        initialize();
    }
}());
