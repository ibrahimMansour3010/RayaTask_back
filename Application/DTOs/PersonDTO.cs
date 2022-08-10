using Application.DTOs.Common;
using Domain.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PersonDTO:BaseDTO
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }

        public List<AddressDTO> Address { get; set; }
    }
    public class PersonListDTO : BaseDTO
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
