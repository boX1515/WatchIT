using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieAPI.Components.Database.Controlers;

namespace MovieAPI.Components.ExternalAPI
{
    public class API
    {
        private ApiManager ApiManager;
        private Dictionary<Local, Movies> RetrievedMovieList;

        public static async Task<API> CreateAsync(ApiManager.APIs API)
        {
            return new API()
            {
                ApiManager = await ApiManager.CreateAsync(API)
            };
        }

        //Query list in database and find those not added
        public async Task MovieQueryAsync(List<Local> list)
        {
         
            list = await Database.Database.MovieQueryInDatabaseAsync(list);

            RetrievedMovieList = new Dictionary<Local,Movies>();
            
            foreach(Local movie in list)
            {
                if (movie.Name != null && movie.Name != "")
                {
                    RetrievedMovieList.Add(movie,await ApiManager.GetMovieMetaDataByObjectAsync(movie));
                }
            }

            
            foreach(KeyValuePair<Local,Movies> x in RetrievedMovieList)
            {
                await WriteLog(await Database.Database.MovieAdd(x), x.Value);
            }
        }

        internal async Task WriteLog(int state, Movies m)
        {
            if(state > 1)
                await Parser.WriteMovieSuccess(new LogSuccess() { Description = string.Format("Movie {0} was added succesfully", m.Local.Name), Status = "Movie was added to db", Type = "Adding movie to db" },m);

                await Parser.WriteMovieError( new LogError() { Description = string.Format("Movie {0} was added but with errors", m.Local.Name) , Error = "Movie was not added",Type = "Adding movie to db error"},m);

        }

        
    }
}