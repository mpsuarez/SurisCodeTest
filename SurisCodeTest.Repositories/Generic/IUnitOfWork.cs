using SurisCodeTest.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Repositories.Generic
{
    public interface IUnitOfWork : IDisposable
    {

        SurisCodeTestDbContext Context { get; }

        Task CommitAsync();

    }
}
