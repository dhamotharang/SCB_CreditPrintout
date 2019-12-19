using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbGLBalanceRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbGLBalanceRepository : DataRepositoryBase<ScbGLBalance>, IScbGLBalanceRepository
    {
        protected override ScbGLBalance AddEntity(IFRSContext entityContext, ScbGLBalance entity)
        {
            return entityContext.Set<ScbGLBalance>().Add(entity);
        }

        protected override ScbGLBalance UpdateEntity(IFRSContext entityContext, ScbGLBalance entity)
        {
            return (from e in entityContext.Set<ScbGLBalance>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbGLBalance> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbGLBalance>()
                   select e;
        }

        protected override ScbGLBalance GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbGLBalance>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbGLBalance> GetScbGLBalanceBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbGLBalance>()
                             where e.Glcode == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbGLBalance> GetScbGLBalances(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbGLBalance>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}