using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MovieAPI.Components.ExternalAPI.APIs
{
    public class YtsAPI : YtsObject
    {
        public string Url = "https://yts.ag/api/v2/";
        public string Key = "";

        private HttpClient httpClient   = new HttpClient();
        private int ResponseNotFound    = 999999;

        private string UrlArguments;
        private string SearchedContent;

        public static async Task<YtsAPI> CreateAsync()
        {
            YtsAPI api = new YtsAPI();

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

        private async Task<YTS> GetMovieById(string id)
        {
            /*SearchedContent = id;
            PrependUrlArguments(
                "/3/movie/" + id,
                AppendKey()
            );
            return await ParseResponse<YTS>(await GetAsync());*/
            await Task.Delay(0);
            return new YTS();
        }

        private async Task<YTS> GetMovieByName(string name)
        {
            /*SearchedContent = name;
            PrependUrlArguments(
                "/3/search/movie",
                AppendKey("query=" + name.Replace(" ", "%20"))
            );
            Response response = await ParseResponse<Response>(await GetAsync());
            return await ParseMovieResponse(response);*/
            await Task.Delay(0);
            return new YTS();
        }

        internal async Task<YTS> GetMovieByIMDb(string imdb)
        {
            if (imdb == "" || imdb == null)
                return new YTS();

            SearchedContent = imdb;
            PrependUrlArguments("list_movies.json", "?query_term=" + imdb);
            return MovieToYTS.Convert(await ParseMovieResponse(await ParseResponse<Response>(await GetAsync())));
        }

        internal async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        internal async Task<Movie> ParseMovieResponse(Response response)
        {
            await Task.Delay(0);
            Movie movie = (response != null && response.data.movie_count == 1) ? response.data.movies.FirstOrDefault() : null;
            if(movie == null)
            {
                //select from array
                return movie;
            }
            return movie;
        }

        internal string AppendKey(string param = "")
        {
            return (param != "")
                ? "?api_key=" + Key + "&" + param
                : "?api_key=" + Key;
        }

        internal void PrependUrlArguments(string arguments, string param)
        {
            UrlArguments = arguments + param;
        }

        internal async Task<HttpResponseMessage> GetAsync()
        {
            return await httpClient.GetAsync(UrlArguments, HttpCompletionOption.ResponseContentRead);
        }
    }

    public class YtsObject
    {
        internal class Response
        {
            public string status                { get; set; }
            public string status_message        { get; set; }
            public ResponseResults data         { get; set; }
        }

        internal class ResponseResults
        {
            public int? movie_count     { get; set; }
            public int? count           { get; set; }
            public int? page_number     { get; set; }
            public List<Movie> movies   { get; set; }
        }

        internal class Movie
        {
            public int?     id                      { get; set; }
            public string   url                     { get; set; }
            public string   imdb_code               { get; set; }
            public string   title                   { get; set; }
            public string   title_english           { get; set; }
            public string   title_long              { get; set; }
            public string   slug                    { get; set; }
            public int?     year                    { get; set; }
            public double?  rating                  { get; set; }
            public int?     runtime                 { get; set; }
            public string[] genres                  { get; set; }
            public string   summary                 { get; set; }
            public string   description_full        { get; set; }
            public string   synopsis                { get; set; }
            public string   yt_trailer_code         { get; set; }
            public string   language                { get; set; }
            public string   mpa_rating              { get; set; }
            public string   background_image        { get; set; }
            public string   background_image_original { get; set; }
            public string   small_cover_image       { get; set; }
            public string   medium_cover_image      { get; set; }
            public string   large_cover_image       { get; set; }
            public string   state                   { get; set; }
            public List<torrents>    torrents       { get; set; }
            public string   date_uploaded           { get; set; }
            public float?   date_uploaded_unix      { get; set; }

        }

        /*public class Torrent
        {
            public string   url                 { get; set; }
            public string   hash                { get; set; }
            public string   quality             { get; set; }
            public float?   seeds               { get; set; }
            public float?   peers               { get; set; }
            public string   size                { get; set; }
            public float?   size_bytes          { get; set; }
            public string   date_uploaded       { get; set; }
            public int?     date_uploaded_unix  { get; set; }
        }*/


        internal class MovieToYTS
        {
            public static YTS Convert(Movie data)
            {
                if (data.title == null)
                    return new YTS();

                List<YTSgenres> g = new List<YTSgenres>();
                int count = 0;
                foreach(string genre in data.genres) { g.Add(new YTSgenres() { Id = count, Name = genre }); count++; }
                return new YTS()
                {
                    background_image    = data.background_image,
                    background_image_original   = data.background_image_original,
                    date_uploaded       = data.date_uploaded,
                    date_uploaded_unix  = (long)data.date_uploaded_unix,
                    description_full    = data.description_full,
                    YTSgenres           = g,
                    id                  = (int)data.id,
                    imdb_code           = data.imdb_code,
                    language            = data.language,
                    large_cover_image   = data.large_cover_image,
                    medium_cover_image  = data.medium_cover_image,
                    small_cover_image   = data.small_cover_image,
                    mpa_rating          = data.mpa_rating,
                    rating              = (double)data.rating,
                    runtime             = (int)data.runtime,
                    slug                = data.slug,
                    state               = data.state,
                    summary             = data.summary,
                    synopsis            = data.synopsis,
                    title               = data.title,
                    title_english       = data.title_english,
                    title_long          = data.title_long,
                    torrents            = data.torrents,
                    url                 = data.url,
                    year                = (int)data.year,
                    yt_trailer_code     = data.yt_trailer_code
                };
            }
        }





    }
}