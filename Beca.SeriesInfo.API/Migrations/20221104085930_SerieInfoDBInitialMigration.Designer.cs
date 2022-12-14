// <auto-generated />
using Beca.SeriesInfo.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Beca.SeriesInfo.API.Migrations
{
    [DbContext(typeof(SerieInfoContext))]
    [Migration("20221104085930_SerieInfoDBInitialMigration")]
    partial class SerieInfoDBInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Beca.SeriesInfo.API.Entities.Capitulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<int>("SerieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Capitulos");
                });

            modelBuilder.Entity("Beca.SeriesInfo.API.Entities.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Beca.SeriesInfo.API.Entities.Capitulo", b =>
                {
                    b.HasOne("Beca.SeriesInfo.API.Entities.Serie", "Serie")
                        .WithMany("Capitulos")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("Beca.SeriesInfo.API.Entities.Serie", b =>
                {
                    b.Navigation("Capitulos");
                });
#pragma warning restore 612, 618
        }
    }
}
