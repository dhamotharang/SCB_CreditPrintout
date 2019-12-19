using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class ScbException : ObjectBase {

        int _ID;
        string _REFNO;
        string _MESSAGE;
        string _CUST_ID;

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

        public string REFNO {
            get { return _REFNO; }
            set {
                if (_REFNO != value) {
                    _REFNO = value;
                    OnPropertyChanged(() => REFNO);
                }
            }
        }

        public string MESSAGE {
            get { return _MESSAGE; }
            set {
                if (_MESSAGE != value) {
                    _MESSAGE = value;
                    OnPropertyChanged(() => MESSAGE);
                }
            }
        }

        public string CUST_ID {
            get { return _CUST_ID; }
            set {
                if (_CUST_ID != value) {
                    _CUST_ID = value;
                    OnPropertyChanged(() => CUST_ID);
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


        class ScbExceptionValidator : AbstractValidator<ScbException> {
            public ScbExceptionValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new ScbExceptionValidator();
        }

    }

}
