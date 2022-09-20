using API_Integracao.DTO;
using API_Integracao.Entites;
using AutoMapper;

namespace API_Integracao.Mappings
{
    public class EntityToDtoProfile :Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
            CreateMap<SkillDTO, Skill>().ReverseMap();
        }
    }
}
