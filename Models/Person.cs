using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
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
        public Address Address { get; set; } = new Address();

        public void JsonParse(string json)
        {
            json = Regex.Replace(json, @"\s", "").Replace("{", "").Replace("}", "").Replace("'", "");

            //char[] charsToTrim = { '{', '}', '\'', '"', '{' };
            char[] charsToSplit = { ',', ':' };
            string[] arr = json.Split(charsToSplit).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case "firstName":
                        FirstName = arr[i + 1];
                        continue;

                    case "lastName":
                        LastName = arr[i + 1];
                        continue;

                    case "addressId":
                        AddressId = int.Parse(arr[i + 1]);
                        break;

                    case "city":
                        Address.City = arr[i + 1];
                        continue;

                    case "addressLine":
                        Address.AddressLine = arr[i + 1];
                        break;
                }
            }
        }
    }
}
