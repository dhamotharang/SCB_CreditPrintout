using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class SCBThrownOutPSFAcc : ObjectBase {

        int _ID;
        string _PSfAccount ;
        double _Amount ; 
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

        public string PSfAccount  {
            get { return _PSfAccount ; }
            set {
                if (_PSfAccount  != value) {
                    _PSfAccount  = value;
                    OnPropertyChanged(() => PSfAccount );
                }
            }
        }

        public double Amount  {
            get { return _Amount ; }
            set {
                if (_Amount  != value) {
                    _Amount  = value;
                    OnPropertyChanged(() => Amount );
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


        class SCBThrownOutPSFAccValidator : AbstractValidator<SCBThrownOutPSFAcc> {
            public SCBThrownOutPSFAccValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new SCBThrownOutPSFAccValidator();
        }

    }

}
