using System.ComponentModel.DataAnnotations;

namespace Beca.SeriesInfo.API.Models
{
    public class CapituloForCreationDto
    {
        [Required(ErrorMessage = "Debes introducir un titulo.")]
        [MaxLength(50)]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? Descripcion { get; set; }

    }
}