using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Data.IFRS.Contracts;

namespace Fintrak.Data.IFRS
{
    [Export(typeof(IScbBusinessSegmentRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ScbBusinessSegmentRepository : DataRepositoryBase<ScbBusinessSegment>, IScbBusinessSegmentRepository
    {
        protected override ScbBusinessSegment AddEntity(IFRSContext entityContext, ScbBusinessSegment entity)
        {
            return entityContext.Set<ScbBusinessSegment>().Add(entity);
        }

        protected override ScbBusinessSegment UpdateEntity(IFRSContext entityContext, ScbBusinessSegment entity)
        {
            return (from e in entityContext.Set<ScbBusinessSegment>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ScbBusinessSegment> GetEntities(IFRSContext entityContext)
        {
            return from e in entityContext.Set<ScbBusinessSegment>()
                   select e;
        }

        protected override ScbBusinessSegment GetEntity(IFRSContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<ScbBusinessSegment>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }



        /////////////////////////////////////////// Methods from IRepo..

        public IEnumerable<ScbBusinessSegment> GetScbBusinessSegmentBySearch(string searchParam) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbBusinessSegment>()
                             where e.cust_code == searchParam  //orderby e.RunDate //, e.datepmt                             
                             select e);
                return query.ToArray();
            }
        }

        public IEnumerable<ScbBusinessSegment> GetScbBusinessSegments(int defaultCount) {
            using (IFRSContext entityContext = new IFRSContext()) {
                var query = (from e in entityContext.Set<ScbBusinessSegment>().Take(defaultCount) //.OrderBy(c => c.RefNo).ThenBy(c => c.datepmt)
                             select e);
                return query.ToArray();
            }
        }

    }
}