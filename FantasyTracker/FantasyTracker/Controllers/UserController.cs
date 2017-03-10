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


        //CreateRoster POINT AT API SEARCH CONTROLLER
        //GET: /User/CreateRoster
        [AllowAnonymous]
        public ActionResult CreateRoster()
        {
            var nbaTeams = db.NbaTeam.ToList();
            var viewModel = new CreateRosterViewModel
            {
                Teams = nbaTeams
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
            var user = db.Users.Find(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                var team = new Player()
                {
                    //PlayerName = model.PlayerName
                };
               
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
