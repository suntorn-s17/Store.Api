namespace Store.Api.Services.Jwt
{
    public interface IJwtService
    {
        string GenerateToken(string username, string role);
    }
}