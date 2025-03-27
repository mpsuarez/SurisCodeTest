using SurisCodeTest.Persistence.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SurisCodeTest.Persistence.Entities
{
    public class WorkingTime : Entity
    {
        public TimeOnly Time { get; set; }

        [JsonIgnore]
        public IList<ServiceWorkingTime> ServiceWorkingTime { get; set; }
    }
}
