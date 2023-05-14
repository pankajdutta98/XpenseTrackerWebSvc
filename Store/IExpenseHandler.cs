using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpenseTracker.Models;

namespace XpenseTracker.Store
{
    interface IExpenseHandler
    {
        Task<int> AddExpense(ExpenseModel expenseModel);
    }
}
