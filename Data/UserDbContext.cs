using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using XpenseTracker.Models;

namespace XpenseTracker.Data
{
    public class UserDbContext : DbContext
    {     
        public UserDbContext() : base("name=UserDbContext")
        {
        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<ExpenseModel> expenses { get; set; }
    }
}
