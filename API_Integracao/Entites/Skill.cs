using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API_Integracao.ultis;
namespace API_Integracao.Entites
{
    [Table("skill")]
    public class Skill : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("type_skill")]
        public EnumCommon.TypeSkill TypeSkill { get; set; }
        [Column("nivelskill")]
        public EnumCommon.NivelSkill NivelSkill { get; set; }


        public int PersonId { get; set; }
        public Person Persons { get; set; }

    }
}
