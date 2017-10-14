using System;
using MovieAPI;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace MovieAPI.Components.CredentialManager
{
    public class Manager
    {
        public string Username  { get; private set; }
        public string Password  { get; private set; }
        public string Key       { get; private set; }


        public async Task CreateAsync(string username = "", string password = "")
        {
            Manager m = new Manager();
            await m.Set(username, password);
        }

        private async Task<bool> Set( string username, string password)
        {
            //SET TO DB
            await Task.Delay(0);
            return true;
        }

        public async Task<Manager> Get()
        {
            //READ FROM DB
            await Task.Delay(0);
            return new Manager();
        }

        public async Task<Manager> ResetKey()
        {
            await Task.Delay(0);
            return new Manager();
        }

    }
}