using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IObeECLResultRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ObeECLResultRepository : DataRepositoryBase<ObeECLResult>, IObeECLResultRepository
    {
        protected override ObeECLResult AddEntity(IFRSContext entityContext, ObeECLResult entity)
        {
            return entityContext.Set<ObeECLResult>().Add(entity);
        }

        protected override ObeECLResult UpdateEntity(IFRSContext entityContext, ObeECLResult entity)
        {
            return (from e in entityContext.Set<ObeECLResult>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ObeECLResult> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ObeECLResult>()
                   select e;
        }

        protected override ObeECLResult GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ObeECLResult>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ObeECLResult> GetObeECLResultBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ObeECLResult>()
                             where e.RefNo == searchParam               //orderby e.RefNo, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ObeECLResult> GetObeECLResults(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ObeECLResult>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }


    }
}