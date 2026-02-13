using Microsoft.AspNetCore.Mvc;
using ProniaOnion.src.Application;

namespace ProniaOnion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService =authService;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterDTO registerDTO)
        {
            await _authService.RegisterAsync(registerDTO);   
            return NoContent();
        }
        

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromForm]LoginDTO loginDTO)
        {
            return Ok(await _authService.LoginAsync(loginDTO));
        }
    }
}
