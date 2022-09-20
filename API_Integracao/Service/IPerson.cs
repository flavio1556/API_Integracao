using API_Integracao.DTO;
using API_Integracao.Entites;
using API_Integracao.Models;

namespace API_Integracao.Service
{
    public interface IPerson
    {
        Task<Person> GetById(long Id);
        Task<List<PersonDTO>> GetAll();
        Task<Person> Post(Person person);
        Task<Person> Put(Person person);
        Task<bool> Delete(long id);
        Task<bool> Delete(PersonDeleteModels person);
    }
}
