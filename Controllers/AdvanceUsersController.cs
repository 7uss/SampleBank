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
	public class AdvanceUsersController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<AdvanceUser> _userManager;
		private readonly SignInManager<AdvanceUser> _signInManager;

		public AdvanceUsersController(ApplicationDbContext context, UserManager<AdvanceUser> userManager, SignInManager<AdvanceUser> signInManager){
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}
    }
}