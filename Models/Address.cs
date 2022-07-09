using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskApp.Common;

namespace TestTaskApp.Models
{
    public class Address : BaseModel
    {
        public string City { get; set; }
        public string AddressLine { get; set; }
    }
}
