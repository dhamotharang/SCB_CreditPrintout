using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.Core.Entities
{
    public class UploadStatus : ObjectBase
    {
        int _ID;
        int _UploadID;
        string _UploadItem;
        string _Severity;
        bool _Status;
        bool _Active;

        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged(() => ID);
                }
            }
        }

        public int UploadID
        {
            get { return _UploadID; }
            set
            {
                if (_UploadID != value)
                {
                    _UploadID = value;
                    OnPropertyChanged(() => UploadID);
                }
            }
        }

        public string UploadItem {
            get { return _UploadItem; }
            set {
                if (_UploadItem != value) {
                    _UploadItem = value;
                    OnPropertyChanged(() => UploadItem);
                }
            }
        }

        public string Severity {
            get { return _Severity; }
            set {
                if (_Severity != value) {
                    _Severity = value;
                    OnPropertyChanged(() => Severity);
                }
            }
        }

        public bool Status {
            get { return _Status; }
            set {
                if (_Status != value) {
                    _Status = value;
                    OnPropertyChanged(() => Status);
                }
            }
        }


        public bool Active
        {
            get { return _Active; }
            set
            {
                if (_Active != value)
                {
                    _Active = value;
                    OnPropertyChanged(() => Active);
                }
            }
        }

        class UploadStatusValidator : AbstractValidator<UploadStatus>
        {
            public UploadStatusValidator()
            {
                RuleFor(obj => obj.ID).NotEmpty().WithMessage("ID must not be empty.");
            }
        }

        protected override IValidator GetValidator()
        {
            return new UploadStatusValidator();
        }
    }
}
