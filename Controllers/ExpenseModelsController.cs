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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using XpenseTracker.Data;
using XpenseTracker.Models;
using XpenseTracker.Store;

namespace XpenseTracker.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExpenseModelsController : ApiController
    {
        private readonly ExpenseHandler _expenseHandler;
        public ExpenseModelsController()
        {
            _expenseHandler = new ExpenseHandler();
        }
        private UserDbContext db = new UserDbContext();

        // GET: api/ExpenseModels
        public IQueryable<ExpenseModel> Getexpenses()
        {
            return db.expenses.OrderByDescending(x=>x.txnDate);
        }

        // GET: api/ExpenseModels/5
        [ResponseType(typeof(ExpenseModel))]
        public async Task<IHttpActionResult> GetExpenseById(int id)
        {
            ExpenseModel expenseModel = await db.expenses.FindAsync(id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            return Ok(expenseModel);
        }

        // POST: api/ExpenseModels
        [ResponseType(typeof(ExpenseModel))]
        public async Task<IHttpActionResult> CreateNewExpense(ExpenseModel expenseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int response = await _expenseHandler.AddExpense(expenseModel);
            if (response == 0)
            {
                return BadRequest("An error occured while processing your request");
            }
            if(response < 0)
            {
                return BadRequest("Invalid data entered. Please enter valid data");
            }
            return Ok(new { message = "Expense added successfully", expenses = db.expenses.OrderByDescending(x=>x.txnDate) });
        }

        [ResponseType(typeof(ExpenseModel))]
        public async Task<IHttpActionResult> EditExpense(ExpenseModel expenseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int response = await _expenseHandler.EditExpense(expenseModel);
            if (response < 0)
            {
                return BadRequest("Not Found!!");
            }
            return Ok(new { message = "Expense updated successfully", expenses = db.expenses.OrderByDescending(x => x.txnDate) });
        }
        [HttpPost]
        [ResponseType(typeof(ExpenseModel))]
        public async Task<IHttpActionResult> DeleteExpense(ExpenseModel expenseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int response = await _expenseHandler.DeleteExpense(expenseModel);
            if (response < 0)
            {
                return BadRequest("Not Found!!");
            }
            return Ok(new { message = "Expense deleted successfully", expenses = db.expenses.OrderByDescending(x => x.txnDate) });
        }
    }
}