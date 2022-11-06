using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beca.SeriesInfo.API.Entities
{
    public class Capitulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? Descripcion { get; set; }

        [ForeignKey("SerieId")]
        public Serie? Serie {get; set; }
        public int SerieId {get; set; }

        public Capitulo(string titulo)
        {
            Titulo = titulo;
        }
      

    }
}
