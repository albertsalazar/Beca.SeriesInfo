using AutoMapper;
using Beca.SeriesInfo.API.Models;
using Beca.SeriesInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Beca.SeriesInfo.API.Controllers
{
    [ApiController]
    [Route("api/series")]
    public class SeriesController : ControllerBase
    {
        private readonly ISerieInfoRepository _serieInfoRepository;
        private readonly IMapper _mapper;
        const int maxSeriesPageSize = 20;

        public SeriesController(ISerieInfoRepository serieInfoRepository, IMapper mapper)
        {
            _serieInfoRepository = serieInfoRepository ??
                throw new ArgumentNullException(nameof(serieInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeriesWithoutCapitulosDto>>> GetSeries(string? titulo, string? searchQuery, int pageNumber=1, int pageSize=10)
        {
            if(pageSize > maxSeriesPageSize)
            {
                pageSize = maxSeriesPageSize;
            }
            var serieEntities = await _serieInfoRepository.GetSeriesAsync(titulo, searchQuery, pageNumber, pageSize);
           
            return Ok(_mapper.Map<IEnumerable<SeriesWithoutCapitulosDto>>(serieEntities));
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerie( int id, bool includeCapitulos = false)
        {
            var serie = await _serieInfoRepository.GetSerieAsync(id, includeCapitulos);
            if( serie == null)
            {
                return NotFound();
            }
            if (includeCapitulos)
            {
                return Ok(_mapper.Map<SerieDto>(serie));
            }
            return Ok(_mapper.Map<SeriesWithoutCapitulosDto>(serie));

        }
        

    }
}
