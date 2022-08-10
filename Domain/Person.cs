using Domain.Common;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Person:BaseEntityModel
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
        }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
