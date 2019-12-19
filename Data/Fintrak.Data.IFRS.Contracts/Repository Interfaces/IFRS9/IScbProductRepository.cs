using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbProductRepository : IDataRepository<ScbProduct>{
        IEnumerable<ScbProduct> GetScbProductBySearch(string searchParam);
        IEnumerable<ScbProduct> GetScbProducts(int defaultCount);
    }
}
