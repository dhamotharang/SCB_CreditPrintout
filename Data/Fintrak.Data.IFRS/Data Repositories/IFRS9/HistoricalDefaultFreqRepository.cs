using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IHistoricalDefaultFreqRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HistoricalDefaultFreqRepository : DataRepositoryBase<HistoricalDefaultFreq>, IHistoricalDefaultFreqRepository
    {
        protected override HistoricalDefaultFreq AddEntity(IFRSContext entityContext, HistoricalDefaultFreq entity)
        {
            return entityContext.Set<HistoricalDefaultFreq>().Add(entity);
        }

        protected override HistoricalDefaultFreq UpdateEntity(IFRSContext entityContext, HistoricalDefaultFreq entity)
        {
            return (from e in entityContext.Set<HistoricalDefaultFreq>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<HistoricalDefaultFreq> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<HistoricalDefaultFreq>()
                   select e;
        }

        protected override HistoricalDefaultFreq GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<HistoricalDefaultFreq>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<HistoricalDefaultFreq> GetHistoricalDefaultFreqBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<HistoricalDefaultFreq>()
                             //where e.RefNo == searchParam               //orderby e.RefNo, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<HistoricalDefaultFreq> GetHistoricalDefaultFreqs(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<HistoricalDefaultFreq>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}