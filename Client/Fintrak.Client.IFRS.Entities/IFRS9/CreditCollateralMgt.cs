using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class CreditCollateralMgt : ObjectBase {

        int _ID;
        string _DETAILS_OF_SECURITIES_OTHERS;
        double _COLLATERAL_VALUE;
        string _COLLATERAL_STATUS;
        string _BANK_CLASSIFICATION;		
        string _LAST_EXAMINERS_CLASSIFICATION;
        string _SCI_ID;

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

        public string DETAILS_OF_SECURITIES_OTHERS {
            get { return _DETAILS_OF_SECURITIES_OTHERS; }
            set {
                if (_DETAILS_OF_SECURITIES_OTHERS != value) {
                    _DETAILS_OF_SECURITIES_OTHERS = value;
                    OnPropertyChanged(() => DETAILS_OF_SECURITIES_OTHERS);
                }
            }
        }


        public double COLLATERAL_VALUE {
            get { return _COLLATERAL_VALUE; }
            set {
                if (_COLLATERAL_VALUE != value) {
                    _COLLATERAL_VALUE = value;
                    OnPropertyChanged(() => COLLATERAL_VALUE);
                }
            }
        }


        public string COLLATERAL_STATUS {
            get { return _COLLATERAL_STATUS; }
            set {
                if (_COLLATERAL_STATUS != value) {
                    _COLLATERAL_STATUS = value;
                    OnPropertyChanged(() => COLLATERAL_STATUS);
                }
            }
        }


        public string BANK_CLASSIFICATION {
            get { return _BANK_CLASSIFICATION; }
            set {
                if (_BANK_CLASSIFICATION != value) {
                    _BANK_CLASSIFICATION = value;
                    OnPropertyChanged(() => BANK_CLASSIFICATION);
                }
            }
        }


        public string LAST_EXAMINERS_CLASSIFICATION {
            get { return _LAST_EXAMINERS_CLASSIFICATION; }
            set {
                if (_LAST_EXAMINERS_CLASSIFICATION != value) {
                    _LAST_EXAMINERS_CLASSIFICATION = value;
                    OnPropertyChanged(() => LAST_EXAMINERS_CLASSIFICATION);
                }
            }
        }


        public string SCI_ID {
            get { return _SCI_ID; }
            set {
                if (_SCI_ID != value) {
                    _SCI_ID = value;
                    OnPropertyChanged(() => SCI_ID);
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


        class CreditCollateralMgtValidator : AbstractValidator<CreditCollateralMgt> {
            public CreditCollateralMgtValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new CreditCollateralMgtValidator();
        }

    }

}
