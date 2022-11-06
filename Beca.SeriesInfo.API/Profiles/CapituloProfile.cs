using AutoMapper;

namespace Beca.SeriesInfo.API.Profiles
{
    public class CapituloProfile : Profile
    {
        public CapituloProfile()
        {
            CreateMap<Entities.Capitulo, Models.CapituloDto>();
            CreateMap<Models.CapituloForCreationDto, Entities.Capitulo>();
            CreateMap<Models.CapituloForUpdateDto, Entities.Capitulo>();
            CreateMap<Entities.Capitulo, Models.CapituloForUpdateDto>();
        }

    }
}
