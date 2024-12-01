using Bloc.Test.Authentication.Models;

namespace Bloc.Test.Authentication.Repository;

public interface IAuthenticationRepository
{
    Task<AuthenticationData> Authenticate(string username, string password);
    Task Logout();
}

public class FakeAuthenticationRepository : IAuthenticationRepository
{
    public static readonly string InvalidCredentialMessage = "Invalid credentials";

    public async Task<AuthenticationData> Authenticate(string username, string password)
    {
        // Simulate authentication
        await Task.Delay(new TimeSpan(0, 0, 0, 0, 500));
        if (username == "admin" && password == "password")
        {
            return new AuthenticationData("token", "refreshToken", DateTime.UtcNow.AddDays(1));
        }

        throw new Exception(InvalidCredentialMessage);
    }

    public async Task Logout()
    {
        // Simulate a logout
        await Task.Delay(new TimeSpan(0, 0, 0, 0, 500));
    }
}