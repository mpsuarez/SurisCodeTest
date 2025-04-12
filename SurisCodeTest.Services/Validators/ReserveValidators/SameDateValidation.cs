using SurisCodeTest.Persistence;
using SurisCodeTest.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Services.Validators.ReserveValidators
{
    public class SameDateValidation : IReserveValidation
    {

        private readonly SurisCodeTestDbContext _context;

        public SameDateValidation(SurisCodeTestDbContext context)
        {
                _context = context;
        }

        public string? Validate(Reserve reserve)
        {
            return _context.Reserve.Any(x => x.Date == reserve.Date && x.Client == reserve.Client) ? "Ya existe una reserva para esa fecha para ese cliente" : null;
        }
    }
}
