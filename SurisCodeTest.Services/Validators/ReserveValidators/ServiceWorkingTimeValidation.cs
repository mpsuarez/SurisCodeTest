using SurisCodeTest.Persistence;
using SurisCodeTest.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Services.Validators.ReserveValidators
{
    public class ServiceWorkingTimeValidation : IReserveValidation
    {

        private readonly SurisCodeTestDbContext _context;

        public ServiceWorkingTimeValidation(SurisCodeTestDbContext context)
        {
            _context = context;
        }

        public string? Validate(Reserve reserve)
        {
            return !_context.ServiceWorkingTime.Any(x => x.Id == reserve.ServiceWorkingTimeId) ? "Ese horario no existe." : null ;
        }

    }
}
