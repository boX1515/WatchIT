using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MovieAPI.Components.ExternalAPI.APIs;
using MovieAPI.Components.Database.Controlers;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace MovieAPI.Components.ExternalAPI
{
    public class ApiManager
    {
        private APIs API    { get; set; }

        private TheMovieDatabaseAPI TheMovieDatabaseAPI;
        //private RottenTomatoAPI RottenTomatoAPI;
        private YtsAPI YtsAPI;

        private APIEntityModelContainer APIEntity;

        public enum APIs
        {
            TMDB = 0,
            YTS = 1
            //Tomato = 1
        }
        
        public static async Task<ApiManager> CreateAsync(APIs selectedApi)
        {
            ApiManager m = new ApiManager()
            {
                API = selectedApi
            };
            await m.GetAvailableApi();
            return m;
        }


        public async Task GetAvailableApi()
        {
            //READ FROM DB
            TheMovieDatabaseAPI = await TheMovieDatabaseAPI.CreateAsync();
            YtsAPI = await YtsAPI.CreateAsync();
        }

        public async Task<Movies> GetMovieMetaDataByObjectAsync(Local movie)
        {
            Movies _movie = new Movies()
            {
                Local = movie,
                TMDB = await TheMovieDatabaseAPI.GetMovie(movie),
                
            };
            _movie.YTS = await YtsAPI.GetMovieByIMDb(_movie.TMDB.imdb_id);

            //GUID
            using (MD5 md5 = MD5.Create())
            {
                _movie.Guid =  new Guid(md5.ComputeHash(Encoding.Default.GetBytes(_movie.Local.Name))).ToString();
            }

            await WriteLog(_movie, Parser.LogStatus.Info);

            return _movie;
        }

        public async Task<Movies> GetMovieMetaDataById(string id)
        {
            Movies _movie = new Movies();
            _movie.TMDB = await TheMovieDatabaseAPI.GetMovieById(id);
            if (_movie.TMDB.title != new TMDB().title)
            {
                _movie.YTS = await YtsAPI.GetMovieByIMDb(_movie.TMDB.imdb_id);
            }
            return _movie;
        }

        internal async Task WriteLog(Movies data,Parser.LogStatus status)
        {
            await Parser.WriteMovieInfo(new LogInfo()
            {
                Description = string.Format("Movie {0} object was built ", data.Local.Name),
                Info = "Movie was built",
                Type = "Building movie"
            },
            data);
                
        }
    }


}