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
using Microsoft.AspNet.Identity.EntityFramework;

namespace FantasyTracker.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext(); //need?????
        // GET: Role
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        public bool isAdminUser() // ???need
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        //// GET: User
        //public ActionResult Index()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = User.Identity;
        //        ViewBag.Name = user.Name;

        //        ViewBag.displayMenu = "No";

        //        if (isAdminUser())
        //        {
        //            ViewBag.displayMenu = "Yes";
        //        }
        //        return View();
        //    }
        //    else
        //    {
        //        ViewBag.Name = "Not Logged in";
        //    }
        //    return View();
        //}
        //public bool isAdminUser()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = User.Identity;
        //        ApplicationDbContext context = new ApplicationDbContext();
        //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        //        var s = UserManager.GetRoles(user.GetUserId());
        //        if (s[0].ToString() == "Admin")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //}
    }
}