using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using MovieAPI.Components.ExternalAPI.Clasess;

namespace MovieAPI.Components.ExternalAPI.APIs
{
    public class TheMovieDatabaseAPI : TheMovieDatabaseObject
    {
        public string Url = "http://api.themoviedb.org/";
        public string Key = "76a03d63be888eba4556bdfa733b4003";

        private HttpClient httpClient   = new HttpClient();
        private int ResponseNotFound    = 999999;
        private string UrlArguments;
        private static Local SearchedMovie;

        public static async Task<TheMovieDatabaseAPI> CreateAsync()
        {
            TheMovieDatabaseAPI api = new TheMovieDatabaseAPI();

            api.httpClient.BaseAddress = new Uri(api.Url);
            if (await api.CheckConnection())
                return api;
            return null;
        }

        private async Task<bool> CheckConnection()
        {
            await Task.Delay(0);
            return true;
        }

        internal async Task<TMDB> GetMovieById(string id)
        {
            PrependUrlArguments(
                "/3/movie/" +   id,
                AppendKey()
            );
            return ConvertToTMDB.Convert(await ParseResponse<Movie>(await GetAsync()));
        }

        internal async Task<TMDB> GetMovie(Local movie )
        {
            SearchedMovie = movie;
            PrependUrlArguments(
                "/3/search/movie",
                AppendKey("query=" + movie.Name.Replace(" ", "%20"))
            );
            Response response = await ParseResponse<Response>(await GetAsync());
            return await ParseMovieResponse(response);
        }


        internal async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            await HttpCheckHeaders(response);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        internal async Task<TMDB> ParseMovieResponse(Response response)
        {
            int id = (response != null && response.total_results == 1) ? response.results[0].id : ResponseNotFound;
            if (id != ResponseNotFound)
            {
                return await GetMovieById(Convert.ToString(id));
            }
            else
            {
                var eligable = response.results
                        .Where(x => x.release_date.Contains(SearchedMovie.Year))
                        .ToList();

                if(eligable.Count > 1)
                    eligable = eligable
                        .Where(y => y.title.ToLower() == SearchedMovie.Name.ToLower())
                        .ToList();

                if(eligable != null && eligable.Count == 1 ) 
                    return await GetMovieById(Convert.ToString(eligable.First().id));
            }
            return new TMDB();
        }

        internal string AppendKey(string param = "")
        {
            return (param != "")
                ? "?api_key=" + Key + "&" + param
                : "?api_key=" + Key;
        }

        internal void PrependUrlArguments(string arguments,string param)
        {
            UrlArguments = arguments + param;
        }

        internal async Task<HttpResponseMessage> GetAsync()
        {
            return await httpClient.GetAsync(UrlArguments,HttpCompletionOption.ResponseContentRead);
        }

        private async Task HttpCheckHeaders(HttpResponseMessage response)
        {
            int limit       = Convert.ToInt32(response.Headers.GetValues("X-Ratelimit-Limit").FirstOrDefault());
            int remaining   = Convert.ToInt32(response.Headers.GetValues("X-Ratelimit-Remaining").FirstOrDefault());
            int reset       = Convert.ToInt32(response.Headers.GetValues("X-Ratelimit-Reset").FirstOrDefault());

            if(remaining < 1)
            {
                await Task.Delay(5000);
            } 
        }

    }

    public class TheMovieDatabaseObject
    {
        internal class Response
        {
            public int? page            { get; set; }
            public int? total_results   { get; set; }
            public int? total_pages     { get; set; }
            public IList<ResponseResults> results    { get; set; }

            
        }
        internal class ResponseResults
        {
            public int id               { get; set; }
            public string title         { get; set; }
            public string release_date  { get; set; }
            public int[] genre_ids      { get; set; }
            public string poster_path   { get; set; }
        }

        internal class Movie
        {
            public int? id   { get; set; }
            public Nullable<bool> adult { get; set; }
            public string backdrop_path { get; set; }
            public string budget        { get; set; }
            public string homepage      { get; set; }
            public string imdb_id       { get; set; }
            public string original_title    { get; set; }
            public string overview      { get; set; }
            public string popularity    { get; set; }
            public string poster_path   { get; set; }
            public string release_date  { get; set; }
            public string revenue       { get; set; }
            public string status        { get; set; }
            public string tagline       { get; set; }
            public string title         { get; set; }
            public string vote_average  { get; set; }
            public string vote_count    { get; set; }
            public List<KeyValue> genres                  { get; set; }
            public List<KeyValue> production_countries    { get; set; }
            public List<KeyValue> production_companies    { get; set; }
            public List<KeyValue> spoken_languages        { get; set; }
        }

        internal class ConvertToTMDB
        {
            public static TMDB Convert(Movie data)
            {
                if (data.title == null)
                    return new TMDB();

                List<TMDBgenres> g  = new List<TMDBgenres>();
                foreach (KeyValue genre in data.genres) { g.Add(new TMDBgenres() { Id = genre.id, Name = genre.name }); }
                List<production_companies> pc = new List<production_companies>();
                foreach(KeyValue pc_ in data.production_companies) { pc.Add(new production_companies() { Id = pc_.id, Name = pc_.name }); }
                return new TMDB()
                {
                    adult           = data.adult,
                    backdrop_path   = data.backdrop_path,
                    budget          = data.budget,
                    homepage        = data.homepage,
                    id              = (int)data.id,
                    imdb_id         = data.imdb_id,
                    original_title  = data.original_title,
                    overview        = data.overview,
                    popularity      = data.popularity,
                    poster_path     = data.poster_path,
                    production_companies = pc,
                    release_date    = data.release_date,
                    revenue         = data.revenue,
                    status          = data.status,
                    tagline         = data.tagline,
                    title           = data.title,
                    TMDBgenres      = g,
                    vote_average    = data.vote_average,
                    vote_count      = data.vote_count
                };
            }
        }





    }
}