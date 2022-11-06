using AutoMapper;
using Beca.SeriesInfo.API.Models;
using Beca.SeriesInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Beca.SeriesInfo.API.Controllers
{
    [Route("api/series/{serieId}/capitulos")]
    [ApiController]
    public class CapitulosController : ControllerBase
    {
        private readonly ISerieInfoRepository _serieInfoRepository;
        private readonly IMapper _mapper;
        public CapitulosController(ISerieInfoRepository serieInfoRepository, IMapper mapper)
        {
            _serieInfoRepository = serieInfoRepository ?? throw new ArgumentNullException(nameof(serieInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapituloDto>>> GetCapitulos(int serieId)
        {
            if (!await _serieInfoRepository.SerieExistsAsync(serieId))
            {
                return NotFound();
            }
            var capitulosForSerie = await _serieInfoRepository.GetCapitulosForSerieAsync(serieId);

            return Ok(_mapper.Map<IEnumerable<CapituloDto>>(capitulosForSerie));

        }
        [HttpGet("{capituloId}", Name = "GetCapitulo")]
        public async Task<ActionResult<CapituloDto>> GetCapitulo(int serieId, int capituloId)
        {
            if (!await _serieInfoRepository.SerieExistsAsync(serieId))
            {
                return NotFound();
            }

            var capitulo = await _serieInfoRepository.GetCapituloForSerieAsync(serieId, capituloId);
            if (capitulo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CapituloDto>(capitulo));

        }

        [HttpPost]
        public async Task<ActionResult<CapituloDto>> CreateCapitulo(int serieId, CapituloForCreationDto capitulo)
        {

            if (!await _serieInfoRepository.SerieExistsAsync(serieId))
            {
                return NotFound();
            }
            var finalCapitulo = _mapper.Map<Entities.Capitulo>(capitulo);
            await _serieInfoRepository.AddCapituloForSerieAsync(serieId, finalCapitulo);
            await _serieInfoRepository.SaveChangesAsync();

            var createdCapituloToReturn =
                _mapper.Map<Models.CapituloDto>(finalCapitulo);

            return CreatedAtRoute("GetCapitulo",
                new
                {
                    serieId = serieId,
                    capituloId = createdCapituloToReturn.Id
                },
                createdCapituloToReturn);
        }
        [HttpPutAttribute("{capituloId}")]
        public async Task<ActionResult> UpdateCapitulo(int serieId, int capituloId, CapituloForUpdateDto capitulo)
        {
            if(!await _serieInfoRepository.SerieExistsAsync(serieId))
            {
                return NotFound();
            }
            var capituloEntity = await _serieInfoRepository.GetCapituloForSerieAsync(serieId, capituloId);
            if(capituloEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(capitulo, capituloEntity);

            await _serieInfoRepository.SaveChangesAsync();

            return NoContent();
        }
        /*
        [HttpPatch("{capituloId}")]
        public async Task<ActionResult> PartiallyUpdateCapitulo(int serieId, int capituloId, JsonPatchDocument<CapituloForUpdateDto> patchDocument)
        {
            if(!await _serieInfoRepository.SerieExistsAsync(serieId))
            {
                return NotFound();
            }
            var capituloEntity = await _serieInfoRepository.GetCapituloForSerieAsync(serieId, capituloId);
            if(capituloEntity == null)
            {
                return NotFound();
            }

            var capituloToPatch = _mapper.Map<CapituloForUpdateDto>(capituloEntity);

            patchDocument.ApplyTo(capituloToPatch);

            _mapper.Map(capituloToPatch, capituloEntity);
            await _serieInfoRepository.SaveChangesAsync();

            return NoContent();     
        }
        */

        [HttpDelete("{capituloId}")]
        public async Task<ActionResult> DeleteCapitulo(int serieId, int capituloId)
        {
            if(!await _serieInfoRepository.SerieExistsAsync(serieId))
            {
                return NotFound();
            }
            var capituloEntity = await _serieInfoRepository.GetCapituloForSerieAsync(serieId, capituloId);
            if(capituloEntity == null)
            {
                return NotFound();
            }

            _serieInfoRepository.DeleteCapitulo(capituloEntity);
            await _serieInfoRepository.SaveChangesAsync();
            return NoContent();
        }
        
        
    }
}
