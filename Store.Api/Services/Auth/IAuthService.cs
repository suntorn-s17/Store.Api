namespace Store.Api.Services.Auth
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string username, string password);
    }
}