using Microsoft.AspNetCore.Mvc;
using SampleBank.Services;

namespace SampleBank.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransactionsController : ControllerBase
    {
        private readonly SampleService _sampleService;

        public TransactionsController(SampleService sampleService){
            _sampleService = sampleService;
        }

        
        public string testAction(){
            string x = _sampleService.WelcomeEquinox();
            return "hello world"+x;
        }

        public string whatever(){
            return "okay";
        }

    }
}
