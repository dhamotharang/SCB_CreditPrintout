using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class ScbLimitDef : ObjectBase {

        int _ID;
        string _sci_id;
        string _currency;
        string _limit;

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

        public string sci_id {
            get { return _sci_id; }
            set {
                if (_sci_id != value) {
                    _sci_id = value;
                    OnPropertyChanged(() => sci_id);
                }
            }
        }

        public string currency {
            get { return _currency; }
            set {
                if (_currency != value) {
                    _currency = value;
                    OnPropertyChanged(() => currency);
                }
            }
        }

        public string limit {
            get { return _limit; }
            set {
                if (_limit != value) {
                    _limit = value;
                    OnPropertyChanged(() => limit);
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


        class ScbLimitDefValidator : AbstractValidator<ScbLimitDef> {
            public ScbLimitDefValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new ScbLimitDefValidator();
        }

    }

}
