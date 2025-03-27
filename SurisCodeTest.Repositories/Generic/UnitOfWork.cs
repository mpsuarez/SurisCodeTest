using SurisCodeTest.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Repositories.Generic
{
    public class UnitOfWork : IUnitOfWork 
    {

        public SurisCodeTestDbContext Context { get; }

        public UnitOfWork(SurisCodeTestDbContext context)
        {
            Context = context;
        }

        public Task CommitAsync()
        {
            return Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

    }
}
