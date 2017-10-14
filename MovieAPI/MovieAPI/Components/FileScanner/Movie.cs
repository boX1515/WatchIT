using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MovieAPI.Components.FileScanner
{
    public class Movie
    {
        private Local localMovie;

        public static async Task<Local> CreateAsync(Scanner data)
        {
            Movie m = new Movie();
            m.localMovie = new Local
            {
                Location = data.CurrentScannedDirectory
            };
            await m.Parse(Directory.GetFileSystemEntries(m.localMovie.Location));
            await m.ParseData();

            return m.localMovie;
        }

        internal async Task Parse(string[] data)
        {
            await Task.Delay(0);
            foreach (string item in data)
            {
                try
                {
                    //HAS SUBTITLE
                    if (item.Contains(".srt"))
                    {
                        localMovie.Subtitle = item.Replace(localMovie.Location + "\\", "");
                    }
                    //HAS VIDEO
                    if (item.Contains(".mp4"))
                    {
                        localMovie.FileName = item.Replace(localMovie.Location + "\\", "");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    localMovie.Error = localMovie.Location;
                }
                
            }

        }

        internal async Task ParseData()
        {
            await Task.Delay(0);
            
            if(localMovie.FileName != "" && localMovie.FileName != null)
            {
                Match m = Regex.Match(
                    localMovie.FileName,
                    @"(?'Title'.*)(?=\.[\d]{4})\.(?'Year'[\d]{4})\.(?'Pixelsize'[\d]{4}p)\.(?'Format'[\w]+)\.(?'Formatsize'[\w]+)-\[(?'Group'.*)\]\.(?'Extension'[\w]+)"
                );
                try
                {
                    localMovie.Name         = (m.Groups["Title"].Value).Replace('.',' ');
                    localMovie.Year         = m.Groups["Year"].Value;
                    localMovie.Pixelsize    = m.Groups["Pixelsize"].Value;
                    localMovie.Format       = m.Groups["Format"].Value;
                    localMovie.Formatsize   = m.Groups["Formatsize"].Value;
                    localMovie.Group        = m.Groups["Group"].Value;
                    localMovie.Extension    = m.Groups["Extension"].Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    localMovie.Error = localMovie.Location;
                }

            }
            else
            {
                localMovie.Error = localMovie.Location;
            }
        }

    }
}