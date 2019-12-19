using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbDataInfoRepository : IDataRepository<ScbDataInfo>{
        IEnumerable<ScbDataInfo> GetScbDataInfoBySearch(string searchParam);
        IEnumerable<ScbDataInfo> GetScbDataInfos(int defaultCount);
        string[] GetScbOptionsByFilter(string filterParam);
        IEnumerable<ScbDataInfo> ExportScbDataInfo(int defaultCount, string path);
    }
}
