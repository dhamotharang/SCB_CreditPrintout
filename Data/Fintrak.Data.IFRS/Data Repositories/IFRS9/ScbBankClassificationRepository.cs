using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbBankClassificationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbBankClassificationRepository : DataRepositoryBase<ScbBankClassification>, IScbBankClassificationRepository
    {
        protected override ScbBankClassification AddEntity(IFRSContext entityContext, ScbBankClassification entity)
        {
            return entityContext.Set<ScbBankClassification>().Add(entity);
        }

        protected override ScbBankClassification UpdateEntity(IFRSContext entityContext, ScbBankClassification entity)
        {
            return (from e in entityContext.Set<ScbBankClassification>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbBankClassification> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbBankClassification>()
                   select e;
        }

        protected override ScbBankClassification GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbBankClassification>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbBankClassification> GetScbBankClassificationBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbBankClassification>()
                             where e.contract_no == searchParam 
                             //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbBankClassification> GetScbBankClassifications(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbBankClassification>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}