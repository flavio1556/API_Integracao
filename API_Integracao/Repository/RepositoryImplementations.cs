using API_Integracao.Data.Context;
using API_Integracao.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API_Integracao.Repository
{
    public class RepositoryImplementations<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Context _context ;
        protected DbSet<T> _dataSet;
        public RepositoryImplementations(Context context)
        {
            _context = context;
            _dataSet = context.Set<T>();    
        }
        public async Task<T> Get(long Id)
        {
            try
            {
                var result = await _dataSet.Include(b => b.Id).FirstOrDefaultAsync(x => x.Id == Id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var result = await _dataSet.Include(b => b.Id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                _dataSet.Add(entity);
                await Save();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                var resultAtual = await this.Get(entity.Id);
                if(resultAtual == null) return null;
                _dataSet.Update(resultAtual).CurrentValues.SetValues(entity);
                await Save();
                return entity;
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
                if (id == 0 || ! await this.Exist(id)) return false;
                var resultAtual = await this.Get(id);                
                 _dataSet.Remove(resultAtual);
                await Save();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Exist(long id)
        {

            var result = await _dataSet.AnyAsync(x => x.Id == id);
            return result;
        }
        
        
        private async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
