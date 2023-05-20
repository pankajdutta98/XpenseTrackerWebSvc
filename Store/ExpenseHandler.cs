using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using XpenseTracker.Data;
using XpenseTracker.Models;

namespace XpenseTracker.Store
{
    public class ExpenseHandler : IExpenseHandler
    {
        private UserDbContext db = new UserDbContext();
        public async Task<int> AddExpense(ExpenseModel expenseModel)
        {
            try
            {
                if (String.IsNullOrEmpty(expenseModel.title) || expenseModel.amount == 0)
                    return -1;
                db.expenses.Add(expenseModel);
                int resp = await db.SaveChangesAsync();
                return resp;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<int> EditExpense(ExpenseModel expenseModel)
        {
            ExpenseModel expense = new ExpenseModel();
            expense = db.expenses.Where(exp => exp.txnId == expenseModel.txnId).FirstOrDefault();
            if(expense == null)
            {
                return -1;
            }
            expense.title = expenseModel.title;
            expense.amount = expenseModel.amount;
            expense.txnDate = expenseModel.txnDate;
            expense.category = expenseModel.category;
            int resp = await db.SaveChangesAsync();
            return resp;
        }
        public async Task<int> DeleteExpense(ExpenseModel expenseModel)
        {
            ExpenseModel expense = new ExpenseModel();
            expense = db.expenses.Where(exp => exp.txnId == expenseModel.txnId).FirstOrDefault();
            if (expense == null)
            {
                return -1;
            }
            db.expenses.Remove(expense);
            int resp = await db.SaveChangesAsync();
            return resp;
        }
    }
}