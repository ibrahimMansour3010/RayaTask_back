using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AddressDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public int PersontId { get; set; }
    }
}
