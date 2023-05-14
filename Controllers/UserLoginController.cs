using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using XpenseTracker.Data;
using XpenseTracker.Models;
using XpenseTracker.Store;

namespace XpenseTracker.Controllers
{
    public class UserLoginController : ApiController
    {
        private readonly LoginSignup loginSignup;
        public UserLoginController()
        {
            loginSignup = new LoginSignup();
        }
        private UserDbContext db = new UserDbContext();


        //public List<UserModel> GetAllUsers()
        //{
        //    List<UserModel> users = new List<UserModel>();
        //    foreach (var item in db.UserModels)
        //    {
        //        item.password = String.Empty;
        //        users.Add(item);
        //    }
        //    return users;
        //}

        //[ResponseType(typeof(UserModel))]
        //public async Task<IHttpActionResult> GetUserById(int id)
        //{
        //    UserModel userModel = await db.UserModels.FindAsync(id);
        //    if (userModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(userModel);
        //}

        [ResponseType(typeof(UserModel))]
        public async Task<IHttpActionResult> UserSignup(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int response = await loginSignup.SignUp(userModel);
            if(response == -1)
            {
                return BadRequest("Username/Password in invalid or blank!");
            }
            if (response == -2)
            {
                return BadRequest("Username already exists!");
            }
            return CreatedAtRoute("DefaultApi", new { id = userModel.id }, userModel);
        }

        [ResponseType(typeof(UserModel))]
        public IHttpActionResult UserLogin(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int response =  loginSignup.Login(userModel);
            if (response == -1)
            {
                return BadRequest("Username/Password in invalid or blank!");
            }
            if (response == -2)
            {
                return BadRequest("Incorrect Username or Password!");
            }
            return Ok(new { message = "Login Successfull!" , status = 180998  });
        }


    }
}