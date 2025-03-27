using SurisCodeTest.Persistence.Entities;
using SurisCodeTest.Repositories;
using SurisCodeTest.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Services
{
    public class ServiceWorkingTimeService
    {

        private readonly ServiceWorkingTimeRepository _serviceWorkingTimeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceWorkingTimeService(ServiceWorkingTimeRepository serviceWorkingTimeRepository, IUnitOfWork unitOfWork)
        {
            _serviceWorkingTimeRepository = serviceWorkingTimeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ServiceWorkingTime>> GetServiceWorkingTimesByServiceIdAsync(Guid serviceId)
        {
            return await _serviceWorkingTimeRepository.GetServiceWorkingTimesByServiceIdAsync(serviceId);
        }

    }
}
