using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SampleBank.Data;
using SampleBank.Models;

namespace SampleBank.Services
{
    public class SampleService
    {
        private readonly ApplicationDbContext _context;
		private readonly UserManager<AdvanceUser> _userManager;
		private readonly SignInManager<AdvanceUser> _signInManager;
        public string welcomeEquinoxStr { get; set; }
        public SampleService(ApplicationDbContext context, UserManager<AdvanceUser> userManager, SignInManager<AdvanceUser> signInManager){  
            welcomeEquinoxStr = "Welcome Folks in .Net Core presentation!"; //Configuration["WelcomeEquinox"];  
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;       
        }
        public string WelcomeEquinox()  
        {  
            return welcomeEquinoxStr;
        }  
    }  
} 