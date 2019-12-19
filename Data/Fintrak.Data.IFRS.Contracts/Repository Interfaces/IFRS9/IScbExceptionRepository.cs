using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbExceptionRepository : IDataRepository<ScbException>{
        IEnumerable<ScbException> GetScbExceptionBySearch(string searchParam);
        IEnumerable<ScbException> getExceptionMessageByFilter(string filterParam);
        IEnumerable<ScbException> GetScbExceptions(int defaultCount);
        //string[] GetDistinctScbExpMessages();
    }
}
