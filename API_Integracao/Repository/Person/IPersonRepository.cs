using API_Integracao.Entites;

namespace API_Integracao.Repository.Person
{
    public interface  IPersonRepository : IRepository<API_Integracao.Entites.Person> 
    {

        Task<List<API_Integracao.Entites.Person>> GetCompletALL();
    }
}
