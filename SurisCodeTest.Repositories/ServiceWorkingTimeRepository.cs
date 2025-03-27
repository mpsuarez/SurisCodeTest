using Microsoft.EntityFrameworkCore;
using SurisCodeTest.Persistence.Entities;
using SurisCodeTest.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Repositories
{
    public class ServiceWorkingTimeRepository : GenericRepository<ServiceWorkingTime>
    {

        private readonly IUnitOfWork _unitOfWork;

        public ServiceWorkingTimeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ServiceWorkingTime>> GetServiceWorkingTimesByServiceIdAsync(Guid serviceId)
        {
            return await _unitOfWork.Context.ServiceWorkingTime.Include(x => x.WorkingTime).Where(x => x.ServiceId == serviceId).ToListAsync();
        }

    }
}
