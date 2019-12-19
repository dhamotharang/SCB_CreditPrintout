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
    public partial class ScbDataInfo : EntityBase, IIdentifiableEntity
    {

        [DataMember]
        [Browsable(false)]
        public int ID { get; set; }

        [DataMember] public string contract_no { get; set; }
        [DataMember] public string account_number { get; set; }
        [DataMember] public string bvn { get; set; }
        [DataMember] public string customer_name { get; set; }
        [DataMember] public int tin { get; set; }
        [DataMember] public string facility_type { get; set; }
        [DataMember] public string business_type { get; set; }
        [DataMember] public string sector { get; set; }
        [DataMember] public string sub_sector { get; set; }
        [DataMember] public string customer_id { get; set; }
        [DataMember] public string group_organization { get; set; }
        [DataMember] public DateTime date_granted { get; set; }
        [DataMember] public DateTime last_credit_date { get; set; }
        [DataMember] public DateTime expiry_date { get; set; }
        [DataMember] public DateTime sanction_date { get; set; }
        [DataMember] public double previous_limit { get; set; }
        [DataMember] public string ErrorMessage { get; set; }
        [DataMember] public string repayment_frequency { get; set; }
        [DataMember] public double cum_repayment_amount_due { get; set; }
        [DataMember] public double cum_repayment_amount_paid { get; set; }
        [DataMember] public double cum_interest_due_not_yet_paid { get; set; }
        [DataMember] public double cum_principal_due_not_yet_paid { get; set; }
        [DataMember] public double interest_rate { get; set; }
        [DataMember] public double tenor { get; set; }
        [DataMember] public double balance { get; set; }
        [DataMember] public double lcy { get; set; }
        [DataMember] public string details_of_securities_others { get; set; }
        [DataMember] public double collateral_value { get; set; }
        [DataMember] public string collateral_status { get; set; }
        [DataMember] public string bank_classification { get; set; }
        [DataMember] public string last_examiners_classification { get; set; }
        [DataMember] public DateTime last_audit_date { get; set; }
        [DataMember] public string name_of_auditor { get; set; }
        [DataMember] public double obligor_shareholder_fund { get; set; }
        [DataMember] public double obligor_profit_before_tax { get; set; }
        [DataMember] public double obligor_total_asset { get; set; }


        public bool Active { get; set; }

            public int EntityId{
                get{ return ID; }
            }
        }
    }
