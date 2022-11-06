using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beca.SeriesInfo.API.Entities
{
    public class Serie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [MaxLength(300)]
        public string? Descripcion { get; set; }

        public ICollection<Capitulo> Capitulos { get; set; }
            = new List<Capitulo>();

        public Serie(string titulo)
        {
            Titulo = titulo;
        }




    }
}
