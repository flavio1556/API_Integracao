using API_Integracao.Entites;

namespace API_Integracao.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Get(long Id);
        Task<List<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(long id);
        Task<bool> Exist(long id);

    }
}
