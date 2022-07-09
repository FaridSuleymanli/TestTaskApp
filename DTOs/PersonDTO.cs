using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskApp.DTOs
{
    public class PersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public long? AddressId { get; set; }
    }
}
