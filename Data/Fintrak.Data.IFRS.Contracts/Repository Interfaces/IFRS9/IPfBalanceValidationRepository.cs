using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IPfBalanceValidationRepository : IDataRepository<PfBalanceValidation>{
        IEnumerable<PfBalanceValidation> GetPfBalanceValidationBySearch(string searchParam);
        IEnumerable<PfBalanceValidation> GetPfBalanceValidationList(string code, string name);
        IEnumerable<PfBalanceValidation> GetPfBalanceValidations(int defaultCount);
    }
}
