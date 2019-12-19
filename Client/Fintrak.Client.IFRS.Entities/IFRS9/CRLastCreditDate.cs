using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class CRLastCreditDate : ObjectBase {

        int _ID;
        string _LAST_CREDIT_DATE;
        string _facility_type;
        string _Customer_Id;
        string _sector;
        string _subsector;
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

        public string LAST_CREDIT_DATE {
            get { return _LAST_CREDIT_DATE; }
            set {
                if (_LAST_CREDIT_DATE != value) {
                    _LAST_CREDIT_DATE = value;
                    OnPropertyChanged(() => LAST_CREDIT_DATE);
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

        public string Customer_Id {
            get { return _Customer_Id; }
            set {
                if (_Customer_Id != value) {
                    _Customer_Id = value;
                    OnPropertyChanged(() => Customer_Id);
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

        public string subsector {
            get { return _subsector; }
            set {
                if (_subsector != value) {
                    _subsector = value;
                    OnPropertyChanged(() => subsector);
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


        class CRLastCreditDateValidator : AbstractValidator<CRLastCreditDate> {
            public CRLastCreditDateValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new CRLastCreditDateValidator();
        }

    }

}
