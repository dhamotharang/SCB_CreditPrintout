using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class ScbProduct : ObjectBase {

        int _ID;
        string _PsfAccNum;
        string _Description;
        string _ProductCode;
        string _ProductcodeDescription;
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

        // [DataMember] public string PsfAccNum { get; set; }
        // [DataMember] public string Description { get; set; }
        // [DataMember] public string ProductCode { get; set; }
        // [DataMember] public string ProductcodeDesctiption { get; set; }

        public string PsfAccNum {
            get { return _PsfAccNum; }
            set {
                if (_PsfAccNum != value) {
                    _PsfAccNum = value;
                    OnPropertyChanged(() => PsfAccNum);
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

        public string Description {
            get { return _Description; }
            set {
                if (_Description != value) {
                    _Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        public string ProductcodeDescription {
            get { return _ProductcodeDescription; }
            set {
                if (_ProductcodeDescription != value) {
                    _ProductcodeDescription = value;
                    OnPropertyChanged(() => ProductcodeDescription);
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

        class ScbProductValidator : AbstractValidator<ScbProduct> {
            public ScbProductValidator() {
                //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
            }
        }

        protected override IValidator GetValidator() {
            return new ScbProductValidator();
        }

    }

}
