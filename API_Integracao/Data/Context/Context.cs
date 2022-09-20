using API_Integracao.Entites;
using Microsoft.EntityFrameworkCore;

namespace API_Integracao.Data.Context
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Person> people { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
