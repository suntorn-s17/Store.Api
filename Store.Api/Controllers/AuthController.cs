using Microsoft.AspNetCore.Mvc;
using Store.Api.DTOs.Requests;
using Store.Api.Services.Auth;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var token = await _authService.LoginAsync(request.Username, request.Password);

            return Ok(new
            {
                token
            });
        }
    }
}