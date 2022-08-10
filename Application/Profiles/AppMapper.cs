using Application.DTOs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Person, PersonListDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
