using MovieAPI.Components.ExternalAPI;
using MovieAPI.Components.Database.Controlers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieAPI.Components.Database
{
    public class Database
    {
        private CredentialManager.Manager Credentials;
        internal static APIEntityModelContainer APIEntity = new APIEntityModelContainer();

        internal static async Task<int> MovieAdd(KeyValuePair<Local, Movies> data)
        {
            APIEntity.MoviesSet.Add(data.Value);
            return await APIEntity.SaveChangesAsync();
        }

        internal static async Task<List<Local>> MovieQueryInDatabaseAsync(List<Local> movies)
        {
            List<string> dbMovies = await APIEntity.MoviesSet
                .Select(x => x.Local.FileName)
                .ToListAsync();

            List<Local> tempMovies = new List<Local>();
            
            foreach (Local m in movies)
                if (!dbMovies.Contains(m.FileName))
                    tempMovies.Add(m);

            return tempMovies;
        }
    }
}