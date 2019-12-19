using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IODEclComputationResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ODEclComputationResultRepository : DataRepositoryBase<ODEclComputationResult>, IODEclComputationResultRepository
    {
        protected override ODEclComputationResult AddEntity(IFRSContext entityContext, ODEclComputationResult entity)
        {
            return entityContext.Set<ODEclComputationResult>().Add(entity);
        }

        protected override ODEclComputationResult UpdateEntity(IFRSContext entityContext, ODEclComputationResult entity)
        {
            return (from e in entityContext.Set<ODEclComputationResult>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ODEclComputationResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ODEclComputationResult>().Take(200)   //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                   select e;
        }

        protected override ODEclComputationResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ODEclComputationResult>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



/*
        public IEnumerable<ODEclComputationResultInfo> GetODEclComputationResults()
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = from a in entityContext.ODEclComputationResultDataSet
                            join b in entityContext.ScheduleTypeSet on a.Schedule_Type equals b.Code
                            select new ODEclComputationResultInfo()
                            {
                                ODEclComputationResult = a,
                                ScheduleType = b
                            };

                return query.ToFullyLoaded();
            }
        }

*/

        public IEnumerable<ODEclComputationResult> GetODEclComputationResultBySearch(string searchParam)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<ODEclComputationResult>()
                             where e.Refno == searchParam
                             //orderby e.RefNo, e.datepmt
                             select e);

                return query.ToArray();
            }
        }

        public IEnumerable<ODEclComputationResult> GetODEclComputationResults(int defaultCount)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<ODEclComputationResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);

                return query.ToArray();
            }
        }



    }
}