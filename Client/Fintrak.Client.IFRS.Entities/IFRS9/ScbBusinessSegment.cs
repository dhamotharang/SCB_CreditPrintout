using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class ScbBusinessSegment : ObjectBase {

        int _ID;
        string _cust_code;
        string _segment;

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

        public string cust_code  {
            get { return _cust_code ; }
            set {
                if (_cust_code  != value) {
                    _cust_code  = value;
                    OnPropertyChanged(() => cust_code );
                }
            }
        }

        public string segment  {
            get { return _segment ; }
            set {
                if (_segment  != value) {
                    _segment  = value;
                    OnPropertyChanged(() => segment );
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


        class ScbBusinessSegmentValidator : AbstractValidator<ScbBusinessSegment> {
            public ScbBusinessSegmentValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new ScbBusinessSegmentValidator();
        }

    }

}
