using Beca.SeriesInfo.API.Entities;

namespace Beca.SeriesInfo.API.Services
{
    public interface ISerieInfoRepository
    {
        Task<IEnumerable<Serie>> GetSeriesAsync();
        Task<IEnumerable<Serie>> GetSeriesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        

        Task<Serie?> GetSerieAsync(int serieId, bool includeCapitulos);

        Task<IEnumerable<Capitulo>> GetCapitulosForSerieAsync(int serieId);

        Task<Capitulo?> GetCapituloForSerieAsync(int serieId, int capituloId);

        Task<bool> SerieExistsAsync(int serieId);

        Task AddCapituloForSerieAsync(int serieId, Capitulo capitulo);

        Task<bool> SaveChangesAsync();

        void DeleteCapitulo(Capitulo capitulo);
    }
}
