/**
 * Created by Deb on 8/20/2014.
 */


(function () {
    "use strict";
    angular
        .module("fintrak")
        .controller("ScbDataTBValidatedEditController",
                    ['$scope', '$window', '$state', '$stateParams', 'viewModelHelper', 'validator',
                        ScbDataTBValidatedEditController]);

    function ScbDataTBValidatedEditController($scope, $window, $state, $stateParams, viewModelHelper, validator) {
              
        var vm = this;
        vm.viewModelHelper = viewModelHelper;
        vm.parentController = $scope.$parent;

        vm.module = 'IFRS9';
        vm.view = 'scbdatatbvalidated-edit-view';
        vm.viewName = 'CBN Credit Format Edit';
        vm.status = false;

        vm.viewModelHelper.modelIsValid = true;
        vm.viewModelHelper.modelErrors = [];

        vm.scbDATATBValidated = {};

        //for the sectors dropdown..
        vm.sectorObj = '';
        vm.allSectors = [];


        vm.init = false;
        vm.showInstruction = false;
        vm.instruction = '';

        var scbdatatbvalidatedRules = [];

        var setupRules = function () {
            //scbdatatbvalidatedRules.push(new validator.PropertyRule("ID, {
            //    required: { message: "ID is required" }
            //}));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("contract_no", {
                required: { message: "contract_no is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("account_number", {
                required: { message: "account_number is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("bvn", {
                required: { message: "bvn is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("customer_name", {
                required: { message: "customer_name is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("tin", {
                required: { message: "tin is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("facility_type", {
                required: { message: "facility_type is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("business_type", {
                required: { message: "business_type is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("sector", {
                required: { message: "sector is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("sub_sector", {
                required: { message: "sub_sector is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("customer_id", {
                required: { message: "customer_id is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("group_organization", {
                required: { message: "group_organization is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("date_granted", {
                required: { message: "date_granted is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("last_credit_date", {
                required: { message: "last_credit_date is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("expiry_date", {
                required: { message: "expiry_date is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("sanction_date", {
                required: { message: "sanction_date is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("previous_limit", {
                required: { message: "previous_limit is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("repayment_frequency", {
                required: { message: "repayment_frequency is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("cum_repayment_amount_due", {
                required: { message: "cum_repayment_amount_due is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("cum_repayment_amount_paid", {
                required: { message: "cum_repayment_amount_paid is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("cum_erest_due_not_yet_paid", {
                required: { message: "cum_erest_due_not_yet_paid is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("cum_principal_due_not_yet_paid", {
                required: { message: "cum_principal_due_not_yet_paid is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("interest_rate", {
                required: { message: "erest_rate is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("tenor", {
                required: { message: "tenor is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("balance", {
                required: { message: "balance is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("lcy", {
                required: { message: "lcy is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("details_of_securities_others", {
                required: { message: "details_of_securities_others is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("collateral_value", {
                required: { message: "collateral_value is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("collateral_status", {
                required: { message: "collateral_status is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("bank_classification", {
                required: { message: "bank_classification is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("last_examiners_classification", {
                required: { message: "last_examiners_classification is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("last_audit_date", {
                required: { message: "last_audit_date is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("name_of_auditor", {
                required: { message: "name_of_auditor is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("obligor_shareholder_fund", {
                required: { message: "obligor_shareholder_fund is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("obligor_profit_before_tax", {
                required: { message: "obligor_profit_before_tax is required" }
            }));

            scbdatatbvalidatedRules.push(new validator.PropertyRule("obligor_total_asset", {
                required: { message: "obligor_total_asset is required" }
            }));
        };
           

        var initialize = function () {
            if (vm.init === false) {

                //load lookups
                intializeLookUp();

                //load available sectors....
                vm.loadSectors();

                if ($stateParams.ID !== 0) {
                    vm.showChildren = true;
                    vm.viewModelHelper.apiGet('api/scbdatatbvalidated/getscbdatatbvalidated/' + $stateParams.ID, null,
                        function (result) {
                            vm.scbDATATBValidated = result.data;
                            initialView();
                            vm.init === true;

                        },
                        function (result) {
                            toastr.error(result.data, 'Fintrak');
                        }, null);
                }
                else
                    vm.scbDATATBValidated = {
                        contract_no: '',
                        account_number: '',
                        bvn: '',
                        customer_name: '',
                        tin: '',
                        facility_type: '',
                        business_type: '',
                        sector: '',
                        sub_sector: '',
                        customer_id: '',
                        group_organization: '',
                        date_granted: '',
                        last_credit_date: '',
                        expiry_date: '',
                        sanction_date: '',
                        previous_limit: '',
                        repayment_frequency: '',
                        cum_repayment_amount_due: '',
                        cum_repayment_amount_paid: '',
                        cum_erest_due_not_yet_paid: '',
                        cum_principal_due_not_yet_paid: '',
                        interest_rate: '',
                        tenor: '', balance: '', lcy: '',
                        details_of_securities_others: '',
                        collateral_value: '',
                        collateral_status: '',
                        bank_classification: '',
                        last_examiners_classification: '',
                        last_audit_date: '',
                        name_of_auditor: '',
                        obligor_shareholder_fund: '',
                        obligor_profit_before_tax: '',
                        obligor_total_asset: ''
                    };
            }
        };

        vm.chgSector = function () {
            vm.scbDATATBValidated.sector = vm.sectorObj.name;
        }

        //for the sector menu dropdown...  - load sectors...
        vm.loadSectors = function () {
            vm.viewModelHelper.apiGet('api/sector/getsectorsbysource/cbn', null,
                function (result) {

                    var all = result.data;          // vm.scbDATATBValidateds = result.data;
                    vm.allSectors = [];             //clear the array....

                    for (var i = 0; i < all.length; i++) {
                        vm.allSectors.push({ 'Id': i, 'name': all[i].Description, 'title': all[i].Description });
                    }
                    console.log(vm.subs);
                    vm.spinner = false;
                },
                function (result) {
                    toastr.error(result.data, 'Fintrak');
                    vm.spinner = false;
                }, null);

        };


        var intializeLookUp = function () {

        };

        var initialView = function () {

        };

        vm.save = function () {
            //Validate
            validator.ValidateModel(vm.scbDATATBValidated, scbdatatbvalidatedRules);
            vm.viewModelHelper.modelIsValid = vm.scbDATATBValidated.isValid;
            vm.viewModelHelper.modelErrors = vm.scbDATATBValidated.errors;
            if (vm.viewModelHelper.modelIsValid) {

                vm.viewModelHelper.apiPost('api/scbdatatbvalidated/updatescbdatatbvalidated', vm.scbDATATBValidated,
                    function (result) {

                        $state.go('ifrs-scbdatatbvalidated-list');
                    },
                    function (result) {
                        toastr.error(result.data, 'Fintrak');
                    }, null);
            }
            else {
                vm.viewModelHelper.modelErrors = vm.scbDATATBValidated.errors;

                var errorList = '';

                angular.forEach(vm.viewModelHelper.modelErrors, function (error) {
                    errorList += error + '<br>';
                });
                toastr.error(errorList, 'Fintrak');
            }

        };

        vm.delete = function () {
            var deleteFlag = $window.confirm(' Are you sure you want to delete');

            if (deleteFlag) {
                vm.viewModelHelper.apiPost('api/scbdatatbvalidated/deletescbdatatbvalidated', vm.scbDATATBValidated.ID,
                    function (result) {
                        toastr.success('Selected item deleted.', 'Fintrak');
                        $state.go('ifrs-scbdatatbvalidated-list');
                    },
                    function (result) {
                        toastr.error(result.data, 'Fintrak');
                    }, null);
            }
        };

        vm.cancel = function () {
            $state.go('ifrs-scbdatatbvalidated-list');
        };

        
        setupRules();
        initialize(); 
}

}());
