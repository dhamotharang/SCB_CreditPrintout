﻿using Fintrak.Shared.IFRS.Framework;
using Fintrak.Shared.Common.Contracts;
using Fintrak.Shared.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fintrak.Shared.IFRS.Entities
{
    public partial class OdLgdComputationResult : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        [Browsable(false)]
        public int Id { get; set; }

        [DataMember] public string AccountNo { get; set; }
        [DataMember] public string Refno { get; set; }
        [DataMember] public string Producttype { get; set; }
        [DataMember] public string SubType { get; set; }
        [DataMember] public string CustomerName { get; set; }
        [DataMember] public string Currency { get; set; }
        [DataMember] public double ExchangeRate { get; set; }
        [DataMember] public DateTime date_pmt { get; set; }
        [DataMember] public double AmortizedCost_FCY { get; set; }
        [DataMember] public double AmortizedCost_LCY { get; set; }
        [DataMember] public double EIR { get; set; }
        [DataMember] public int Stage { get; set; }
        [DataMember] public DateTime MaturityDate { get; set; }
        [DataMember] public double TotalColRecAmt { get; set; }
        [DataMember] public double RecoveryRate { get; set; }
        [DataMember] public double UNSecuredRecovery { get; set; }
        [DataMember] public double TotalRecoverableAmt { get; set; }
        [DataMember] public double LGD { get; set; }


        public int EntityId {
            get {
                return Id;
            }
        }

    }
}
