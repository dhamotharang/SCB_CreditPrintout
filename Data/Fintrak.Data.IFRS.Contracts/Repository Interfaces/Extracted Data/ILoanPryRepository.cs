using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface ILoanPryRepository : IDataRepository<LoanPry>
    {
        IEnumerable<LoanPry> GetPryLoanBySearch(string searchParam);
        IEnumerable<LoanPryInfo> GetLoanPrys();
        IEnumerable<LoanPry> GetPryLoans(int defaultCount);
    }
}
