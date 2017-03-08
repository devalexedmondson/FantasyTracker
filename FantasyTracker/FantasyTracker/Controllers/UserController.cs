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

namespace FantasyTracker.Controllers
{
    public class UserController : Controller
    {
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
        //CreateTeam POST
        //POST : /User/CreateTeam
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateTeam(UserViewModel model)
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());
            //if(ModelState.IsValid)
            //{
            //    var team = user.TeamId.TeamName;
            //    return RedirectToAction("Index", "Home");
            //};
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