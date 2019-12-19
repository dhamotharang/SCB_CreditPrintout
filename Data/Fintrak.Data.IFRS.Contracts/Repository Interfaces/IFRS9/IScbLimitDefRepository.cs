using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbLimitDefRepository : IDataRepository<ScbLimitDef>{
        IEnumerable<ScbLimitDef> GetScbLimitDefBySearch(string searchParam);
        IEnumerable<ScbLimitDef> GetScbLimitDefs(int defaultCount);
        //string[] GetDistinctScbExpMessages();
    }
}
