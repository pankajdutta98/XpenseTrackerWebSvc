using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using XpenseTracker.Models;

namespace XpenseTracker.Store
{
    interface ILoginSignup
    {
        Task<int> SignUp(UserModel userModel);
        int Login(UserModel userModel);
    }
}
