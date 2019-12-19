using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbCreditSanctionRepository : IDataRepository<ScbCreditSanction>{
        IEnumerable<ScbCreditSanction> GetScbCreditSanctionBySearch(string searchParam);
        IEnumerable<ScbCreditSanction> GetScbCreditSanctions(int defaultCount);
    }
}
