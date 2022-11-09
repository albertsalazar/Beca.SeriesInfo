using Beca.SeriesInfo.API.Entities;

namespace Beca.SeriesInfo.API.Business
{
    public class SerieFactory
    {
        public virtual Serie CreateSerie(string titulo, string descripcion)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                throw new ArgumentException($"{nameof(titulo)} cannot be null or empty.");
            }
            if (titulo.Length > 50)
            {
              
               throw new ArgumentException($"{nameof(titulo)} cannot be longer than 50 characters.");
            }
            if (descripcion.Length > 300)
            {
                throw new ArgumentException($"{nameof(descripcion)} cannot be longer than 300 characters.");
            }

            
            return new Serie(titulo, descripcion);
        }
    }
}
