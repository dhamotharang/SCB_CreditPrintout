using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities
{
    public class ScbDataTBValidated : ObjectBase
    {

        int _ID;
        string _contract_no;
        string _account_number;
        string _bvn;
        string _customer_name;
        int _tin;
        string _facility_type;
        string _business_type;
        string _sector;
        string _sub_sector;
        string _customer_id;
        string _group_organization;
        DateTime _date_granted;
        DateTime _last_credit_date;
        DateTime _expiry_date;
        DateTime _sanction_date;
        double _previous_limit;
        string _repayment_frequency;
        double _cum_repayment_amount_due;
        double _cum_repayment_amount_paid;
        double _cum_interest_due_not_yet_paid;
        double _cum_principal_due_not_yet_paid;
        double _interest_rate;
        double _tenor;
        double _balance;
        double _lcy;
        string _details_of_securities_others;
        double _collateral_value;
        string _collateral_status;
        string _bank_classification;
        string _last_examiners_classification;
        DateTime _last_audit_date;
        string _name_of_auditor;
        double _obligor_shareholder_fund;
        double _obligor_profit_before_tax;
        double _obligor_total_asset;
        bool _Active;

        public int ID {
            get { return _ID; }
            set {
                if (_ID != value) {
                    _ID = value;
                    OnPropertyChanged(() => ID);
                }
            }
        }

        public string contract_no {
            get { return _contract_no; }
            set {
                if (_contract_no != value) {
                    _contract_no = value;
                    OnPropertyChanged(() => contract_no);
                }
            }
        }

        public string account_number {
            get { return _account_number; }
            set {
                if (_account_number != value) {
                    _account_number = value;
                    OnPropertyChanged(() => account_number);
                }
            }
        }

        public string bvn {
            get { return _bvn; }
            set {
                if (_bvn != value) {
                    _bvn = value;
                    OnPropertyChanged(() => bvn);
                }
            }
        }

        public string customer_name {
            get { return _customer_name; }
            set {
                if (_customer_name != value) {
                    _customer_name = value;
                    OnPropertyChanged(() => customer_name);
                }
            }
        }

        public int tin {
            get { return _tin; }
            set {
                if (_tin != value) {
                    _tin = value;
                    OnPropertyChanged(() => tin);
                }
            }
        }

        public string facility_type {
            get { return _facility_type; }
            set {
                if (_facility_type != value) {
                    _facility_type = value;
                    OnPropertyChanged(() => facility_type);
                }
            }
        }

        public string business_type {
            get { return _business_type; }
            set {
                if (_business_type != value) {
                    _business_type = value;
                    OnPropertyChanged(() => business_type);
                }
            }
        }

        public string sector {
            get { return _sector; }
            set {
                if (_sector != value) {
                    _sector = value;
                    OnPropertyChanged(() => sector);
                }
            }
        }

        public string sub_sector {
            get { return _sub_sector; }
            set {
                if (_sub_sector != value) {
                    _sub_sector = value;
                    OnPropertyChanged(() => sub_sector);
                }
            }
        }

        public string customer_id {
            get { return _customer_id; }
            set {
                if (_customer_id != value) {
                    _customer_id = value;
                    OnPropertyChanged(() => customer_id);
                }
            }
        }

        public string group_organization {
            get { return _group_organization; }
            set {
                if (_group_organization != value) {
                    _group_organization = value;
                    OnPropertyChanged(() => group_organization);
                }
            }
        }

        public DateTime date_granted {
            get { return _date_granted; }
            set {
                if (_date_granted != value) {
                    _date_granted = value;
                    OnPropertyChanged(() => date_granted);
                }
            }
        }

        public DateTime last_credit_date {
            get { return _last_credit_date; }
            set {
                if (_last_credit_date != value) {
                    _last_credit_date = value;
                    OnPropertyChanged(() => last_credit_date);
                }
            }
        }

        public DateTime expiry_date {
            get { return _expiry_date; }
            set {
                if (_expiry_date != value) {
                    _expiry_date = value;
                    OnPropertyChanged(() => expiry_date);
                }
            }
        }

        public DateTime sanction_date {
            get { return _sanction_date; }
            set {
                if (_sanction_date != value) {
                    _sanction_date = value;
                    OnPropertyChanged(() => sanction_date);
                }
            }
        }

        public double previous_limit {
            get { return _previous_limit; }
            set {
                if (_previous_limit != value) {
                    _previous_limit = value;
                    OnPropertyChanged(() => previous_limit);
                }
            }
        }

        public string repayment_frequency {
            get { return _repayment_frequency; }
            set {
                if (_repayment_frequency != value) {
                    _repayment_frequency = value;
                    OnPropertyChanged(() => repayment_frequency);
                }
            }
        }

        public double cum_repayment_amount_due {
            get { return _cum_repayment_amount_due; }
            set {
                if (_cum_repayment_amount_due != value) {
                    _cum_repayment_amount_due = value;
                    OnPropertyChanged(() => cum_repayment_amount_due);
                }
            }
        }

        public double cum_repayment_amount_paid {
            get { return _cum_repayment_amount_paid; }
            set {
                if (_cum_repayment_amount_paid != value) {
                    _cum_repayment_amount_paid = value;
                    OnPropertyChanged(() => cum_repayment_amount_paid);
                }
            }
        }

        public double cum_interest_due_not_yet_paid {
            get { return _cum_interest_due_not_yet_paid; }
            set {
                if (_cum_interest_due_not_yet_paid != value) {
                    _cum_interest_due_not_yet_paid = value;
                    OnPropertyChanged(() => cum_interest_due_not_yet_paid);
                }
            }
        }

        public double cum_principal_due_not_yet_paid {
            get { return _cum_principal_due_not_yet_paid; }
            set {
                if (_cum_principal_due_not_yet_paid != value) {
                    _cum_principal_due_not_yet_paid = value;
                    OnPropertyChanged(() => cum_principal_due_not_yet_paid);
                }
            }
        }

        public double interest_rate {
            get { return _interest_rate; }
            set {
                if (_interest_rate != value) {
                    _interest_rate = value;
                    OnPropertyChanged(() => interest_rate);
                }
            }
        }

        public double tenor {
            get { return _tenor; }
            set {
                if (_tenor != value) {
                    _tenor = value;
                    OnPropertyChanged(() => tenor);
                }
            }
        }

        public double balance {
            get { return _balance; }
            set {
                if (_balance != value) {
                    _balance = value;
                    OnPropertyChanged(() => balance);
                }
            }
        }

        public double lcy {
            get { return _lcy; }
            set {
                if (_lcy != value) {
                    _lcy = value;
                    OnPropertyChanged(() => lcy);
                }
            }
        }

        public string details_of_securities_others {
            get { return _details_of_securities_others; }
            set {
                if (_details_of_securities_others != value) {
                    _details_of_securities_others = value;
                    OnPropertyChanged(() => details_of_securities_others);
                }
            }
        }

        public double collateral_value {
            get { return _collateral_value; }
            set {
                if (_collateral_value != value) {
                    _collateral_value = value;
                    OnPropertyChanged(() => collateral_value);
                }
            }
        }

        public string collateral_status {
            get { return _collateral_status; }
            set {
                if (_collateral_status != value) {
                    _collateral_status = value;
                    OnPropertyChanged(() => collateral_status);
                }
            }
        }

        public string bank_classification {
            get { return _bank_classification; }
            set {
                if (_bank_classification != value) {
                    _bank_classification = value;
                    OnPropertyChanged(() => bank_classification);
                }
            }
        }

        public string last_examiners_classification {
            get { return _last_examiners_classification; }
            set {
                if (_last_examiners_classification != value) {
                    _last_examiners_classification = value;
                    OnPropertyChanged(() => last_examiners_classification);
                }
            }
        }

        public DateTime last_audit_date {
            get { return _last_audit_date; }
            set {
                if (_last_audit_date != value) {
                    _last_audit_date = value;
                    OnPropertyChanged(() => last_audit_date);
                }
            }
        }

        public string name_of_auditor {
            get { return _name_of_auditor; }
            set {
                if (_name_of_auditor != value) {
                    _name_of_auditor = value;
                    OnPropertyChanged(() => name_of_auditor);
                }
            }
        }

        public double obligor_shareholder_fund {
            get { return _obligor_shareholder_fund; }
            set {
                if (_obligor_shareholder_fund != value) {
                    _obligor_shareholder_fund = value;
                    OnPropertyChanged(() => obligor_shareholder_fund);
                }
            }
        }

        public double obligor_profit_before_tax {
            get { return _obligor_profit_before_tax; }
            set {
                if (_obligor_profit_before_tax != value) {
                    _obligor_profit_before_tax = value;
                    OnPropertyChanged(() => obligor_profit_before_tax);
                }
            }
        }

        public double obligor_total_asset {
            get { return _obligor_total_asset; }
            set {
                if (_obligor_total_asset != value) {
                    _obligor_total_asset = value;
                    OnPropertyChanged(() => obligor_total_asset);
                }
            }
        }

        public bool Active {
            get { return _Active; }
            set {
                if (_Active != value) {
                    _Active = value;
                    OnPropertyChanged(() => Active);
                }
            }
        }


        class ScbDataTBValidatedValidator : AbstractValidator<ScbDataTBValidated>
        {
            public ScbDataTBValidatedValidator()
            {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator()
        {
            return new ScbDataTBValidatedValidator();
        }
    }
}
