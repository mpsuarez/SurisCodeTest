using SurisCodeTest.Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurisCodeTest.Persistence.Entities
{
    public class Reserve : Entity
    {
        public DateOnly Date { get; set; }
        public Guid ServiceWorkingTimeId { get; set; }

        public string Client { get; set; }

        public ServiceWorkingTime ServiceWorkingTime { get; set; }
    }
}
