using Bloc.Models;
using Bloc.Test.Authentication.Models;
using Bloc.Test.Authentication.Repository;
using Bloc.Test.Authentication.States;

namespace Bloc.Test.Authentication.Cubit;

public class AuthenticationCubit(IAuthenticationRepository repository)
    : Cubit<AuthenticationState>(new AuthenticationInitialState())
{
    public async void Login(string username, string password)
    {
        try
        {
            Emit(new AuthenticatingState());
            AuthenticationData authenticationData = await repository.Authenticate(username, password);
            Emit(new AuthenticatedState(authenticationData));
        }
        catch (Exception e)
        {
            Emit(new AuthenticationErrorState(e.Message));
        }
    }

    public async Task Logout()
    {
        await repository.Logout();
        Emit(new UnauthenticatedState());
    }
}