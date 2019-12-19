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
    public partial class PfBalanceValidation : EntityBase, IIdentifiableEntity
    {

        [DataMember]
        [Browsable(false)]
        public int ID { get; set; }

        [DataMember] public string Productcode { get; set; }
        [DataMember] public string Glcode { get; set; }
        [DataMember] public double GL_Balance { get; set; } 
        [DataMember] public double Loan_balance { get; set; } 
        [DataMember] public double Differences { get; set; }      


        public bool Active { get; set; }
    
            public int EntityId{
                get{
                    return ID;
                }
            }
        }
    }
