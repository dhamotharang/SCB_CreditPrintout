using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IBondsECLResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BondsECLResultRepository : DataRepositoryBase<BondsECLResult>, IBondsECLResultRepository
    {
        protected override BondsECLResult AddEntity(IFRSContext entityContext, BondsECLResult entity)
        {
            return entityContext.Set<BondsECLResult>().Add(entity);
        }

        protected override BondsECLResult UpdateEntity(IFRSContext entityContext, BondsECLResult entity)
        {
            return (from e in entityContext.Set<BondsECLResult>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<BondsECLResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<BondsECLResult>()
                   select e;
        }

        protected override BondsECLResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<BondsECLResult>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<BondsECLResult> GetBondsECLResultBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<BondsECLResult>()
                             where e.RefNo == searchParam               //orderby e.RefNo, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<BondsECLResult> GetBondsECLResults(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<BondsECLResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}