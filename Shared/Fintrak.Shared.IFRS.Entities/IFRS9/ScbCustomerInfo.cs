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
    public partial class ScbCustomerInfo : EntityBase, IIdentifiableEntity
    {

        [DataMember]
        [Browsable(false)]
        public int ID { get; set; }

        [DataMember] public string Contract_Number { get; set; }
        [DataMember] public string customer_id { get; set; }
        [DataMember] public string Facility_type { get; set; }
        [DataMember] public string Sector { get; set; }
        [DataMember] public string Sub_sector { get; set; }
        [DataMember] public int Repayment_Frequency { get; set; }
        [DataMember] public string Repayment_Frequency_in_words { get; set; }
        [DataMember] public string Tin_number { get; set; }
        [DataMember] public string BVN { get; set; }


        public bool Active { get; set; }

            public int EntityId{
                get{
                    return ID;
                }
            }
        }
    }
