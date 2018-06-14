using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.Service.Controllers
{
    [Route("api/teste")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("ObterTeste")]
        [Authorize]
        public ObjectResult GetUserDetails(){
            return new ObjectResult(new {
                Username = User.Identity.Name
            });                
        }
    }
}