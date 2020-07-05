using System;
using System.Collections.Generic;
using System.Text;

namespace DSN.Common.Types
{
    public interface IPagedQuery: IQuery
    {
        int Page { get;  }
        int Results { get; }
        string OrderBy { get; }
        string SortBy { get; }
    }
}
