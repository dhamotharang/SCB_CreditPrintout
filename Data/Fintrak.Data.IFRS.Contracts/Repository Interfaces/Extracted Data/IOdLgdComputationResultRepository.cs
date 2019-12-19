using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IOdLgdComputationResultRepository : IDataRepository<OdLgdComputationResult>
    {
        IEnumerable<OdLgdComputationResult> GetOdLgdComputationResultBySearch(string searchParam);
        IEnumerable<OdLgdComputationResult> GetOdLgdComputationResults(int defaultCount);
    }
}
