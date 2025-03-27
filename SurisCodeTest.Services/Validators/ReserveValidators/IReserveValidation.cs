using SurisCodeTest.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Services.Validators.ReserveValidators
{
    public interface IReserveValidation
    {
        string? Validate(Reserve reserve);
    }
}
