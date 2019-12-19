using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class ScbCustomerInfo : ObjectBase {

        int _ID;
        string _Contract_Number;
        string _customer_id;
        string _Facility_type;
        string _Sector;
        string _Sub_sector;
        int _Repayment_Frequency;
        string _Repayment_Frequency_in_words;
        string _Tin_number;
        string _BVN;

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


        public string Contract_Number {
            get { return _Contract_Number; }
            set {
                if (_Contract_Number != value) {
                    _Contract_Number = value;
                    OnPropertyChanged(() => Contract_Number);
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


        public string Facility_type {
            get { return _Facility_type; }
            set {
                if (_Facility_type != value) {
                    _Facility_type = value;
                    OnPropertyChanged(() => Facility_type);
                }
            }
        }


        public string Sector {
            get { return _Sector; }
            set {
                if (_Sector != value) {
                    _Sector = value;
                    OnPropertyChanged(() => Sector);
                }
            }
        }


        public string Sub_sector {
            get { return _Sub_sector; }
            set {
                if (_Sub_sector != value) {
                    _Sub_sector = value;
                    OnPropertyChanged(() => Sub_sector);
                }
            }
        }


        public int Repayment_Frequency {
            get { return _Repayment_Frequency; }
            set {
                if (_Repayment_Frequency != value) {
                    _Repayment_Frequency = value;
                    OnPropertyChanged(() => Repayment_Frequency);
                }
            }
        }


        public string Repayment_Frequency_in_words {
            get { return _Repayment_Frequency_in_words; }
            set {
                if (_Repayment_Frequency_in_words != value) {
                    _Repayment_Frequency_in_words = value;
                    OnPropertyChanged(() => Repayment_Frequency_in_words);
                }
            }
        }


        public string Tin_number {
            get { return _Tin_number; }
            set {
                if (_Tin_number != value) {
                    _Tin_number = value;
                    OnPropertyChanged(() => Tin_number);
                }
            }
        }


        public string BVN {
            get { return _BVN; }
            set {
                if (_BVN != value) {
                    _BVN = value;
                    OnPropertyChanged(() => BVN);
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


        class ScbCustomerInfoValidator : AbstractValidator<ScbCustomerInfo> {
            public ScbCustomerInfoValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new ScbCustomerInfoValidator();
        }

    }

}
