using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbCollateralMgtRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbCollateralMgtRepository : DataRepositoryBase<ScbCollateralMgt>, IScbCollateralMgtRepository
    {
        protected override ScbCollateralMgt AddEntity(IFRSContext entityContext, ScbCollateralMgt entity)
        {
            return entityContext.Set<ScbCollateralMgt>().Add(entity);
        }

        protected override ScbCollateralMgt UpdateEntity(IFRSContext entityContext, ScbCollateralMgt entity)
        {
            return (from e in entityContext.Set<ScbCollateralMgt>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbCollateralMgt> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbCollateralMgt>()
                   select e;
        }

        protected override ScbCollateralMgt GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbCollateralMgt>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbCollateralMgt> GetScbCollateralMgtBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbCollateralMgt>()
                             where e.contract_no == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbCollateralMgt> GetScbCollateralMgts(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbCollateralMgt>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}