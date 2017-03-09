using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using FantasyTracker.Models;
using System.Data.Entity;
using System.Net;
using System.IO;
using System.Text;

namespace FantasyTracker.Controllers
{
    public class UserController : Controller
    {
        
        
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult Index()
        {

            return View();
        }
        public void PostPlayer()
        {
            WebRequest request = WebRequest.Create("http://api.sportradar.us/nfl-ot1/players/9634e162-5ff5-4372-b72b-ee1b0cb73a0d/profile.json?api_key=2wgxe67a3cevs76xe6g53kac");
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
       






        //CreateTeam
        //GET: /User/CreateTeam
        [AllowAnonymous]
        public ActionResult CreateTeam()
        {
            return View();
        }
        //UserRoster
        // GET: /Account/UserRoster
        [AllowAnonymous]
        public ActionResult UserRoster()
        {
            return View();
        }
        //CreateTeam POST
        //POST : /User/CreateTeam
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTeam(CreateTeamViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Include(x => x.Team).Where(x => x.Id == userId).First();
            if (ModelState.IsValid)
            {
                user.Team.TeamName = model.TeamName;
                user.Team.Sport = model.Sport;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            };
            return View(model);
        }
        //CreateTeam POINT AT API SEARCH CONTROLLER
        //GET: /User/CreateTeam
        [AllowAnonymous]
        public ActionResult CreateRoster()
        {
            return View();
        }
        //CreateTeam POST
        //POST : /User/CreateTeam
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRoster(CreateRosterViewModel model)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                var team = new Player()
                {
                    PlayerName = model.PlayerName
                };
                //return RedirectToAction("Index", "Home");
            };
            return View(model);
        }
        //CreateTeam POST
        //POST : /User/CreateTeam
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTeam(UserViewModel model)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                var team = user.Team.TeamName;
                return RedirectToAction("Index", "Home");
            };
            return View(model);
        }
        #region Helpers
        //private bool HasTeam()
        //{
        //    var user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user != null)
        //    {
        //        return user.TeamId != null;
        //    }
        //    return false;
        //}
        #endregion
    }
}