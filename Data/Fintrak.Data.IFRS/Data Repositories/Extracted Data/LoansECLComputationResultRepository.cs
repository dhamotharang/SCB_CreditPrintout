using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(ILoansECLComputationResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoansECLComputationResultRepository : DataRepositoryBase<LoansECLComputationResult>, ILoansECLComputationResultRepository
    {
        protected override LoansECLComputationResult AddEntity(IFRSContext entityContext, LoansECLComputationResult entity)
        {
            return entityContext.Set<LoansECLComputationResult>().Add(entity);
        }

        protected override LoansECLComputationResult UpdateEntity(IFRSContext entityContext, LoansECLComputationResult entity)
        {
            return (from e in entityContext.Set<LoansECLComputationResult>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<LoansECLComputationResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<LoansECLComputationResult>().Take(200)   //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                   select e;
        }

        protected override LoansECLComputationResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<LoansECLComputationResult>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



/*
        public IEnumerable<LoansECLComputationResultInfo> GetLoansECLComputationResults()
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = from a in entityContext.LoansECLComputationResultDataSet
                            join b in entityContext.ScheduleTypeSet on a.Schedule_Type equals b.Code
                            select new LoansECLComputationResultInfo()
                            {
                                LoansECLComputationResult = a,
                                ScheduleType = b
                            };

                return query.ToFullyLoaded();
            }
        }

*/


        public IEnumerable<LoansECLComputationResult> GetLoansECLComputationResultBySearch(string searchParam)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<LoansECLComputationResult>()
                             where e.Refno == searchParam
                             //orderby e.RefNo, e.datepmt
                             select e);

                return query.ToArray();
            }
        }

        public IEnumerable<LoansECLComputationResult> GetLoansECLComputationResults(int defaultCount)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<LoansECLComputationResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);

                return query.ToArray();
            }
        }



    }
}