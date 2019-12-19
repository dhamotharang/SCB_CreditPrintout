using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbCustomerInfoRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbCustomerInfoRepository : DataRepositoryBase<ScbCustomerInfo>, IScbCustomerInfoRepository
    {
        protected override ScbCustomerInfo AddEntity(IFRSContext entityContext, ScbCustomerInfo entity)
        {
            return entityContext.Set<ScbCustomerInfo>().Add(entity);
        }

        protected override ScbCustomerInfo UpdateEntity(IFRSContext entityContext, ScbCustomerInfo entity)
        {
            return (from e in entityContext.Set<ScbCustomerInfo>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbCustomerInfo> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbCustomerInfo>()
                   select e;
        }

        protected override ScbCustomerInfo GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbCustomerInfo>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbCustomerInfo> GetScbCustomerInfoBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbCustomerInfo>()
                             where e.Contract_Number == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbCustomerInfo> GetScbCustomerInfos(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbCustomerInfo>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}