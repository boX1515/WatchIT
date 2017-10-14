using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MovieAPI.Components.ExternalAPI;
using MovieAPI.Components.Database.Controlers;

namespace MovieAPI.Components.FileScanner
{
    public class Scanner
    {
        private List<Local> MovieList { get; set; }
        private List<string> MovieListDirectories;
        private int TimeoutDelay = 60000; //1000 = 1s

        //API
        private Dictionary<ApiManager.APIs,API> Api;
        private API DatabaseApi;

        //Directory
        public string CurrentDirectory;
        public string[] CurrentDirectoryList;
        public string CurrentScannedDirectory;

        private Scanner()
        {
            MovieList = new List<Local>();
            MovieListDirectories = new List<string>();
        }

        public static async Task<List<Local>> CreateAsync()
        {
            Scanner s = new Scanner();
            if(await s.CheckAPI())
            {
                await s.Initialize();
            }
            else
            {
                //DISPLAY ERROR

            }
            return s.MovieList;

        }

        private async Task<bool> CheckAPI()
        {
            Api = new Dictionary<ApiManager.APIs, API>()
            {
                { ApiManager.APIs.TMDB, await API.CreateAsync(ApiManager.APIs.TMDB) },
                //{ ApiManager.APIs.Tomato, await API.CreateAsync(ApiManager.APIs.Tomato)}
            };

            DatabaseApi = Api.Where(x => x.Value != null).First().Value;
            if (DatabaseApi != null)
                return true;
            return false;
        }

        private async Task Initialize()
        {
            await GetRootDirectories();
            if (MovieListDirectories.Count == 0)
                return;

            await FindNew();
        }

        private async Task FindNewScan()
        {
            while (true)
            {
                await FindNew();
                await Task.Delay(TimeoutDelay);
            }
        }

        private async Task FindNew()
        {
            MovieList = new List<Local>();
            foreach (string dir in MovieListDirectories)
            {
                CurrentDirectory = dir;
                CurrentDirectoryList = Directory.GetDirectories(dir);
                foreach (string mdir in CurrentDirectoryList)
                {
                    CurrentScannedDirectory = mdir;
                    if (!(await CheckDirectoryInDatabase(mdir)))
                        MovieList.Add(await Movie.CreateAsync(this));
                }
            }
            var list = MovieList.Where(x => x.Error == null && x.Name != null).ToList();
            var errorList = MovieList.Where(x => x.Error != null && x.Name == null).ToList();

            await DatabaseApi.MovieQueryAsync(list);
        }

        private async Task GetRootDirectories()
        {
            //Temp fix
            await Task.Delay(0);
            MovieListDirectories.AddRange(
                new string[]
                {
                    @"E:\Movies",
                    @"E:\Movies2"
                }
            );
        }
        
        private async Task<bool> CheckDirectoryInDatabase(string directory)
        {
            //CHECK IN DATABASE IF DIRECTORY EXISTS RETURN BOOL VALUE
            await Task.Delay(0);
            return false;
        }
    }
}