using Fintrak.Shared.IFRS.Framework;
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
    public partial class ScbCreditSanction  : EntityBase, IIdentifiableEntity
    {

        [DataMember]
        [Browsable(false)]
        public int ID { get; set; }

        [DataMember] public string Contract_number { get; set; }
        [DataMember] public double SANCTION_LIMIT { get; set; }
        [DataMember] public double PREVIOUS_LIMIT { get; set; }
        [DataMember] public string Customer_Id { get; set; }
        [DataMember] public string facility_type { get; set; }
        [DataMember] public string sector { get; set; }
        [DataMember] public string subsector { get; set; }

        public bool Active { get; set; }

                public int EntityId{
                    get{
                        return ID;
                    }
                }
            }
        }
