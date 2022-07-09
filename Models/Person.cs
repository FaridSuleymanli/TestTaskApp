using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestTaskApp.Common;
using TestTaskApp.Services;

namespace TestTaskApp.Models
{
    public class Person : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public long? AddressId { get; set; }
        public Address Address { get; set; }
    }
}
