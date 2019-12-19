using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities
{
    public class ScbBankClassification : ObjectBase
    {
        int _ID;

        string _contract_no;
        string _facility_type;
        string _sector;
        string _prev_bank_classification;
        string _curr_bank_classification;

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
        public string contract_no {
            get { return _contract_no; }
            set {
                if (_contract_no != value) {
                    _contract_no = value;
                    OnPropertyChanged(() => contract_no);
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

        public string sector {
            get { return _sector; }
            set {
                if (_sector != value) {
                    _sector = value;
                    OnPropertyChanged(() => sector);
                }
            }
        }

        public string prev_bank_classification {
            get { return _prev_bank_classification; }
            set {
                if (_prev_bank_classification != value) {
                    _prev_bank_classification = value;
                    OnPropertyChanged(() => prev_bank_classification);
                }
            }
        }

        public string curr_bank_classification {
            get { return _curr_bank_classification; }
            set {
                if (_curr_bank_classification != value) {
                    _curr_bank_classification = value;
                    OnPropertyChanged(() => curr_bank_classification);
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


        class ScbBankClassificationValidator : AbstractValidator<ScbBankClassification>
        {
            public ScbBankClassificationValidator()
            {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator()
        {
            return new ScbBankClassificationValidator();
        }
    }
}
