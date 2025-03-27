using SurisCodeTest.Persistence.Entities;
using SurisCodeTest.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Repositories
{
    public class WorkingTimeRepository : GenericRepository<WorkingTime>
    {
        public WorkingTimeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
    
}
