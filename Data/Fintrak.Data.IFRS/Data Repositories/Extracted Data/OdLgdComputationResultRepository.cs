using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IOdLgdComputationResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OdLgdComputationResultRepository : DataRepositoryBase<OdLgdComputationResult>, IOdLgdComputationResultRepository
    {
        protected override OdLgdComputationResult AddEntity(IFRSContext entityContext, OdLgdComputationResult entity)
        {
            return entityContext.Set<OdLgdComputationResult>().Add(entity);
        }

        protected override OdLgdComputationResult UpdateEntity(IFRSContext entityContext, OdLgdComputationResult entity)
        {
            return (from e in entityContext.Set<OdLgdComputationResult>()
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<OdLgdComputationResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<OdLgdComputationResult>().Take(200)   //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                   select e;
        }

        protected override OdLgdComputationResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<OdLgdComputationResult>()
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



/*
        public IEnumerable<OdLgdComputationResultInfo> GetOdLgdComputationResults()
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = from a in entityContext.OdLgdComputationResultDataSet
                            join b in entityContext.ScheduleTypeSet on a.Schedule_Type equals b.Code
                            select new OdLgdComputationResultInfo()
                            {
                                OdLgdComputationResult = a,
                                ScheduleType = b
                            };

                return query.ToFullyLoaded();
            }
        }

*/


        public IEnumerable<OdLgdComputationResult> GetOdLgdComputationResultBySearch(string searchParam)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<OdLgdComputationResult>()
                             where e.Refno == searchParam
                             //orderby e.RefNo, e.datepmt
                             select e);

                return query.ToArray();
            }
        }

        public IEnumerable<OdLgdComputationResult> GetOdLgdComputationResults(int defaultCount)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<OdLgdComputationResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);

                return query.ToArray();
            }
        }



    }
}