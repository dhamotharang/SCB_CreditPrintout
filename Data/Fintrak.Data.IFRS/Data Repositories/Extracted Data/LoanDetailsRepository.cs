using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IRawLoanDetailsRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RawLoanDetailsRepository : DataRepositoryBase<RawLoanDetails>, IRawLoanDetailsRepository
    {
        protected override RawLoanDetails AddEntity(IFRSContext entityContext, RawLoanDetails entity)
        {
            return entityContext.Set<RawLoanDetails>().Add(entity);
        }

        protected override RawLoanDetails UpdateEntity(IFRSContext entityContext, RawLoanDetails entity)
        {
            return (from e in entityContext.Set<RawLoanDetails>()
                    where e.LoanDetailId == entity.LoanDetailId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<RawLoanDetails> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<RawLoanDetails>().Take(200)
                   select e;
        }

        protected override RawLoanDetails GetEntity(IFRSContext entityContext, int loanDetailId)
        {
            var query = (from e in entityContext.Set<RawLoanDetails>()
                         where e.LoanDetailId == loanDetailId
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<RawLoanDetails> GetLoanDetailsBySearch(string searchParam)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<RawLoanDetails>()
                             where e.RefNo == searchParam || e.AccountNo == searchParam
                             select e);

                return query.ToArray();
            }
        }

        public IEnumerable<RawLoanDetails> GetLoanDetails(int defaultCount)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<RawLoanDetails>().Take(defaultCount)
                             select e);

                return query.ToArray();
            }
        }


    }
}