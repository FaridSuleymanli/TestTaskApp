using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.Models
{
    public class JsonObject
    {
        public Person[] People { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var people in this.People)
            {
                sb.AppendFormat("People:\r\n");
                sb.AppendFormat("\t FirstName: {0}\r\n", people.FirstName);
                sb.AppendFormat("\t  LastName: {0}\r\n", people.LastName);
                sb.AppendFormat("\t Address:\r\n");
                sb.AppendFormat("\t  LastName: {0}\r\n", people.Address.City);
                sb.AppendFormat("\t  LastName: {0}\r\n", people.Address.AddressLine);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
