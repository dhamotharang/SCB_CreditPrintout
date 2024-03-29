using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Fintrak.Shared.Common.ServiceModel;
using Fintrak.Shared.IFRS.Framework;

namespace Fintrak.Business.IFRS.Contracts
{
    [DataContract]
    public class GLAdjustmentDataMain : DataContractBase
    {
        [DataMember]
        public int GLAdjustmentId { get; set; }

        [DataMember]
        public string AdjustmentCode { get; set; }

        [DataMember]
        public string GroupCode { get; set; }

        [DataMember]
        public int GLId { get; set; }

        [DataMember]
        public string GLCode { get; set; }

        [DataMember]
        public string GLName { get; set; }

        [DataMember]
        public string Narration { get; set; }

        [DataMember]
        public int Indicator { get; set; }

        [DataMember]
        public string IndicatorName { get; set; }

        [DataMember]
        public int AdjustmentType { get; set; }

        [DataMember]
        public string AdjustmentTypeName { get; set; }

        [DataMember]
        public int ReportType { get; set; }

        [DataMember]
        public string ReportTypeName { get; set; }


        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public int CurrencyId { get; set; }

        [DataMember]
        public string CurrencyName { get; set; }

        [DataMember]
        public DateTime RunDate { get; set; }

        [DataMember]
        public bool Posted { get; set; }


        [DataMember]
        public string CompanyCode { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string UpdatedBy { get; set; }
    }
}
