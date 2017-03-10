using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.IO;
using System.Web.UI;
using FantasyTracker.Models;
using System.Net;
using System.Text;

namespace FantasyTracker.Api
{
    //Drop down to display all NBA teams. Use to display all teams and find team id: team.id -> https://api.sportradar.us/nba-t3/seasontd/2016/REG/rankings.json?api_key=9reqn46t4sn9hdaa7ppukjeq

    //Drop down to display all players on that team. Use team.id to search team team profiles for player id: https://api.sportradar.us/nba-t3/teams/583eca2f-fb46-11e1-82cb-f4ce4684ea4c/profile.json?api_key=api_key=9reqn46t4sn9hdaa7ppukjeq

    public class SportsRadar
    {
        public class ApiController
        {
            public async Task<HttpResponseMessage> ConsumeExternalAPI()
            {
                string url = "https://api.sportradar.us/nba-t3/players/37fbc3a5-0d10-4e22-803b-baa2ea0cdb12/profile.json?api_key=9reqn46t4sn9hdaa7ppukjeq";
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

        public void GetPlayer()
        {
            WebRequest request = WebRequest.Create("https://api.sportradar.us/nba-t3/players/37fbc3a5-0d10-4e22-803b-baa2ea0cdb12/profile.xml?api_key=9reqn46t4sn9hdaa7ppukjeq");
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            request.Method = "POST";
            string postData = "This is a test";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = byteArray.Length;
            request.ContentType = "application/json; charset=utf-8";
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}