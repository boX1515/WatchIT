using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieAPI.Components.ExternalAPI.APIs
{
    public class RottenTomatoAPI
    {
        public string Url = "";
        public string Key = "";

        public static async Task<RottenTomatoAPI> CreateAsync()
        {
            RottenTomatoAPI api = new RottenTomatoAPI();
            if (await api.CheckConnection())
                return api;
            return null;
        }

        private async Task<bool> CheckConnection()
        {
            await Task.Delay(0);
            return true;
        }

        public async Task GetMovieById(string id)
        {
            await Task.Delay(0);
        }
    }
}