using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using FantasyTracker.Models;

namespace FantasyTracker.Controllers
{
    public class ApiController
    {
        public async Task<HttpResponseMessage> ConsumeExternalAPI()
        {
            string url = "https://api.sportradar.us/nba-t3/games/2017/3/09/schedule.json?api_key=9reqn46t4sn9hdaa7ppukjeq";
            Player Player = new Player();
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {


            }
            return response;
        }
    }
}