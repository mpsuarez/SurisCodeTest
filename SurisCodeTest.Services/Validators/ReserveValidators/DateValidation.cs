using SurisCodeTest.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Services.Validators.ReserveValidators
{
    public class DateValidation : IReserveValidation
    {

        public string? Validate(Reserve reserve)
        {
            return reserve.Date < DateOnly.FromDateTime(DateTime.Now) ? "Verifique la fecha" : null;
        }

    }
}
