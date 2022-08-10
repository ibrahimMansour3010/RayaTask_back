using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.DTOs;
using Application.Responses;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService: IPersonService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public PersonService(IUnitOfWork unit,IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<GeneralResponse<List<PersonListDTO>>> GetAll()
        {
            var response = new GeneralResponse<List<PersonListDTO>>();
            var persons = await _unit.PersonRepo.GetAll();
            if (persons.Any())
            {
                response.Status = true;
                response.Message = "success";
                response.Response = _mapper.Map<List<PersonListDTO>>(persons);
            }
            return response;
        }
        public async Task<GeneralResponse<PersonDTO>> Get(int Id)
        {
            var response = new GeneralResponse<PersonDTO>();
            var person = _unit.PersonRepo.GetByConditionWithInclude(i=>i.Id == Id,new List<string>() { "Addresses" }).FirstOrDefault();
            if (person != null)
            {
                response.Status = true;
                response.Message = "success";
                response.Response = _mapper.Map<PersonDTO>(person);
                if (person.Addresses.Any())
                {
                    response.Response.Address = _mapper.Map<List<AddressDTO>>(person.Addresses);
                }
            }
            return response;
        }
        public async Task<GeneralResponse<PersonDTO>> ManagePerson(PersonDTO person)
        {
            var response = new GeneralResponse<PersonDTO>();
            if(person.Id == 0) // add
            {
                var result = await _unit.PersonRepo.Add(_mapper.Map<Person>(person));
                await _unit.Save();
                if (person.Address.Any())
                {
                    foreach (var address in person.Address)
                    {
                        var addressEnitiy = _mapper.Map<Address>(address);
                        addressEnitiy.PersontId = result.Id;
                        await _unit.AddressRepo.Add(addressEnitiy);
                        await _unit.Save();
                    }
                }
                if(result != null)
                {
                    response.Status = true;
                    response.Message = "success";
                    response.Response = _mapper.Map<PersonDTO>(result);
                    return response;
                }
            }
            else
            {
                var personEntity = _unit.PersonRepo.GetByConditionWithInclude(i => i.Id == person.Id, new List<string>() { "Addresses" }).FirstOrDefault();
                _mapper.Map(person, personEntity);
                _unit.PersonRepo.Edit(personEntity);
                if (personEntity.Addresses.Any())
                {
                    _unit.AddressRepo.DeleteRange(personEntity.Addresses);
                }
                if (person.Address.Any())
                {
                    foreach (var address in person.Address)
                    {
                        var addressEnitiy = _mapper.Map<Address>(address);
                        addressEnitiy.PersontId = personEntity.Id;
                        await _unit.AddressRepo.Add(addressEnitiy);
                        await _unit.Save();
                    }
                }
                await _unit.Save();
                personEntity = _unit.PersonRepo.GetByConditionWithInclude(i => i.Id == person.Id, new List<string>() { "Addresses" }).FirstOrDefault();

                response.Status = true;
                response.Message = "success";
                response.Response = _mapper.Map<PersonDTO>(personEntity);
                return response;
            }
            response.Status = false;
            response.Message = "fail";
            return response;
        }
        public async Task<GeneralResponse<PersonDTO>> Delete(int Id)
        {
            var response = new GeneralResponse<PersonDTO>();
            var person = _unit.PersonRepo.GetByConditionWithInclude(i => i.Id == Id, new List<string>() { "Addresses" }).FirstOrDefault();
            if (person != null)
            {
                response.Status = true;
                response.Message = "success";
                response.Response = _mapper.Map<PersonDTO>(person);

                _unit.AddressRepo.DeleteRange(person.Addresses);
                _unit.PersonRepo.Delete(person);
                await _unit.Save();
            }
            return response;
        }
    }
}
