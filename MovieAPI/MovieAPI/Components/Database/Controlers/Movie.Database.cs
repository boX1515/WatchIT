using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieAPI.Components.Database.Controlers
{
    public class Movie : Database
    {

        internal static async Task<List<Movies>> ByIdAsync(string v)
        {
            return await APIEntity.MoviesSet.Where(x => x.Guid == v && x.TMDB.imdb_id != null || x.YTS.title != null).ToListAsync();
        }

        internal static async Task<Movies[]> ByNameAsync(string v)
        {
            /*return await APIEntity.MoviesSet.Where(
                x => 
                    (x.Local.Name.ToLower() == v.ToLower() || x.Local.Name.ToLower().CompareTo(v.ToLower()) == 0) 
                    && x.TMDB.imdb_id != null || x.YTS.title != null
                )
                .ToListAsync();*/

            return await APIEntity.MoviesSet.Where(
                x =>
                    (x.Local.Name.ToLower() == v.ToLower())
                    && x.TMDB.imdb_id != null || x.YTS.title != null
                )
                .ToArrayAsync();
        }
        
        internal static async Task<List<Movies>> ByYearAsync(string v)
        {
            return await APIEntity.MoviesSet.Where(x => x.Local.Year == v && x.TMDB.imdb_id != null || x.YTS.title != null).ToListAsync();
        }

        internal static async Task<List<Movies>> ByQualityAsync(string v)
        {
            return await APIEntity.MoviesSet.Where(x => x.Local.Pixelsize == v && x.TMDB.imdb_id != null || x.YTS.title != null ).ToListAsync();
        }
    }
}