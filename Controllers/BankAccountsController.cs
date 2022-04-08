#nullable disable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleBank.Data;
using SampleBank.Models;

namespace SampleBank.Controllers
{
	public class BankAccountsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<AdvanceUser> _userManager;
		private readonly SignInManager<AdvanceUser> _signInManager;

		public BankAccountsController(ApplicationDbContext context, UserManager<AdvanceUser> userManager, SignInManager<AdvanceUser> signInManager){
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		// GET: BankAccounts
		[Authorize]
		public async Task<IActionResult> Index(){

			// before i used user.bankAccounts.ToList() to fetch the user's bank accounts and it worked very well but then i'm not sure what
			// happened and it stopped giving me any restult. like all i did was update the database with some new fields and for some reason
			// it doesn't work anymore (what could be the reason for this????)
			var user = await _userManager.GetUserAsync(User);
			var bankAccounts = _context.BankAccount.Where(b => b.user.Equals(user));
			return View(bankAccounts);
			// return View(await _context.BankAccount.ToListAsync());
		}

		// GET: BankAccounts/Details/5
		[Authorize]
		public async Task<IActionResult> Details(int? id){
			if (id == null){
				return NotFound();
			}

			var bankAccount = await _context.BankAccount.FirstOrDefaultAsync(m => m.id == id);
			if (bankAccount == null)
			{
				return NotFound();
			}

			return View(bankAccount);
		}

		// GET: BankAccounts/Create
		[Authorize]
		public IActionResult Create()
		{
			return View();
		}

		// POST: BankAccounts/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Create(BankAccount bankAccount){
			
			Random generator = new Random();
			var user = await _userManager.GetUserAsync(User);

			bankAccount.accountNumber = generator.Next(0, 1000000).ToString("D12");
			bankAccount.cardNumber = generator.Next(0, 1000000).ToString("D12");
			bankAccount.expirationDate = DateTime.UtcNow.Date.AddYears(5);
			bankAccount.beneficiaryName = user.firstName + " " + user.lastName;
			bankAccount.user = user;

			ModelState.Clear();
			await TryUpdateModelAsync(bankAccount);
			
			// Console.WriteLine("================================");
			// Console.WriteLine(ModelState.ErrorCount);
			// Console.WriteLine("================================");
			
			// // foreach (var modelState in ModelState.Values)
			// // {
			// // 	foreach (var error in modelState.Errors)
			// // 	{
			// // 		Console.WriteLine(error.ErrorMessage);
			// // 	}
			// // }
			// Console.WriteLine("================================");
			if (ModelState.IsValid){

				_context.Add(bankAccount);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(bankAccount);
		}

		// GET: BankAccounts/Edit/5
		[Authorize]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var bankAccount = await _context.BankAccount.FindAsync(id);
			if (bankAccount == null)
			{
				return NotFound();
			}
			return View(bankAccount);
		}

		// POST: BankAccounts/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> Edit(int id, [Bind("id,accountNumber,expirationDate,beneficiaryName,cardNumber")] BankAccount bankAccount)
		{
			if (id != bankAccount.id)
			{
					return NotFound();
			}

			if (ModelState.IsValid)
			{
					try
					{
						_context.Update(bankAccount);
						await _context.SaveChangesAsync();
					}
					catch (DbUpdateConcurrencyException)
					{
						if (!BankAccountExists(bankAccount.id))
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
			return View(bankAccount);
		}

		// GET: BankAccounts/Delete/5
		[Authorize]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var bankAccount = await _context.BankAccount
				.FirstOrDefaultAsync(m => m.id == id);
			if (bankAccount == null)
			{
				return NotFound();
			}

			return View(bankAccount);
		}

		// POST: BankAccounts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
				var bankAccount = await _context.BankAccount.FindAsync(id);
				_context.BankAccount.Remove(bankAccount);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
		}

		private bool BankAccountExists(int id)
		{
				return _context.BankAccount.Any(e => e.id == id);
		}
	}
}
