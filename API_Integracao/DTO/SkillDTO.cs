using API_Integracao.ultis;

namespace API_Integracao.DTO
{
    public class SkillDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public EnumCommon.TypeSkill TypeSkill { get; set; }
        public EnumCommon.NivelSkill NivelSkill { get; set; }
    }
}
