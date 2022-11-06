using Beca.SeriesInfo.API.DbContexts;
using Beca.SeriesInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Beca.SeriesInfo.API.Services
{
    

    public class SerieInfoRepository : ISerieInfoRepository
    {
        private readonly SerieInfoContext _context;
        public SerieInfoRepository(SerieInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Capitulo?> GetCapituloForSerieAsync(int serieId, int capituloId)
        {
            return await _context.Capitulos.Where(c => c.SerieId == serieId &&
            c.Id == capituloId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Capitulo>> GetCapitulosForSerieAsync(int serieId)
        {
            return await _context.Capitulos.Where(c => c.SerieId == serieId).ToListAsync();
        }

        public async Task<Serie?> GetSerieAsync(int serieId, bool includeCapitulos)
        {
            if (includeCapitulos)
            {
                return await _context.Series.Include(s => s.Capitulos).
                    Where(c => c.Id == serieId).FirstOrDefaultAsync();
            }
            return await _context.Series.Where(s => s.Id == serieId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Serie>> GetSeriesAsync(string? titulo, string? searchQuery, int pageNumber, int pageSize)
        {
           
            var collection = _context.Series as IQueryable<Serie>;

            if (!string.IsNullOrEmpty(titulo))
            {
                titulo = titulo.Trim();
                collection = collection.Where(c => c.Titulo == titulo);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Titulo.Contains(searchQuery)
                || (a.Descripcion != null && a.Descripcion.Contains(searchQuery)));
            }
            return await collection.OrderBy(c => c.Titulo).Skip(pageSize*(pageNumber-1)).Take(pageSize).ToListAsync();

           
       
        }

        public async Task<bool> SerieExistsAsync(int serieId)
        {
            return await _context.Series.AnyAsync(s => s.Id == serieId);
        }

        public void DeleteCapitulo(Capitulo capitulo)
        {
            _context.Capitulos.Remove(capitulo);
        }

        public async Task<IEnumerable<Serie>> GetSeriesAsync()
        {
            return await _context.Series.OrderBy(s=>s.Titulo).ToListAsync();
        }

        public async Task AddCapituloForSerieAsync(int serieId, Capitulo capitulo)
        {
            var serie = await GetSerieAsync(serieId, false);
            if(serie != null)
            {
                serie.Capitulos.Add(capitulo);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
