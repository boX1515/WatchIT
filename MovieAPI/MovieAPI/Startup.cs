using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using MovieAPI.Components.FileScanner;

namespace MovieAPI
{
    public class Startup
    {
        public static async void Initialize()
        {
            await StartTasks();
        }

        private static async Task StartTasks()
        {
            await Task.Delay(0);
            try
            {
                Thread fileScanner = new Thread(async () => await Scanner.CreateAsync())
                {
                    Priority = ThreadPriority.Normal
                };
                fileScanner.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}