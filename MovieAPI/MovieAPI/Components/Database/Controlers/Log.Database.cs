using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieAPI.Components.Database.Controlers
{
    public class Parser
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

        public async Task<LogStatus> Write<T>(T data, string description, LogStatus status = LogStatus.Info) where T : class
        {
            Parser p = new Parser() { status = status };
            if (data == null)
                return LogStatus.Error;

            if(data.GetType() == typeof(Movies))
                return await p.WriteAsync<Movies>(data,description);

            return LogStatus.Error;
        }

        public static async Task<T> Read<T>(T type, string[] args = null)
        {
            Parser p = new Parser();
            if (type == null)
                return default(T);
            return await p.ReadAsync(type,args);
        }

        private async Task<LogStatus> WriteAsync<T>(object data,string description) where T : class
        {
            var x = (T)data;

            return LogStatus.Error;
        }

        private async Task<T> ReadAsync<T>(T type,string[] args)
        {
            return default(T);
        }
    }
}