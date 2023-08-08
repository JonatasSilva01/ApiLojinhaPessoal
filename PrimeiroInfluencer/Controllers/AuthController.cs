using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeUsuario.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Acesso permitido!");
        }
    }
}