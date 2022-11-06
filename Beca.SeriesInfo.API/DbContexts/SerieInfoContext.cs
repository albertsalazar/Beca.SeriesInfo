using Beca.SeriesInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beca.SeriesInfo.API.DbContexts
{
    public class SerieInfoContext : DbContext  

    {
        public DbSet<Serie> Series { get; set; } = null!;

        public DbSet<Capitulo> Capitulos { get; set; } = null!;


        public SerieInfoContext(DbContextOptions<SerieInfoContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Serie>()
                .HasData(
                new Serie("Breaking Bad")
                {
                    Id = 1,
                    Descripcion = "Descripcion"
                },
                new Serie("The Bear")
                {
                    Id = 2,
                    Descripcion = "Descripcion"
                },
                new Serie("Bojack Horseman")
                {
                    Id = 3,
                    Descripcion = "Descripcion"
                },
                new Serie("Dark")
                {
                      Id = 4,
                      Descripcion = "Descripcion"
                });
            modelBuilder.Entity<Capitulo>()
                .HasData(
                new Capitulo("Cap 1")
                {
                    Id= 1,
                    SerieId = 1,
                    Descripcion = "Descripcion"
                },
                new Capitulo("Cap 2")
                {
                     Id = 2,
                     SerieId = 1,
                     Descripcion = "Descripcion2"
                },
                new Capitulo("Cap 1")
                {
                     Id = 3,
                     SerieId = 2,
                     Descripcion = "Descripcion3"
                },
                new Capitulo("Cap 2")
                {
                    Id = 4,
                    SerieId = 2,
                    Descripcion = "Descripcion4"
                },
                new Capitulo("Cap 1")
                {
                    Id = 5,
                    SerieId = 3,
                    Descripcion = "Descripcion5"
                }

                );
            base.OnModelCreating(modelBuilder);

        }
    }


}

