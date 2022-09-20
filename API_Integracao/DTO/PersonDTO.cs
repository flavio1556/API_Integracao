namespace API_Integracao.DTO
{
    public class PersonDTO
    {
        public long Id  { get; set; }
        public long CPF { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }       
        public List<SkillDTO> Skills { get; set; }
    }
}
