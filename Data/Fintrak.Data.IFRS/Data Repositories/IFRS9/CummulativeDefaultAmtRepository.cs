using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(ICummulativeDefaultAmtRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CummulativeDefaultAmtRepository : DataRepositoryBase<CummulativeDefaultAmt>, ICummulativeDefaultAmtRepository
    {
        protected override CummulativeDefaultAmt AddEntity(IFRSContext entityContext, CummulativeDefaultAmt entity)
        {
            return entityContext.Set<CummulativeDefaultAmt>().Add(entity);
        }

        protected override CummulativeDefaultAmt UpdateEntity(IFRSContext entityContext, CummulativeDefaultAmt entity)
        {
            return (from e in entityContext.Set<CummulativeDefaultAmt>()
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<CummulativeDefaultAmt> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<CummulativeDefaultAmt>()
                   select e;
        }

        protected override CummulativeDefaultAmt GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<CummulativeDefaultAmt>()
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<CummulativeDefaultAmt> GetCummulativeDefaultAmtBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<CummulativeDefaultAmt>()
                            // where e.RefNo == searchParam               //orderby e.RefNo, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<CummulativeDefaultAmt> GetCummulativeDefaultAmts(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<CummulativeDefaultAmt>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}