using SurisCodeTest.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurisCodeTest.Services.Validators.ReserveValidators
{
    public class ReserveValidation
    {

        private readonly IEnumerable<IReserveValidation> _reserveValidation;

        public ReserveValidation(IEnumerable<IReserveValidation> reserveValidation)
        {
            _reserveValidation = reserveValidation;
        }

        public string? Validate(Reserve reserve)
        {
            foreach (var validation in _reserveValidation)
            {
                string? validationString = validation.Validate(reserve);
                if (validationString != null)
                {
                    return validationString;
                }
            }
            return null;
        }

    }
}
