using Beca.SeriesInfo.API.Business;
using Beca.SeriesInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApi.Test
{
    public class SeriesTests
    {
        [Fact]
        public void createSerieTest()
        {
            var serieFactory = new SerieFactory();

            var serie = (Serie)serieFactory.CreateSerie("Juego de Tronos", "descripcion de la serie");

            Assert.Equal("Juego de Tronos", serie.Titulo);
            Assert.Equal("descripcion de la serie", serie.Descripcion);

        }
        [Fact]
        public void shouldNotCreateSerieTest()
        {
            string titulo = "Esto es un titulo demasiado largo para una serie porque contiene mas de 50 caracteres y esos son muchos caracteres";
            var serieFactory = new SerieFactory();
            Assert.Throws<ArgumentException>(
                () => serieFactory.CreateSerie(titulo, "descripcion"));
        }


        
    }
}
