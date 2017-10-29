using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieAPI.Components.Database.Controlers;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    public class MovieController : ApiController
    {
        public async Task<Movies[]> Get(string name)
        {
            var data = await Movie.ByNameAsync(name);
            return data;
        }

        // GET: api/Movie
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Movie/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Movie
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public void Delete(int id)
        {
        }
    }
}
