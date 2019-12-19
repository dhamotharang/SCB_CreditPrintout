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
    public partial class ScbGLBalance  : EntityBase, IIdentifiableEntity
    {

        [DataMember]
        [Browsable(false)]
        public int ID { get; set; }

        [DataMember] public string Glcode { get; set; }


        [DataMember] public string glcode_description { get; set; } 
        [DataMember] public string ProductCode { get; set; }

        [DataMember] public string Product_description { get; set; }

        [DataMember] public double Amount { get; set; }
        [DataMember] public DateTime ReportDate { get; set; }



        public bool Active { get; set; }

            public int EntityId{
                get{
                    return ID;
                }
            }
        }
    }
