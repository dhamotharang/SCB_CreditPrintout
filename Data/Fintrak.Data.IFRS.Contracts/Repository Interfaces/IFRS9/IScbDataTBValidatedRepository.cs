using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbDataTBValidatedRepository : IDataRepository<ScbDataTBValidated>{

        IEnumerable<ScbDataTBValidated> GetScbDataTBValidatedBySearch(string searchParam);
        IEnumerable<ScbDataTBValidated> GetScbDataTBValidateds(int defaultCount);
        IEnumerable<ScbDataTBValidated> GetScbDataTBValidatedsByRange(double minval,double maxval);
        IEnumerable<ScbDataTBValidated> ExportScbDataTBValidated(int defaultCount, string path);

        string[] GetScbDataTBOptionsByFilter(string filterParam);
    }
}
