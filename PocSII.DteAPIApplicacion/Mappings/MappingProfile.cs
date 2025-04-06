using AutoMapper;
using PocSII.DteBusinessRules.Domain;

namespace PocSII.DteAPIApplicacion.Mappings
{
   public class MappingProfile:Profile
    {
        public MappingProfile() {          
            CreateMap<ElectronicDocument, Invoice>();
    }
    }
}
