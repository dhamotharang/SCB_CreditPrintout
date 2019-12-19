using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(ICRLastCreditDateRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CRLastCreditDateRepository : DataRepositoryBase<CRLastCreditDate>, ICRLastCreditDateRepository
    {
        protected override CRLastCreditDate AddEntity(IFRSContext entityContext, CRLastCreditDate entity)
        {
            return entityContext.Set<CRLastCreditDate>().Add(entity);
        }

        protected override CRLastCreditDate UpdateEntity(IFRSContext entityContext, CRLastCreditDate entity)
        {
            return (from e in entityContext.Set<CRLastCreditDate>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<CRLastCreditDate> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<CRLastCreditDate>()
                   select e;
        }

        protected override CRLastCreditDate GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<CRLastCreditDate>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<CRLastCreditDate> GetCRLastCreditDateBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<CRLastCreditDate>()
                             where e.LAST_CREDIT_DATE == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<CRLastCreditDate> GetCRLastCreditDates(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<CRLastCreditDate>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}