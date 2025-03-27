using SurisCodeTest.Persistence.Entities;
using SurisCodeTest.Repositories;
using SurisCodeTest.Repositories.Generic;
using SurisCodeTest.Services.Validators.ReserveValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Services
{
    public class ServiceService
    {

        private readonly ServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(ServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _serviceRepository.GetAllAsync();
        }

    }
}
