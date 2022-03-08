using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public interface IBaseResource<T>
    {
        /// Create Resource
        Task<List<T>> GetResources();

        /// Create Resource
        Task<T> GetResourcesById<U>(U id);

        /// Create Resource
        Task<T> CreateResource(T resource);

        /// Update Resource
        Task<T> UpdateResource(T resource);

        // Delete Resource
        Task DeleteResource(T resource);

        /// Delete Resource permanently
        Task DeleteResourcePermanently(T resource);

        /// Restore Resource
        Task RestoreResource(T resource);

        /// List Deleted Resources
        Task<List<T>> ListDeletedResources();
    }
}
