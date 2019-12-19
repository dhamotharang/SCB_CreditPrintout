﻿using System;
using System.Linq;
using Fintrak.Shared.Budget.Framework.Enums;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.Budget.Entities
{
    public class OpexEntry : TransactionObjectDecimalBase
    {
        int _OpexEntryId;
        string _DefintionCode;
        string _MisCode;
        string _ItemCode;
        decimal _Cost;
        string _CurrencyCode;
        CenterTypeEnum _CenterType;
        string _Note;
        string _Year;
        string _ReviewCode;  
        bool _Active;

        public int OpexEntryId
        {
            get { return _OpexEntryId; }
            set
            {
                if (_OpexEntryId != value)
                {
                    _OpexEntryId = value;
                    OnPropertyChanged(() => OpexEntryId);
                }
            }
        }


        public string DefintionCode
        {
            get { return _DefintionCode; }
            set
            {
                if (_DefintionCode != value)
                {
                    _DefintionCode = value;
                    OnPropertyChanged(() => DefintionCode);
                }
            }
        }

        public string MisCode
        {
            get { return _MisCode; }
            set
            {
                if (_MisCode != value)
                {
                    _MisCode = value;
                    OnPropertyChanged(() => MisCode);
                }
            }
        }

        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value;
                    OnPropertyChanged(() => ItemCode);
                }
            }
        }


        public decimal Cost
        {
            get { return _Cost; }
            set
            {
                if (_Cost != value)
                {
                    _Cost = value;
                    OnPropertyChanged(() => Cost);
                }
            }
        }

        public string CurrencyCode
        {
            get { return _CurrencyCode; }
            set
            {
                if (_CurrencyCode != value)
                {
                    _CurrencyCode = value;
                    OnPropertyChanged(() => CurrencyCode);
                }
            }
        }

        public CenterTypeEnum CenterType
        {
            get { return _CenterType; }
            set
            {
                if (_CenterType != value)
                {
                    _CenterType = value;
                    OnPropertyChanged(() => CenterType);
                }
            }
        }


        public string Note
        {
            get { return _Note; }
            set
            {
                if (_Note != value)
                {
                    _Note = value;
                    OnPropertyChanged(() => Note);
                }
            }
        }


        public string ReviewCode
        {
            get { return _ReviewCode; }
            set
            {
                if (_ReviewCode != value)
                {
                    _ReviewCode = value;
                    OnPropertyChanged(() => ReviewCode);
                }
            }
        }



        public string Year
        {
            get { return _Year; }
            set
            {
                if (_Year != value)
                {
                    _Year = value;
                    OnPropertyChanged(() => Year);
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

        public string LongDescription
        {
            get
            {
                return string.Format("{0} - {1}", _DefintionCode, _MisCode);
            }
        }

        
        class OpexEntryValidator : AbstractValidator<OpexEntry>
        {
            public OpexEntryValidator()
            {
                RuleFor(obj => obj.DefintionCode).NotEmpty().WithMessage("DefintionCode is required.");
                RuleFor(obj => obj.MisCode).NotEmpty().WithMessage("MisCode is required.");
            }
        }

        protected override IValidator GetValidator()
        {
            return new OpexEntryValidator();
        }
    }
}
