using AutoMapper;
using GETRI_DFA_CountryState.DTO;
using GETRI_DFA_CountryState.Models;

namespace GETRI_DFA_CountryState.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCountryDTO, Country>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.Country));
            CreateMap<CreateStateDTO, State>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.State));
        }
    }
}
