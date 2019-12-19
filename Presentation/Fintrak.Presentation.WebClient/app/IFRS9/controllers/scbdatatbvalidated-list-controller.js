/**
 * Created by Deb on 8/20/2014.
 */
(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbDataTBValidatedListController",
            ['$scope', '$state', 'viewModelHelper', 'validator', ScbDataTBValidatedListController]);

    function ScbDataTBValidatedListController($scope, $state, viewModelHelper, validator) {

        var vm = this;

        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS_ScbDataTBValidated_Data';
        vm.view = 'scbdatatbvalidated-list-view';
        vm.viewName = 'CBN Credit Format - Data';

        //Pagination Proper
        var tabID = 'scbDATATBValidatedTable';
        var exportTable;
        //End

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.total_balance = 0;

        vm.scbDATATBValidateds = [];
        vm.init = false;
        vm.searchParam = '';
        vm.defaultCount = 500;
        vm.showInstruction = true;
        vm.instruction = 'Only top ' + vm.defaultCount + ' records loaded. Use the main search fuctionality to find a specific record by RefNo or Account No.';


        /////////////////////////////////////////////////////////////////////// filter begins...


        //whow or hide the spinner... 
        vm.spinner = false;

        vm.opt_1 = "";
        vm.opt_2 = "";
        vm.filterValue = '';

        vm.subs = [];

       // vm.criteraOptions = 'contract_no;account_number;bvn;customer_name;tin;facility_type;business_type;sector;sub_sector;customer_id;group_organization;last_credit_date;previous_limit;bank_classification;last_examiners_classification;name_of_auditor;obligor_shareholder_fund;obligor_profit_before_tax;obligor_total_asset'


        vm.optCriteria = [
            { Id: 1, name: 'BVN',                title:'BVN' },
            { Id: 2, name: 'contract_no',        title:'Contract No'},
            { Id: 3, name: 'account_number',     title:'Account No'}, 
            { Id: 4, name: 'facility_type',      title:'Facility Type'}, 
            { Id: 5, name: 'business_type',      title:'Business Type'}, 
            { Id: 6, name: 'group_organization', title:'Group Organization'}, 
            { Id: 7, name: 'sector',             title:'Sector'}, 
            { Id: 8, name: 'sub_sector',         title:'Sub-Sector'} 
        ]; 


        vm.minLoan = vm.maxLoan = 0;

        vm.filterLoans = function () {

            var mxl = parseInt(vm.maxLoan);
            var mnl = parseInt(vm.minLoan);
            if (mxl <= mnl) {
                toastr.warning('The maximum loan amount must be greater than the minimum loan amount..');
                return;
            } else {             
                vm.viewModelHelper.apiGet('api/scbdatatbvalidated/getScbDataTBLoanbyrange/' + mnl + '/' + mxl , 
                null,
                function (result) {
                    vm.scbDATATBValidateds = result.data;
                    //refresh everything... 
                    vm.searchParam = '';
                   // vm.refresh();
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
            }
        };



        vm.getSubOptions = function () {
            vm.spinner = true;
            vm.viewModelHelper.apiGet('api/scbDATATBValidated/getOptionsFromFilter/' + vm.opt_1.name, null,
                function (result) {
                    // vm.scbDATATBValidateds = result.data;
                    var all = result.data;
                    vm.subs = []; //clear the array....

                    for (var i = 0; i < all.length; i++) {
                        vm.subs.push({ 'Id': i, 'name': all[i], 'title': all[i] });
                    }
                    console.log(vm.subs);
                    vm.spinner = false;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                    vm.spinner = false;
                }, null);
        };

        vm.updateFilterCriteria = function () {
            //alert(vm.opt_2.name);
            if (vm.opt_1.name == null || vm.opt_2.name == null || vm.filterValue == '') {

                toastr.warning('Please select the appropriate options first...');
                return;

            } else {

                var postData = {
                    colName : vm.opt_1.name,
                    oldValue: vm.opt_2.name,
                    newValue: vm.filterValue
                };


                console.log(postData);

                //alert(JSON.stringify(postData));

                vm.viewModelHelper.apiPost('api/scbDATATBValidated/updateFilteredScbDataTBValidated', postData,
                function (result) {
                    vm.scbDATATBValidateds = result.data;
                    //vm.calcTotalBalance(result.data);
                    //refresh everything... 
                    vm.searchParam = '';
                    vm.refresh();
                    vm.getSubOptions();
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);

            }
        };


        ///////////////////////////////////////////////////////////     fiter ends..


        var initialize = function () {
            if (vm.init === false) {
                vm.loaddefault();
                vm.loadTotalBalance();
            }

        };
        var InitialView = function (tabID) {
            InitialGrid(tabID);
        }

        vm.loaddefault = function () {
            vm.viewModelHelper.apiGet('api/scbDATATBValidated/availableScbDataTBValidateds/' + vm.defaultCount, null,
                function (result) {
                    vm.scbDATATBValidateds = result.data;
                    InitialView('scbDATATBValidatedTable');
                    vm.searchParam = '';
                    if (vm.init === true) {
                        exportTable.destroy();
                    } else vm.init = true;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                }, null);
        }


        vm.loadTotalBalance = function () {
            vm.viewModelHelper.apiGet('api/ScbDataTBValidated/getScbDataTBValidatedBalance', null,
                function (result) {
                    vm.total_balance = result.data;
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


        vm.exportAllData = function () {
            var xhr = new XMLHttpRequest();
            xhr.onreadystatechange = function () {
                vm.loading = false;
            }
            xhr.open('GET', 'api/scbDATATBValidated/exportScbDATATBValidated/0', true);
            xhr.responseType = 'arraybuffer';
            xhr.onload = function () {
                if (this.status === 200) {
                    var filename = "";
                    var disposition = xhr.getResponseHeader('Content-Disposition');
                    if (disposition && disposition.indexOf('attachment') !== -1) {
                        var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
                        var matches = filenameRegex.exec(disposition);
                        if (matches != null && matches[1]) filename = matches[1].replace(/['"]/g, '');
                    }
                    var type = xhr.getResponseHeader('Content-Type');

                    var blob = typeof File === 'function'
                        ? new File([this.response], filename, { type: type })
                        : new Blob([this.response], { type: type });
                    if (typeof window.navigator.msSaveBlob !== 'undefined') {
                        // IE workaround for "HTML7007: One or more blob URLs were revoked by closing the blob for which they were created. These URLs will no longer resolve as the data backing the URL has been freed."
                        window.navigator.msSaveBlob(blob, filename);
                    } else {
                        var URL = window.URL || window.webkitURL;
                        var downloadUrl = URL.createObjectURL(blob);

                        if (filename) {
                            // use HTML5 a[download] attribute to specify filename
                            var a = document.createElement("a");
                            // safari doesn't support this yet
                            if (typeof a.download === 'undefined') {
                                window.location = downloadUrl;
                            } else {
                                a.href = downloadUrl;
                                a.download = filename;
                                document.body.appendChild(a);
                                a.click();
                            }
                        } else {
                            window.location = downloadUrl;
                        }

                        setTimeout(function () { URL.revokeObjectURL(downloadUrl); }, 100); // cleanup
                    }
                }
            };
            xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
            vm.loading = true;
            xhr.send()
        }




        vm.loadScbDataTBValidatedBySearch = function () {

            if (vm.searchParam === '') {
                toastr.warning('Please input a RefNo ', 'Empty Search');
                return
            } else {

                vm.viewModelHelper.apiGet('api/scbDATATBValidated/getscbdatatbvalidatedbysearch/' + vm.searchParam, null,
                    function (result) {
                        vm.scbDATATBValidateds = result.data;
                        vm.calcTotalBalance(result.data);

                        InitialView('scbDATATBValidatedTable');
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
            vm.init = false;
            vm.searchParam = '';
            initialize();
            exportTable.destroy();
        };

        initialize();
    }
}());
