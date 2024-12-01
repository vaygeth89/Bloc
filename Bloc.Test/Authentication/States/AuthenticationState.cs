using Bloc.Test.Authentication.Models;

namespace Bloc.Test.Authentication.States;

public abstract record AuthenticationState();

public record AuthenticationInitialState() : AuthenticationState();

public record AuthenticatingState() : AuthenticationState();

public record AuthenticatedState(AuthenticationData Data) : AuthenticationState();

public record UnauthenticatedState() : AuthenticationState();

public record AuthenticationErrorState(string Message) : AuthenticationState();