using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XpenseTracker.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string  password { get; set; }
        public string phNum { get; set; }
        public string address { get; set; }
    }
}