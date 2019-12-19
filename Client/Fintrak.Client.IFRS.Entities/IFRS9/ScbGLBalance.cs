using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class ScbGLBalance : ObjectBase {

        int _ID;

        string _Glcode;
        string _glcode_description;
        string _ProductCode;
        string _Product_description;
        double _Amount;
        DateTime _ReportDate;

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

        public string Glcode {
            get { return _Glcode; }
            set {
                if (_Glcode != value) {
                    _Glcode = value;
                    OnPropertyChanged(() => Glcode);
                }
            }
        }

        public string glcode_description {
            get { return _glcode_description; }
            set {
                if (_glcode_description != value) {
                    _glcode_description = value;
                    OnPropertyChanged(() => glcode_description);
                }
            }
        }

        public string ProductCode {
            get { return _ProductCode; }
            set {
                if (_ProductCode != value) {
                    _ProductCode = value;
                    OnPropertyChanged(() => ProductCode);
                }
            }
        }

        public string Product_description {
            get { return _Product_description; }
            set {
                if (_Product_description != value) {
                    _Product_description = value;
                    OnPropertyChanged(() => Product_description);
                }
            }
        }

        public double Amount {
            get { return _Amount; }
            set {
                if (_Amount != value) {
                    _Amount = value;
                    OnPropertyChanged(() => Amount);
                }
            }
        }

        public DateTime ReportDate {
            get { return _ReportDate; }
            set {
                if (_ReportDate != value) {
                    _ReportDate = value;
                    OnPropertyChanged(() => ReportDate);
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


        class ScbGLBalanceValidator : AbstractValidator<ScbGLBalance> {
            public ScbGLBalanceValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new ScbGLBalanceValidator();
        }

    }

}
