using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using Fintrak.Shared.Common.Extensions;
using Fintrak.Shared.Core.Entities;
using Fintrak.Data.Core.Contracts;
using System.Data.Entity.Infrastructure;
using Fintrak.Shared.Common.Data;

namespace Fintrak.Data.Core
{
    [Export(typeof(IUploadStatusRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class UploadStatusRepository : DataRepositoryBase<UploadStatus>, IUploadStatusRepository
    {
        protected override UploadStatus AddEntity(CoreContext entityContext, UploadStatus entity)
        {
            return entityContext.Set<UploadStatus>().Add(entity);
        }

        protected override UploadStatus UpdateEntity(CoreContext entityContext, UploadStatus entity)
        {
            return (from e in entityContext.Set<UploadStatus>()
                    where e.ID == entity.ID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<UploadStatus> GetEntities(CoreContext entityContext)
        {
            return from e in entityContext.Set<UploadStatus>()
                   select e;
        }

        protected override UploadStatus GetEntity(CoreContext entityContext, int id)
        {
            var query = (from e in entityContext.Set<UploadStatus>()
                         where e.ID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }


    }
}
