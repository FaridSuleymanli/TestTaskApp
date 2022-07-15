using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.Models
{
    public class JsonObject
    {
        public List<Person> People { get; set; }

        public override string ToString()
        {
            string bracket1 = "{\r\n";
            string bracket2 = "}\r\n";
            string comma = ",";
            StringBuilder sb = new StringBuilder();
            foreach (var people in this.People)
            {
                sb.Append(bracket1);
                sb.AppendFormat("\t id: {0}{1}\r\n", people.Id, comma);
                sb.AppendFormat("\t FirstName: {0}{1}\r\n", people.FirstName, comma);
                sb.AppendFormat("\t  LastName: {0}{1}\r\n", people.LastName, comma);
                sb.AppendFormat("\t  addressId: {0}{1}\r\n", people.AddressId, comma);
                sb.AppendFormat("\t Address:\r\n");
                sb.Append(bracket1);
                sb.AppendFormat("\t  id: {0}{1}\r\n", people.Address.Id, comma);
                sb.AppendFormat("\t  city: {0}{1}\r\n", people.Address.City, comma);
                sb.AppendFormat("\t  addressLine: {0}{1}\r\n", people.Address.AddressLine, comma);
                sb.Append(bracket2);
                sb.Append(bracket2);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
