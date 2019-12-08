using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BankUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public IActionResult Index()
        {
            return View(Bank.GetAllAccountsByEmailAddress(HttpContext.User.Identity.Name));
        }

        // GET: Account/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("EmailAddress,AccountType,accountName")] Account account)
        {
            if (ModelState.IsValid)
            {
                Bank.CreateAccount(account.accountName, account.EmailAddress, account.AccountType);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
           
        }

        // GET: Account/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EmailAddress,AccountNumber,AccountType,accountName")] Account account)
        {
            if (id != account.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Bank.UpdateAccount(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        [HttpGet]
        public IActionResult Deposit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult Deposit(IFormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["Amount"]);
            Bank.Deposit(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Withdraw(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = Bank.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        public IActionResult Withdraw(IFormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var amount = Convert.ToDecimal(controls["Amount"]);
            Bank.Withdraw(accountNumber, amount);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Transactions(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var transactions=Bank.GetAllTransactionsByAccountNumber(id.Value);
            return View(transactions);
        }
    }
}
