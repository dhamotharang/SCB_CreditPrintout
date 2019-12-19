using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(ICreditCollateralMgtRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CreditCollateralMgtRepository : DataRepositoryBase<CreditCollateralMgt>, ICreditCollateralMgtRepository
    {
        protected override CreditCollateralMgt AddEntity(IFRSContext entityContext, CreditCollateralMgt entity)
        {
            return entityContext.Set<CreditCollateralMgt>().Add(entity);
        }

        protected override CreditCollateralMgt UpdateEntity(IFRSContext entityContext, CreditCollateralMgt entity)
        {
            return (from e in entityContext.Set<CreditCollateralMgt>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<CreditCollateralMgt> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<CreditCollateralMgt>()
                   select e;
        }

        protected override CreditCollateralMgt GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<CreditCollateralMgt>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<CreditCollateralMgt> GetCreditCollateralMgtBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<CreditCollateralMgt>()
                             where e.DETAILS_OF_SECURITIES_OTHERS == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<CreditCollateralMgt> GetCreditCollateralMgts(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<CreditCollateralMgt>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}