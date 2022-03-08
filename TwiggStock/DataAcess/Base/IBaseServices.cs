using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public interface IBaseServices
    {
        // Store new Resource Model
        Task CreateResource<T>(string sql, T parameters);

    }
}
