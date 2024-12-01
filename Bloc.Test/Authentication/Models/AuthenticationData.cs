namespace Bloc.Test.Authentication.Models;

public class AuthenticationData(string AccessToken, string RefreshToken, DateTime ExpiresAt)
{
    public bool IsExpired => DateTime.UtcNow > ExpiresAt;
}