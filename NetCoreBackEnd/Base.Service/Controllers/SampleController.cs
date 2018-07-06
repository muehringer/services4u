using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Base.Application;
using Base.Infrastructure;

namespace Base.Service.Controllers
{
    [Route("api/sample")]
    public class SampleController : Controller
    {
        private readonly ISampleManager app;

        public SampleController(ISampleManager sampleManager)
        {
            app = sampleManager;
        }

        [HttpGet]
        [Route("ObterUsuarioLogado")]
        [Authorize]
        public ObjectResult GetUserLogged(){
            return new ObjectResult(new {
                Username = User.Identity.Name
            });                
        }

        [HttpGet]
        [Route("ObterSample")]
        [Authorize]
        public ResultData<SampleVm> Get()
        {
            return app.GetAll();                           
        }
    }
}