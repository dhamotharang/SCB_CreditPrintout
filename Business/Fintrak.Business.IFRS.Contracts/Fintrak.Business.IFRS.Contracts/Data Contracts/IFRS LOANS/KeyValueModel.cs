using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Fintrak.Shared.Common.ServiceModel;


namespace Fintrak.Business.IFRS.Contracts
{
    [DataContract]
    public partial class KeyvalueModel : DataContractBase
    {
        [DataMember]
        public int Key { get; set; }

        [DataMember]
        public string Value { get; set; }

    }
}
