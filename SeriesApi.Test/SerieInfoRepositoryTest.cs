using Beca.SeriesInfo.API.DbContexts;
using Beca.SeriesInfo.API.Entities;
using Beca.SeriesInfo.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApi.Test
{
    public class SerieInfoRepositoryTest : IDisposable
    {
        private SerieInfoRepository _serieInfoRepository;
        public void Dispose()
        {

        }
        public SerieInfoRepositoryTest()
        {
            var connection = new SqliteConnection("Data Source=SerieInfo.db");
            connection.Open();
            var optionsBuilder = new DbContextOptionsBuilder<SerieInfoContext>().UseSqlite(connection);
            var dbContext = new SerieInfoContext(optionsBuilder.Options);
            dbContext.Database.Migrate();
            _serieInfoRepository = new SerieInfoRepository(dbContext);
        }
        [Fact]
        public async void GetSeriesTest()
        {
            var series = await _serieInfoRepository.GetSeriesAsync();

            Assert.NotNull(series);
            Assert.Equal(series.Count(), 4);

          
        }
        [Fact]
        public async void GetSerieWithoutCapitulosTets()
        {
            var serie = await _serieInfoRepository.GetSerieAsync(1, false);
            Assert.NotNull(serie);
            Assert.Empty(serie.Capitulos);
        }
        [Fact]
        public async void GetSeriesWithCapitulosTest()
        {
            var serie = await _serieInfoRepository.GetSerieAsync(1, true);
            Assert.NotNull(serie);
            Assert.NotEmpty(serie.Capitulos);
        }

        [Fact]
        public async void GetSeriesByFilterTest()
        {
            string  title= "Breaking Bad";
            var series = await _serieInfoRepository.GetSeriesAsync(title, null, 1, 1);
            Assert.Equal(series.First().Titulo, title);

        }
        [Fact]
        public async void GetSeriesBySearchQueryTest()
        {
            string query = "Bear";
            var series = await _serieInfoRepository.GetSeriesAsync(null, query, 1, 1);
            Assert.Contains(query, series.First().Titulo);
        }
        [Fact]
        public async void GetCapitulosForSerieTest()
        {
            var capitulos = await _serieInfoRepository.GetCapitulosForSerieAsync(1);
            Assert.Equal(capitulos.First().SerieId,1);
        }
        [Fact]
        public async void GetCapituloForSerieTets()
        {
            var capitulo = await _serieInfoRepository.GetCapituloForSerieAsync(1, 1);
            Assert.Equal(capitulo.Id, 1);
            Assert.Equal(capitulo.SerieId, 1);
        }

        [Fact]
        public async void CreateCapituloTest()
        {
            int serieId = 1;
            Capitulo cap = new Capitulo("Jesse Pinkman")
            {
               
                SerieId = 1,
                Descripcion = "El capitulo que aparece por primera vez Jesse"
            };
            await _serieInfoRepository.AddCapituloForSerieAsync(serieId, cap);
            await _serieInfoRepository.SaveChangesAsync();
            Capitulo capitulo = await _serieInfoRepository.GetCapituloForSerieAsync(serieId, cap.Id);
            Assert.Equal(capitulo.Titulo, "Jesse Pinkman");

        }
        [Fact]
        public async void DeleteCapituloTest()
        {
            int serieId = 1;
            int capId = 6;
            Capitulo cap = await _serieInfoRepository.GetCapituloForSerieAsync(serieId, capId);
            _serieInfoRepository.DeleteCapitulo(cap);
            await _serieInfoRepository.SaveChangesAsync();
            Assert.ThrowsAsync<ArgumentNullException>(
                () => _serieInfoRepository.GetCapituloForSerieAsync(serieId, capId));

        }
            
        

    }
}
