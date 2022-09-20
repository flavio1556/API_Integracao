using API_Integracao.DTO;
using API_Integracao.Entites;
using API_Integracao.Models;
using API_Integracao.Repository.Person;
using AutoMapper;

namespace API_Integracao.Service
{
    public class PersonImplementations : IPerson
    {
        private readonly IPersonRepository _repositoy;
        private readonly IMapper _mapper;
        public PersonImplementations(IPersonRepository repositoy, IMapper mapper)
        {
            _repositoy = repositoy;
            _mapper = mapper;
        }

        public async Task<Person> GetById(long Id)
        {
            try
            {
                return await _repositoy.Get(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<PersonDTO>> GetAll()
        {
            try
            {
                var result = await _repositoy.GetCompletALL();
                var resultDto = _mapper.Map<List<PersonDTO>>(result);
                return resultDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Person> Post(Person person)
        {
            try
            {
               return await _repositoy.Create(person);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Person> Put(Person person)
        {
            try
            {
               return await _repositoy.Update(person);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
               return await _repositoy.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(PersonDeleteModels person)
        {
            try
            {
                bool existe = await _repositoy.Exist(person.Id);
                if (!existe) return false;

                return await _repositoy.Delete(person.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
