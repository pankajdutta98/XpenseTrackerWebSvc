using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XpenseTracker.Models
{
    public class ExpenseModel
    {
        [Key]
        public int txnId { get; set; }
        public DateTime txnDate { get; set; }
        public string title { get; set; }
        public int amount { get; set; }
        public string category { get; set; }
    }
}