using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbProductRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbProductRepository : DataRepositoryBase<ScbProduct>, IScbProductRepository
    {
        protected override ScbProduct AddEntity(IFRSContext entityContext, ScbProduct entity)
        {
            return entityContext.Set<ScbProduct>().Add(entity);
        }

        protected override ScbProduct UpdateEntity(IFRSContext entityContext, ScbProduct entity)
        {
            return (from e in entityContext.Set<ScbProduct>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbProduct> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbProduct>()
                   select e;
        }

        protected override ScbProduct GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbProduct>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbProduct> GetScbProductBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbProduct>()
                             where e.ProductCode == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbProduct> GetScbProducts(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbProduct>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}