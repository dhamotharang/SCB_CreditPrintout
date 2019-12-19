using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbGLBalanceRepository : IDataRepository<ScbGLBalance>{
        IEnumerable<ScbGLBalance> GetScbGLBalanceBySearch(string searchParam);
        IEnumerable<ScbGLBalance> GetScbGLBalances(int defaultCount);
    }
}
