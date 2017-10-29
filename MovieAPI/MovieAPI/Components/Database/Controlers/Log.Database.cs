using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace MovieAPI.Components.Database.Controlers
{
    public class Parser : Database
    {
        private LogStatus status { get; set; }
        private string[] data { get; set; }

        [Flags]
        public enum LogStatus
        {
            Error = 0,
            Warning = 1,
            Info = 2,
            Success = 3
        }


        public static async Task<LogStatus> WriteMovieError(LogError data, Movies movie) 
        {
            Parser p = new Parser() { status = LogStatus.Error };
            if (data == null)
                return LogStatus.Error;

            if (movie != null)
                return await p.WriteMovieErrorAsync(data, movie);

            return LogStatus.Error;
        }

        public static async Task<LogStatus> WriteMovieSuccess(LogSuccess data, Movies movie)
        {
            Parser p = new Parser() { status = LogStatus.Success };
            if (data == null)
                return LogStatus.Error;
            if (movie != null)
                return await p.WriteMovieSuccessAsync(data,movie);

            return LogStatus.Error;
        }

        public static async Task<LogStatus> WriteMovieInfo(LogInfo data, Movies movie)
        {
            Parser p = new Parser() { status = LogStatus.Info };
            if (data == null)
                return LogStatus.Error;
            if(movie != null)
                return await p.WriteMovieInfoAsync(data, movie);

            return LogStatus.Error;
        }

        public static async Task<T> Read<T>(T type, string[] args = null)
        {
            Parser p = new Parser();
            if (type == null)
                return default(T);
            return await p.ReadAsync(type,args);
        }

        //PRIVATE CLASS FUNCTIONS

        private async Task<LogStatus> WriteMovieAsync(object data, Movies movies)
        {
            return (data.GetType() == typeof(LogError)) ?
                await WriteMovieErrorAsync((LogError)data,movies)
                :
                ((data.GetType() == typeof(LogSuccess)) ?
                    await WriteMovieSuccessAsync((LogSuccess)data,movies)
                    :
                    ((data.GetType() == typeof(LogInfo)) ?
                        await WriteMovieInfoAsync((LogInfo)data,movies)
                        : LogStatus.Error
                        )
                    );
        }

        private async Task<LogStatus> WriteMovieErrorAsync(LogError data,Movies movies) 
        {
            if(data != null)
            {
                try
                {
                    movies.Log.Add(
                        new Log()
                        {
                            DateTime = DateTime.Now,
                            LogError = data,
                            LogSuccess = null,
                        }
                    );
                    await APIEntity.SaveChangesAsync();
                    return LogStatus.Success;
                }
                catch(Exception ex)
                {
                    return LogStatus.Error;
                }
            }
            return LogStatus.Error;
        }

        private async Task<LogStatus> WriteMovieSuccessAsync(LogSuccess data, Movies movies) 
        {
            if (data != null)
            {
                try
                {
                    movies.Log.Add(
                        new Log()
                        {
                            DateTime = DateTime.Now,
                            LogError = null,
                            LogSuccess = data,
                        }
                    );
                    await APIEntity.SaveChangesAsync();
                    return LogStatus.Success;
                }
                catch(Exception ex)
                {
                    return LogStatus.Error;
                }
            }
            return LogStatus.Error;


        }

        private async Task<LogStatus> WriteMovieInfoAsync(LogInfo data, Movies movies)
        {
            if (data != null)
            {
                try
                {
                    movies.Log.Add(
                        new Log()
                        {
                            DateTime = DateTime.Now,
                            LogError = null,
                            LogSuccess = null,
                            LogInfo = data
                        }
                    );
                    await APIEntity.SaveChangesAsync();
                    return LogStatus.Success;
                }
                catch (Exception ex)
                {
                    return LogStatus.Error;
                }
            }
            return LogStatus.Error;


        }


        private async Task<T> ReadAsync<T>(T type,string[] args)
        {
            return default(T);
        }
    }
}