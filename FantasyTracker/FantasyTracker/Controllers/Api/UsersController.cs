using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FantasyTracker.Models;
using Microsoft.AspNet.Identity;

namespace FantasyTracker.Controllers.Api
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/users
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();
        }
        
        //Get /api/customers/1
        //public ApplicationUser GetUser(int id)
        //{
        //    var user = _context.Users.SingleOrDefault(c => c.Id == id);

        //    if (user == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return user;
        //}

        //// Post /api/customers
        //[HttpPost]
        //public ApplicationUser CreateUser(ApplicationUser user)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    _context.Users.Add(user);
        //    _context.SaveChanges();
        //    return user;
        //}

        ////PUT /api/customers/1
        //[HttpPut]
        //public void UpdateCustomer(int id, ApplicationUser user)
        //{
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var userInDb = _context.Users.SingleOrDefault(c => c.Id == id);


        //    if (userInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //        _context.SaveChanges();
        //}

        ////Delete /api/users/1
        //[HttpDelete]
        //public void DeleteUser(int id)
        //{
        //    var userInDb = _context.Users.SingleOrDefault(c => c.Id == id);

        //    if (userInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    _context.Users.Remove(userInDb);
        //    _context.SaveChanges();
        //}

    }
}
