using Fintrak.Shared.Core.Entities;
using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Fintrak.Data.Core.Contracts
{
    public interface IUploadStatusRepository : IDataRepository<UploadStatus>{
        //IEnumerable<UploadStatusInfo> GetUploadStatuss();
        //void UploadStatusData(string actionName, SqlParameter[] parameters);
    }
}
