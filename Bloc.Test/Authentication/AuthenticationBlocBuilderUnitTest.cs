using Bloc.Models;
using Bloc.Test.Authentication.Cubit;
using Bloc.Test.Authentication.Repository;
using Bloc.Test.Authentication.States;
using Bloc.Test.Models.Count;

namespace Bloc.Test.Authentication;

public class AuthenticationBlocBuilderUnitTest
{
    private static IAuthenticationRepository _authenticationRepository = new FakeAuthenticationRepository();

    private readonly BlocBuilder<AuthenticationCubit, AuthenticationState> _authenticationBuilder
        = new(new AuthenticationCubit(_authenticationRepository));


    public AuthenticationBlocBuilderUnitTest()
    {
        _authenticationBuilder.Bloc.OnStateChanged += ListenForStateChanges;
    }

    [Fact]
    //authenticate
    public void Authenticate_ValidCredentials()
    {
        _authenticationBuilder.Bloc.Login("admin", "password");
    }

    [Fact]
    //authenticate
    public void Authenticate_WithInvalidCredentials()
    {
        _authenticationBuilder.Bloc.Login("admin", "123");
    }

    [Fact]
    //authenticate
    public async void Logout_Successfully()
    {
        await _authenticationBuilder.Bloc.Logout();
    }

    private void ListenForStateChanges(AuthenticationState state)
    {
        if (state is AuthenticatedState authenticatedState)
        {
            Assert.False(authenticatedState.Data.IsExpired);
        }
        else if (state is AuthenticationErrorState authenticationErrorState)
        {
            Assert.Equal(authenticationErrorState.Message, FakeAuthenticationRepository.InvalidCredentialMessage);
        }
        else if (state is UnauthenticatedState)
        {
            Assert.True(true);
        }
    }
}