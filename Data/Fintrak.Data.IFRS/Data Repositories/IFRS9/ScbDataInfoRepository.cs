using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using Fintrak.Data.IFRS.Contracts;
using Fintrak.Shared.IFRS.Entities;


using System.Data.SqlClient;
using Fintrak.Presentation.WebClient.Models;
using Fintrak.Shared.Common.Services;


namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbDataInfoRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbDataInfoRepository : DataRepositoryBase<ScbDataInfo>, IScbDataInfoRepository
    {
        protected override ScbDataInfo AddEntity(IFRSContext entityContext, ScbDataInfo entity)
        {
            return entityContext.Set<ScbDataInfo>().Add(entity);
        }

        protected override ScbDataInfo UpdateEntity(IFRSContext entityContext, ScbDataInfo entity)
        {
            return (from e in entityContext.Set<ScbDataInfo>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbDataInfo> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbDataInfo>()
                   select e;
        }

        protected override ScbDataInfo GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbDataInfo>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbDataInfo> GetScbDataInfoBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbDataInfo>()
                             where e.account_number == searchParam               //orderby e.RefNo, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbDataInfo> GetScbDataInfos(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbDataInfo>().Take(defaultCount)//.OrderBy(c => c.err) .OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


        public string[] GetScbOptionsByFilter(string filterParam) {

            var connectionString = IFRSContext.GetDataConnection();           
            var colnameList = new List<string>();  // List<string> pTypes;

            using (var con = new SqlConnection(connectionString)) {
                var cmd = new SqlCommand("scb_get_DistinctFields", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter {
                    ParameterName = "colName",
                    Value = filterParam,
                });

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read()) {
                        var colType = new KeyValueModel();
                        if (reader["colname"] != DBNull.Value)
                            colType.Value = reader["colname"].ToString();
                        colnameList.Add(colType.Value);
                    }
                    reader.Close();
                    con.Close();
                }

                con.Close();
            }
            return colnameList.ToArray();
        }



        public IEnumerable<ScbDataInfo> ExportScbDataInfo(int defaultCount, string path) {
            using (IFRSContext entityContext = new IFRSContext()) {
                if (!string.IsNullOrEmpty(path)) {
                    var query = (from e in entityContext.Set<ScbDataInfo>()
                                 select new {
                                     e.contract_no,
                                     e.account_number,
                                     BVN = e.bvn,
                                     e.customer_name,
                                     TIN = e.tin,
                                     e.facility_type,
                                     e.business_type,
                                     e.sector,
                                     e.sub_sector,
                                     e.customer_id,
                                     e.group_organization,
                                     e.date_granted,
                                     e.last_credit_date,
                                     e.expiry_date,
                                     e.sanction_date,
                                     e.previous_limit,
                                     e.repayment_frequency,
                                     e.cum_repayment_amount_due,
                                     e.cum_repayment_amount_paid,
                                     e.cum_interest_due_not_yet_paid,
                                     e.cum_principal_due_not_yet_paid,
                                     e.interest_rate,
                                     e.tenor,
                                     e.balance,
                                     e.lcy,
                                     e.details_of_securities_others,
                                     e.collateral_value,
                                     e.collateral_status,
                                     e.bank_classification,
                                     e.last_examiners_classification,
                                     e.last_audit_date,
                                     e.name_of_auditor,
                                     e.obligor_shareholder_fund,
                                     e.obligor_profit_before_tax,
                                     e.obligor_total_asset,
                                     e.ErrorMessage
                                 });

                    var ExportHandler = new ExcelService();
                    var response = ExportHandler.Export(query.ToList(), path);

                    return new List<ScbDataInfo>().Take(defaultCount).ToArray();

                    //var query = (from e in entityContext.Set<LoanECLResult>() //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                    //             select e);
                    //var ExportHandler = new ExcelService();
                    //var response = ExportHandler.Export(query.ToList(), path);

                    //return query.Take(defaultCount).ToArray();
                } else {
                    var query = (from e in entityContext.Set<ScbDataInfo>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                                 select e);

                    return query.ToArray();
                }
            }
        }

    }
}