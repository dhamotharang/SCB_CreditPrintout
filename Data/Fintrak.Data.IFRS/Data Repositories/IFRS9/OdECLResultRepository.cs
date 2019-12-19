using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IOdECLResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OdECLResultRepository : DataRepositoryBase<OdECLResult>, IOdECLResultRepository
    {
        protected override OdECLResult AddEntity(IFRSContext entityContext, OdECLResult entity)
        {
            return entityContext.Set<OdECLResult>().Add(entity);
        }

        protected override OdECLResult UpdateEntity(IFRSContext entityContext, OdECLResult entity)
        {
            return (from e in entityContext.Set<OdECLResult>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<OdECLResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<OdECLResult>()
                   select e;
        }

        protected override OdECLResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<OdECLResult>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<OdECLResult> GetOdECLResultBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<OdECLResult>()
                             where e.RefNo == searchParam               //orderby e.RefNo, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<OdECLResult> GetOdECLResults(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<OdECLResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}