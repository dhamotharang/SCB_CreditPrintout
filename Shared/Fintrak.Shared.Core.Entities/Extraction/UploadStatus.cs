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

namespace Fintrak.Shared.Core.Entities
{
    public partial class UploadStatus : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        [Browsable (false)]
        public int ID { get; set; }

        [DataMember] public int UploadID { get; set; }
        [DataMember] public string UploadItem { get; set; }
        [DataMember] public string Severity { get; set; }
        [DataMember] public bool Status { get; set; }

        [DataMember] public bool Active { get; set; }

        public int EntityId
        {
            get
            {
                return UploadID;
            }
        }
    }
}
