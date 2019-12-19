using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbCreditSanctionRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbCreditSanctionRepository : DataRepositoryBase<ScbCreditSanction>, IScbCreditSanctionRepository
    {
        protected override ScbCreditSanction AddEntity(IFRSContext entityContext, ScbCreditSanction entity)
        {
            return entityContext.Set<ScbCreditSanction>().Add(entity);
        }

        protected override ScbCreditSanction UpdateEntity(IFRSContext entityContext, ScbCreditSanction entity)
        {
            return (from e in entityContext.Set<ScbCreditSanction>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbCreditSanction> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbCreditSanction>()
                   select e;
        }

        protected override ScbCreditSanction GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbCreditSanction>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbCreditSanction> GetScbCreditSanctionBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbCreditSanction>()
                             where e.Contract_number == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbCreditSanction> GetScbCreditSanctions(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbCreditSanction>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}