using Microsoft.EntityFrameworkCore;
using Store.Api.Entities;
using Store.Api.Exceptions;
using Store.Api.Services.Jwt;

namespace Store.Api.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IJwtService _jwtService;
        private readonly AppDbContext _context;

        public AuthService(ILogger<AuthService> logger, IJwtService jwtService, AppDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
            _logger = logger;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            _logger.LogInformation("Attempting login for username {Username}", username);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                _logger.LogWarning("Login failed for username {Username}: invalid credentials", username);

                throw new UnauthorizeException("Invalid username or password");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                _logger.LogWarning("Login failed for username {Username}: invalid credentials", username);

                throw new UnauthorizeException("Invalid username or password");
            }

            _logger.LogInformation("Authentication successful for username {Username}", username);

            var token = _jwtService.GenerateToken(user.Username, user.Role);

            return token;
        }
    }
}