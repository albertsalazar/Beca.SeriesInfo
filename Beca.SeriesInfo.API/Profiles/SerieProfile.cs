using AutoMapper;

namespace Beca.SeriesInfo.API.Profiles
{
    public class SerieProfile : Profile
    {
        public SerieProfile()
        {
            CreateMap<Entities.Serie, Models.SeriesWithoutCapitulosDto>();
            CreateMap<Entities.Serie, Models.SerieDto>();
        }
    }
}
