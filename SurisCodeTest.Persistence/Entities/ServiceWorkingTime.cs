using SurisCodeTest.Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurisCodeTest.Persistence.Entities
{
    public class ServiceWorkingTime : Entity
    {
        public Guid ServiceId { get; set; }

        public Guid WorkingTimeId { get; set; }
        
        public Service Service { get; set; }

        public WorkingTime WorkingTime { get; set; }
    }
}
