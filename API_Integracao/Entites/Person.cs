using System.ComponentModel.DataAnnotations.Schema;

namespace API_Integracao.Entites
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("cpf")]
        public long CPF { get; set; }
        [Column("name")]
        public string Name { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
