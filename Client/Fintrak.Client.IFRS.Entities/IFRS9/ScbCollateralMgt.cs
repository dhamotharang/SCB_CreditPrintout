using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class ScbCollateralMgt : ObjectBase {

        int _ID;

        string _SCID;
        string _Customer_ID;
        string _contract_no;

        double _total_obligor_collateral_value;
        double _facility_coverage_value;

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

        public string SCID {
            get { return _SCID; }
            set {
                if (_SCID != value) {
                    _SCID = value;
                    OnPropertyChanged(() => SCID);
                }
            }
        }

        public string Customer_ID {
            get { return _Customer_ID; }
            set {
                if (_Customer_ID != value) {
                    _Customer_ID = value;
                    OnPropertyChanged(() => Customer_ID);
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

        public double total_obligor_collateral_value {
            get { return _total_obligor_collateral_value; }
            set {
                if (_total_obligor_collateral_value != value) {
                    _total_obligor_collateral_value = value;
                    OnPropertyChanged(() => total_obligor_collateral_value);
                }
            }
        }

        public double facility_coverage_value {
            get { return _facility_coverage_value; }
            set {
                if (_facility_coverage_value != value) {
                    _facility_coverage_value = value;
                    OnPropertyChanged(() => facility_coverage_value);
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


        class ScbCollateralMgtValidator : AbstractValidator<ScbCollateralMgt> {
            public ScbCollateralMgtValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }


        protected override IValidator GetValidator() {
            return new ScbCollateralMgtValidator();
        }


    }

}
