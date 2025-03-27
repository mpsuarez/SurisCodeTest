using SurisCodeTest.Persistence;
using SurisCodeTest.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Services.Validators.ReserveValidators
{
    public class SameReserveValidation : IReserveValidation
    {

        private readonly SurisCodeTestDbContext _context;

        public SameReserveValidation(SurisCodeTestDbContext context)
        {
            _context = context;
        }

        public string? Validate(Reserve reserve)
        {
            return _context.Reserve.Any(x => x.Date == reserve.Date && x.ServiceWorkingTimeId == reserve.ServiceWorkingTimeId) ? 
                "El servicio para ese horario ya esta recervado" : null ;
        }
    }
    
}
