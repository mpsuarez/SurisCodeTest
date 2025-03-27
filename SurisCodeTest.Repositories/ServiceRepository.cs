using SurisCodeTest.Persistence.Entities;
using SurisCodeTest.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Repositories
{
    public class ServiceRepository : GenericRepository<Service>
    {

        public ServiceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}
