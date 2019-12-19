using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class PfBalanceValidation : ObjectBase {

        int _ID;
        string _Productcode;
        string _Glcode;
        double _GL_Balance;
        double _Loan_balance;
        double _Differences; 

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

        public string Productcode {
            get { return _Productcode; }
            set {
                if (_Productcode != value) {
                    _Productcode = value;
                    OnPropertyChanged(() => Productcode);
                }
            }
        }

        public string Glcode {
            get { return _Glcode; }
            set {
                if (_Glcode != value) {
                    _Glcode = value;
                    OnPropertyChanged(() => Glcode);
                }
            }
        }

        public double GL_Balance {
            get { return _GL_Balance; }
            set {
                if (_GL_Balance != value) {
                    _GL_Balance = value;
                    OnPropertyChanged(() => GL_Balance);
                }
            }
        }

        public double Loan_balance {
            get { return _Loan_balance; }
            set {
                if (_Loan_balance != value) {
                    _Loan_balance = value;
                    OnPropertyChanged(() => Loan_balance);
                }
            }
        }

        public double Differences {
            get { return _Differences; }
            set {
                if (_Differences != value) {
                    _Differences = value;
                    OnPropertyChanged(() => Differences);
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


        class PfBalanceValidationValidator : AbstractValidator<PfBalanceValidation> {
            public PfBalanceValidationValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new PfBalanceValidationValidator();
        }

    }

}
