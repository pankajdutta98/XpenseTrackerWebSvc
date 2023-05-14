using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using XpenseTracker.Data;
using XpenseTracker.Models;

namespace XpenseTracker.Store
{

    public class LoginSignup : ILoginSignup
    {
        UserDbContext db = new UserDbContext();
        public async Task<int> SignUp(UserModel userModel)
        {
            if (String.IsNullOrEmpty(userModel.userName) || String.IsNullOrEmpty(userModel.password))
                return -1;
            if(db.UserModels.Where(user=> user.userName == userModel.userName).ToList().Count() > 0)
            {                
                return -2;
            }

            db.UserModels.Add(userModel);
            await db.SaveChangesAsync();
            return 0;
        }
        public int Login(UserModel userModel)
        {
            if (String.IsNullOrEmpty(userModel.userName) || String.IsNullOrEmpty(userModel.password))
                return -1;
            if (db.UserModels.Where(user => user.userName == userModel.userName && user.password == userModel.password).ToList().Count() == 0)
            {
                return -2;
            }
            return 0;
        }
    }
}