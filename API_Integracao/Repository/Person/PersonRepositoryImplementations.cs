using API_Integracao.Data.Context;
using API_Integracao.Entites;
using Microsoft.EntityFrameworkCore;

namespace API_Integracao.Repository.Person
{
    public class PersonRepositoryImplementations : RepositoryImplementations<API_Integracao.Entites.Person>, IPersonRepository
    {
        public PersonRepositoryImplementations(Context context) : base(context)
        {
            _dataSet = context.Set<API_Integracao.Entites.Person>();
        }

        public async Task<List<Entites.Person>> GetCompletALL()
        {
            return await _dataSet.Include(s => s.Skills).ToListAsync();
        }
    }
}
