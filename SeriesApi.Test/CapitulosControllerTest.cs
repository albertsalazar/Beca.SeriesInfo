using AutoMapper;
using Beca.SeriesInfo.API.Controllers;
using Beca.SeriesInfo.API.Entities;
using Beca.SeriesInfo.API.Profiles;
using Beca.SeriesInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeriesApi.Test
{
    public class CapitulosControllerTest
    {
        private CapitulosController _capitulosController;
        private HttpContext _httpContext;

        public CapitulosControllerTest()
        {

            var MockRepository = new Mock<ISerieInfoRepository>();

            var mapperConf = new MapperConfiguration(c => c.AddProfile<CapituloProfile>());
            var mapper = new Mapper(mapperConf);

            _httpContext = new DefaultHttpContext();

            MockRepository.Setup(m => m.GetSerieAsync(1, It.IsAny<bool>()))
                        .ReturnsAsync(new Serie("The Bear") { Descripcion = "Descripcion de the bear" });
            MockRepository.Setup(m => m.SerieExistsAsync(1))
                    .ReturnsAsync(true);
            MockRepository.Setup(m => m.SerieExistsAsync(100))
                        .ReturnsAsync(false);
            MockRepository.Setup(m => m.GetCapitulosForSerieAsync(1))
                        .ReturnsAsync((new List<Capitulo>() {
                        new Capitulo("Capitulo 1") { Descripcion = "Descripcion del capitulo 1" },
                        new Capitulo("Capitulo 2") { Descripcion = "Descripcion del capitulo 2" } }
                        ));

            MockRepository.Setup(m => m.GetCapituloForSerieAsync(1, 1))
                    .ReturnsAsync(new Capitulo("Capitulo 1") { Descripcion = "Descripcion del capitulo 1" });

            _capitulosController = new CapitulosController(MockRepository.Object, mapper);

            _capitulosController.ControllerContext = new ControllerContext()
            {
                HttpContext = _httpContext,
            };


        }
        [Fact]
        public async void GetCapitulosTest()
        {
            int serieId = 1;
            var result = await _capitulosController.GetCapitulos(serieId);
            Assert.NotNull(result);
        }
        [Fact]
        public async void GetCapituloTest()
        {
            int serieId = 1;
            int capituloId = 1;
            var result = await _capitulosController.GetCapitulo(serieId, capituloId);
            Assert.NotNull(result);
        }
      
    }
}
