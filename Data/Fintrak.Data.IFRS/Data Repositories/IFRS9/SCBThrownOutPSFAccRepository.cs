using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(ISCBThrownOutPSFAccRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SCBThrownOutPSFAccRepository : DataRepositoryBase<SCBThrownOutPSFAcc>, ISCBThrownOutPSFAccRepository
    {
        protected override SCBThrownOutPSFAcc AddEntity(IFRSContext entityContext, SCBThrownOutPSFAcc entity)
        {
            return entityContext.Set<SCBThrownOutPSFAcc>().Add(entity);
        }

        protected override SCBThrownOutPSFAcc UpdateEntity(IFRSContext entityContext, SCBThrownOutPSFAcc entity)
        {
            return (from e in entityContext.Set<SCBThrownOutPSFAcc>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<SCBThrownOutPSFAcc> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<SCBThrownOutPSFAcc>()
                   select e;
        }

        protected override SCBThrownOutPSFAcc GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<SCBThrownOutPSFAcc>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<SCBThrownOutPSFAcc> GetSCBThrownOutPSFAccBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<SCBThrownOutPSFAcc>()
                             where e.PSfAccount == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<SCBThrownOutPSFAcc> GetSCBThrownOutPSFAccs(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<SCBThrownOutPSFAcc>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }

    }
}