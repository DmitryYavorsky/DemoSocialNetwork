using System;
using System.Collections.Generic;
using System.Text;
using DSN.Common.Types;

namespace DSN.Common.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery: IQuery
    {
    }
}
