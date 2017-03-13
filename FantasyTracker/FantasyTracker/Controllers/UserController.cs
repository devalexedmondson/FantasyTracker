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
using System.Net.Http;

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

        //CreateTeam
        //GET: /User/CreateTeam
        [AllowAnonymous]
        public ActionResult CreateTeam()
        {
            var x = new CreateTeamViewModel();
            x.data = PullGames();
            return View(x);
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
        
        //CreateRoster POINT AT API SEARCH CONTROLLER
        //GET: /User/CreateRoster
        [AllowAnonymous]
        public ActionResult CreateRoster()
        {
            //var nbaTeams = db.NbaTeam.ToList();
            var viewModel = new CreateRosterViewModel
            {
                //Teams = nbaTeams
            };
            return View(viewModel);
        }

        //CreateTeam POST
        //POST : /User/CreateRoster
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRoster(CreateRosterViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Include(x => x.Team).Where(x => x.Id == userId).First();
            if (ModelState.IsValid)
            {
                var team = new Player()
                {
                    PlayerName = model.PlayerName
                };
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            };
            return View(model);
        }


        //CreateTeam POST
        //POST : /User/EditTeam
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

        //UserRoster
        // GET: /Account/UserRoster
        [AllowAnonymous]
        public ActionResult UserRoster()
        {
            var x = new UserRosterViewModel();
            x.data = GetPlayers();
            return View(x);
        }

        [AllowAnonymous]
        public ActionResult ViewGames()
        {
            var x = new ViewGamesViewModel();
            x.data = PullGames();
            return View(x);
        }
        public string PullGames()
        {
            //put dateTime in URL string
            var dateTime = DateTime.UtcNow.Date;
            WebRequest request = WebRequest.Create("https://api.sportradar.us/nba-t3/games/2017/3/13/schedule.json?api_key=9reqn46t4sn9hdaa7ppukjeq");
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            return responseFromServer;
        }
        public string GetTeams()
        {
            WebRequest request = WebRequest.Create("https://api.sportradar.us/nba-t3/league/hierarchy.json?api_key=9reqn46t4sn9hdaa7ppukjeq");
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            return responseFromServer;
        }
        public string GetPlayers()
        {
            WebRequest request = WebRequest.Create("https://api.sportradar.us/nba-t3/players/0afbe608-940a-4d5d-a1f7-468718c67d91/profile.json?api_key=9reqn46t4sn9hdaa7ppukjeq");
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();
            return responseFromServer;
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
