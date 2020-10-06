using Auth0API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auth0API.Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        public IArticleRepository Article { get;  }

        public IEmployeeRepository Employee { get;  }
        /// <summary>
        /// Commit all changes made in a container.
        /// </summary>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,  
        /// then an exception is thrown
        ///</remarks>
        int Commit();

        Task<int> CommitAsync();

    }
}
