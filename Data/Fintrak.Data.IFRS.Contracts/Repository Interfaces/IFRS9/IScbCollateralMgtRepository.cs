using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbCollateralMgtRepository : IDataRepository<ScbCollateralMgt>{
        IEnumerable<ScbCollateralMgt> GetScbCollateralMgtBySearch(string searchParam);
        IEnumerable<ScbCollateralMgt> GetScbCollateralMgts(int defaultCount);
    }
}
