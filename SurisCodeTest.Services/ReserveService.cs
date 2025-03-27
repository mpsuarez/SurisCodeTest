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

    public class ReserveService
    {
        private readonly ReserveRepository _reserveRepository;
        private readonly ReserveValidation _reserveValidator;
        private readonly IUnitOfWork _unitOfWork;

        public ReserveService(ReserveRepository reserveRepository, ReserveValidation reserveValidator, IUnitOfWork unitOfWork)
        {
            _reserveRepository = reserveRepository;
            _reserveValidator = reserveValidator;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Reserve>> GetAllReservesAsync()
        {
            return await _reserveRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Reserve>> GetAllReservesforListAsync()
        {
            return await _reserveRepository.GetAllReservesforListAsync();
        }

        public async Task<Reserve> GetReserveByIdAsync(Guid id)
        {
            var reserves = await _reserveRepository.GetAsync(x => x.Id == id);
            return reserves.Single();
        }

        public async Task<string?> CreateReserveAsync(Reserve reserve)
        {
            string? validationString = _reserveValidator.Validate(reserve);
            if (validationString == null)
            {

                await _reserveRepository.AddAsync(reserve);
                await _unitOfWork.CommitAsync();
                return null;
            }
            return validationString;
        }

    }
}
