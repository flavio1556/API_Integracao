using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Integracao.Entites
{
    public class BaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
    }
}
