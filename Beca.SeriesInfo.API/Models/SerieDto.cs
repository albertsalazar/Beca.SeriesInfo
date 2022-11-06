using Beca.SeriesInfo.API.Entities;

namespace Beca.SeriesInfo.API.Models
{
    public class SerieDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }  
        public int NumeroDeCapitulos
        {
            get
            {
                return Capitulos.Count;
            }
        }
        public ICollection<CapituloDto> Capitulos { get; set; }
            = new List<CapituloDto>();
    }
}
