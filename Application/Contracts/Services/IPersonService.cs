using Application.DTOs;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface IPersonService
    {
        Task<GeneralResponse<List<PersonListDTO>>> GetAll();
        Task<GeneralResponse<PersonDTO>> Get(int Id);
        Task<GeneralResponse<PersonDTO>> ManagePerson(PersonDTO person);
        Task<GeneralResponse<PersonDTO>> Delete(int Id);
    }
}
