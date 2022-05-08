#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleBank.Data;
using SampleBank.Models;

namespace SampleBank.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AdvanceUser> _userManager;

        public TransactionsController(ApplicationDbContext context, UserManager<AdvanceUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transaction.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .FirstOrDefaultAsync(m => m.id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public async Task<IActionResult> Create(transactionTypes transactionType){
            var userId = _userManager.GetUserId(User);
            var user = await _context.AspNetUsers.AsNoTracking().Include(u => u.beneficiaryAccounts).Include(u => u.bankAccounts).FirstOrDefaultAsync(u => u.Id == userId);
            TempData["transactionType"] = transactionType;
            ViewBag.userBankAccounts = user.bankAccounts;

            if (transactionType == transactionTypes.outerTransfer){
                ViewBag.userBeneficiaryAccounts = user.beneficiaryAccounts;
            }
            
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("amount, transactionType")] Transaction transaction, int? accountId, int? toAccountId){
            if (accountId == toAccountId && accountId != null){
                // TempData["transactionType"] = transaction.transactionType;
                TempData["error"] = "cannot select the same bank account for both ends of the transaction";
                return RedirectToAction("Create", new { transactionType = transaction.transactionType});
            }

            var bankAccount = await _context.BankAccount.Include(b => b.user).FirstOrDefaultAsync(b => b.id == accountId);
            if(transaction.transactionType != transactionTypes.deposit && transaction.amount > bankAccount.balance){
                TempData["error"] = "The amount you entered exceeds you account limit. please trye again.";
                return RedirectToAction("Create", new { transactionType = transaction.transactionType});
            }
            
            decimal newBalance;

            // setting the balance resulting from the transaction
            if (transaction.transactionType == transactionTypes.deposit)
                newBalance = bankAccount.balance + transaction.amount;
            else
                newBalance = bankAccount.balance - transaction.amount;

            
            // setting the bank account that the transaction was sent to incase of transfer transactions
            bool toBankAccountExists = toAccountId != null ? _context.BankAccount.Any(b => b.id == toAccountId) : false;
            if (toAccountId != null && toBankAccountExists && (transaction.transactionType == transactionTypes.innerTransfer || transaction.transactionType == transactionTypes.outerTransfer)){
                var toBankAccount = await _context.BankAccount.Include(b => b.user).FirstOrDefaultAsync(b => b.id == toAccountId);
                transaction.fromBankAccount = bankAccount;
                transaction.toBankAccount = toBankAccount;
                toBankAccount.balance += transaction.amount;
            }
            
            // setting remaining transaction data
            transaction.bankAccount = bankAccount;
            transaction.oldBalance = bankAccount.balance;
            transaction.newBalance = newBalance;
            transaction.transactionDate = DateTime.Now;

            ModelState.Clear();
            // this attempts to update the record and stores any resulting errors such as Validation errors in the ModelState.
            await TryUpdateModelAsync(transaction);

            if (ModelState.IsValid)
            {
                bankAccount.balance = newBalance;
                transaction.success = true;
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                TempData["notice"] = "Transaction Completed Successfully";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Amount,TransactionType,Success,Date")] Transaction transaction)
        {
            if (id != transaction.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .FirstOrDefaultAsync(m => m.id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.id == id);
        }
    }
}
