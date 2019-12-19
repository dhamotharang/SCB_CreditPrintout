using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(ICummulativeLifetimePdRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CummulativeLifetimePdRepository : DataRepositoryBase<CummulativeLifetimePd>, ICummulativeLifetimePdRepository
    {
        protected override CummulativeLifetimePd AddEntity(IFRSContext entityContext, CummulativeLifetimePd entity)
        {
            return entityContext.Set<CummulativeLifetimePd>().Add(entity);
        }

        protected override CummulativeLifetimePd UpdateEntity(IFRSContext entityContext, CummulativeLifetimePd entity)
        {
            return (from e in entityContext.Set<CummulativeLifetimePd>()
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<CummulativeLifetimePd> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<CummulativeLifetimePd>()
                   select e;
        }

        protected override CummulativeLifetimePd GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<CummulativeLifetimePd>()
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<CummulativeLifetimePd> GetCummulativeLifetimePdBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<CummulativeLifetimePd>()
                            // where e.RefNo == searchParam               //orderby e.RefNo, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<CummulativeLifetimePd> GetCummulativeLifetimePds(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<CummulativeLifetimePd>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}