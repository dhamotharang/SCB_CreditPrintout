using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(ILoanECLResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoanECLResultRepository : DataRepositoryBase<LoanECLResult>, ILoanECLResultRepository
    {
        protected override LoanECLResult AddEntity(IFRSContext entityContext, LoanECLResult entity)
        {
            return entityContext.Set<LoanECLResult>().Add(entity);
        }

        protected override LoanECLResult UpdateEntity(IFRSContext entityContext, LoanECLResult entity)
        {
            return (from e in entityContext.Set<LoanECLResult>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<LoanECLResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<LoanECLResult>()
                   select e;
        }

        protected override LoanECLResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<LoanECLResult>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<LoanECLResult> GetLoanECLResultBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<LoanECLResult>()
                             where e.RefNo == searchParam               //orderby e.RefNo, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<LoanECLResult> GetLoanECLResults(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<LoanECLResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}