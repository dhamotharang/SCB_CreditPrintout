using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IBondsECLComputationResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BondsECLComputationResultRepository : DataRepositoryBase<BondsECLComputationResult>, IBondsECLComputationResultRepository
    {
        protected override BondsECLComputationResult AddEntity(IFRSContext entityContext, BondsECLComputationResult entity)
        {
            return entityContext.Set<BondsECLComputationResult>().Add(entity);
        }

        protected override BondsECLComputationResult UpdateEntity(IFRSContext entityContext, BondsECLComputationResult entity)
        {
            return (from e in entityContext.Set<BondsECLComputationResult>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<BondsECLComputationResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<BondsECLComputationResult>()
                   select e;
        }

        protected override BondsECLComputationResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<BondsECLComputationResult>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<BondsECLComputationResult> GetBondsECLComputationResultBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<BondsECLComputationResult>()
                             where e.Refno == searchParam
                             orderby e.date_pmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<BondsECLComputationResult> GetBondsECLComputationResults(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<BondsECLComputationResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}