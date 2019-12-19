using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbLimitDefRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbLimitDefRepository : DataRepositoryBase<ScbLimitDef>, IScbLimitDefRepository
    {
        protected override ScbLimitDef AddEntity(IFRSContext entityContext, ScbLimitDef entity)
        {
            return entityContext.Set<ScbLimitDef>().Add(entity);
        }

        protected override ScbLimitDef UpdateEntity(IFRSContext entityContext, ScbLimitDef entity)
        {
            return (from e in entityContext.Set<ScbLimitDef>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbLimitDef> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbLimitDef>()
                   select e;
        }

        protected override ScbLimitDef GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbLimitDef>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbLimitDef> GetScbLimitDefBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbLimitDef>()
                             where e.sci_id == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbLimitDef> GetScbLimitDefs(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbLimitDef>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}