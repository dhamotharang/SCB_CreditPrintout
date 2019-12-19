using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.MPR.Entities;
using Fintrak.Data.MPR.Contracts;

namespace Fintrak.Data.MPR
{
    [Export(typeof(IBalanceSheetThresholdRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BalanceSheetThresholdRepository : DataRepositoryBase<BalanceSheetThreshold>, IBalanceSheetThresholdRepository
    {

        protected override BalanceSheetThreshold AddEntity(MPRContext entityContext, BalanceSheetThreshold entity)
        {
            return entityContext.Set<BalanceSheetThreshold>().Add(entity);
        }

        protected override BalanceSheetThreshold UpdateEntity(MPRContext entityContext, BalanceSheetThreshold entity)
        {
            return (from e in entityContext.Set<BalanceSheetThreshold>()
                    where e.BalanceSheetThresholdId == entity.BalanceSheetThresholdId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<BalanceSheetThreshold> GetEntities(MPRContext entityContext)
        {
            return from e in entityContext.Set<BalanceSheetThreshold>()
                   select e;
        }

        protected override BalanceSheetThreshold GetEntity(MPRContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<BalanceSheetThreshold>()
                         where e.BalanceSheetThresholdId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<BalanceSheetThresholdInfo> GetBalanceSheetThresholds()
        {
            using (MPRContext entityContext = new MPRContext())
            {
                var query = from a in entityContext.BalanceSheetThresholdSet
                            join b in entityContext.ProductSet on a.ProductCode equals b.Code
                            join c in entityContext.BSCaptionSet on a.CaptionCode equals c.CaptionCode
                            select new BalanceSheetThresholdInfo()
                            {
                                BalanceSheetThreshold = a,
                                Product  = b,
                                BSCaption = c
                            };

                return query.ToFullyLoaded();
            }
        }
      
    }
}
