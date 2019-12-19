using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbExceptionRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbExceptionRepository : DataRepositoryBase<ScbException>, IScbExceptionRepository
    {
        protected override ScbException AddEntity(IFRSContext entityContext, ScbException entity)
        {
            return entityContext.Set<ScbException>().Add(entity);
        }

        protected override ScbException UpdateEntity(IFRSContext entityContext, ScbException entity)
        {
            return (from e in entityContext.Set<ScbException>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbException> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbException>()
                   select e;
        }

        protected override ScbException GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbException>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbException> GetScbExceptionBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbException>()
                             where e.REFNO == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbException> GetScbExceptions(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbException>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }



        public IEnumerable<ScbException> getExceptionMessageByFilter(string filterparam) {
            using (IFRSContext entityContext = new IFRSContext()) { 
                var query = (from e in entityContext.Set<ScbException>()
                             where e.MESSAGE == filterparam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }



    }
}