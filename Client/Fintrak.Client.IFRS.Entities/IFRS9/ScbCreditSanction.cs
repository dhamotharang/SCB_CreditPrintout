using System;
using System.Linq;
using Fintrak.Shared.Common.Core;
using FluentValidation;

namespace Fintrak.Client.IFRS.Entities {

    public class ScbCreditSanction : ObjectBase {

        int _ID;
        string _Contract_number;
        double _PREVIOUS_LIMIT;
        double _SANCTION_LIMIT;
        string _Customer_Id;
        string _facility_type ;
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

        public string Contract_number {
            get { return _Contract_number; }
            set {
                if (_Contract_number != value) {
                    _Contract_number = value;
                    OnPropertyChanged(() => Contract_number);
                }
            }
        }


        public double PREVIOUS_LIMIT {
            get { return _PREVIOUS_LIMIT;
                }
                set {
                            if (_PREVIOUS_LIMIT != value) {
                                _PREVIOUS_LIMIT = value;
                OnPropertyChanged(() => PREVIOUS_LIMIT);
            }
                        }
                    }

                    public double SANCTION_LIMIT {
                        get { return _SANCTION_LIMIT; }
                        set {
                            if (_SANCTION_LIMIT != value) {
                                _SANCTION_LIMIT = value;
            OnPropertyChanged(() => SANCTION_LIMIT);
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


            class ScbCreditSanctionValidator : AbstractValidator<ScbCreditSanction> {
                public ScbCreditSanctionValidator() {
                    //RuleFor(obj => obj.Instrument).NotEmpty().WithMessage("Instrument is required.");        
                }
            }

            protected override IValidator GetValidator() {
                return new ScbCreditSanctionValidator();
            }

    }

}
