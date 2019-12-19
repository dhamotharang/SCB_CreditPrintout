using Fintrak.Shared.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Fintrak.Shared.IFRS.Entities;
using Fintrak.Shared.IFRS.Framework;


namespace Fintrak.Data.IFRS.Contracts
{
    public interface IScbBusinessSegmentRepository : IDataRepository<ScbBusinessSegment>{
        IEnumerable<ScbBusinessSegment> GetScbBusinessSegmentBySearch(string searchParam);
        IEnumerable<ScbBusinessSegment> GetScbBusinessSegments(int defaultCount);
    }
}
