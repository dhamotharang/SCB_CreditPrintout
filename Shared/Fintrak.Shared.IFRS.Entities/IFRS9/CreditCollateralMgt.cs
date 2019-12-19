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
    public partial class CreditCollateralMgt : EntityBase, IIdentifiableEntity
    {

        [DataMember]
        [Browsable(false)]
        public int ID { get; set; }

        [DataMember] public string DETAILS_OF_SECURITIES_OTHERS { get; set; }
        [DataMember] public double COLLATERAL_VALUE { get; set; }
        [DataMember] public string COLLATERAL_STATUS { get; set; }
        [DataMember] public string BANK_CLASSIFICATION { get; set; }
        [DataMember] public string LAST_EXAMINERS_CLASSIFICATION { get; set; }
        [DataMember] public string SCI_ID { get; set; }


        public bool Active { get; set; }

            public int EntityId{
                get{
                    return ID;
                }
            }
        }
    }
