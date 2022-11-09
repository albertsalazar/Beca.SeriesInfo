using AutoMapper;
using Beca.SeriesInfo.API.Controllers;
using Beca.SeriesInfo.API.Entities;
using Beca.SeriesInfo.API.Models;
using Beca.SeriesInfo.API.Profiles;
using Beca.SeriesInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApi.Test
{
    public class SerieControllerTest : IDisposable
    {
        private SeriesController _serieController;
        private HttpContext _httpContext;
        public void Dispose()
        {

        }

        public SerieControllerTest()
        {
           
            var MockRepository = new Mock<ISerieInfoRepository>();
            var mapperConf = new MapperConfiguration(c => c.AddProfile<SerieProfile>());
            var Mapper = new Mapper(mapperConf);

            _httpContext = new DefaultHttpContext();

            MockRepository.Setup(m => m.GetSerieAsync(1, It.IsAny<bool>()))
                .ReturnsAsync(new Serie("Juego de Tronos") { Titulo = "Juego de Tronos" });
            MockRepository.Setup(m => m.GetSerieAsync(200, false))
                .ReturnsAsync((Serie)null);
            MockRepository.Setup(m => m.GetSeriesAsync(null, null, 10, 1))
                .ReturnsAsync((new List<Serie>()
                {
                    new Serie("La casa de Papel"){Descripcion="descripcion de la casa de papel",
                    Id=1},
                    new Serie("Better Call Saul"){Descripcion="descripcion de better call saul",
                    Id=2}

                }));
            _serieController = new SeriesController(MockRepository.Object, Mapper);
            _serieController.ControllerContext = new ControllerContext()
            {
                HttpContext = _httpContext
            };

               

        }
        [Fact]
        public async Task GetSeriesTest()
        {
            var series = await _serieController.GetSeries(null, null);
            Assert.True(series != null);
            
        }
        [Fact]
        public async Task GetSerieTest()
        {
            var serie = await _serieController.GetSerie(1);
            Assert.True(serie != null);
        }
        [Fact]
        public async Task GetErrorSerieDoesntExistTest()
        {
            IActionResult result = await _serieController.GetSerie(100);
            Assert.IsType<NotFoundResult>(result);
        }
    }
    
}
