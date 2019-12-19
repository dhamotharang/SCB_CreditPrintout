using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IObeLGDComptResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ObeLGDComptResultRepository : DataRepositoryBase<ObeLGDComptResult>, IObeLGDComptResultRepository
    {
        protected override ObeLGDComptResult AddEntity(IFRSContext entityContext, ObeLGDComptResult entity)
        {
            return entityContext.Set<ObeLGDComptResult>().Add(entity);
        }

        protected override ObeLGDComptResult UpdateEntity(IFRSContext entityContext, ObeLGDComptResult entity)
        {
            return (from e in entityContext.Set<ObeLGDComptResult>()
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ObeLGDComptResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ObeLGDComptResult>().Take(200)   //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                   select e;
        }

        protected override ObeLGDComptResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ObeLGDComptResult>()
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



/*
        public IEnumerable<ObeLGDComptResultInfo> GetObeLGDComptResults()
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = from a in entityContext.ObeLGDComptResultDataSet
                            join b in entityContext.ScheduleTypeSet on a.Schedule_Type equals b.Code
                            select new ObeLGDComptResultInfo()
                            {
                                ObeLGDComptResult = a,
                                ScheduleType = b
                            };

                return query.ToFullyLoaded();
            }
        }

*/

        public IEnumerable<ObeLGDComptResult> GetObeLGDComptResultBySearch(string searchParam)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<ObeLGDComptResult>()
                             where e.Refno == searchParam
                             //orderby e.RefNo, e.datepmt
                             select e);

                return query.ToArray();
            }
        }

        public IEnumerable<ObeLGDComptResult> GetObeLGDComptResults(int defaultCount)
        {
            using (IFRSContext entityContext = new IFRSContext())
            {
                var query = (from e in entityContext.Set<ObeLGDComptResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);

                return query.ToArray();
            }
        }



    }
}