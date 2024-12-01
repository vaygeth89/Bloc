namespace Bloc.Models;

public class BlocBuilder<TBloc, TState> where TBloc : BlocBase<TState> where TState : class
{
    public TBloc Bloc { get; }
    public TState State => Bloc.State;

    public BlocBuilder(TBloc bloc)
    {
        Bloc = bloc;
        UpdateState(Bloc.State);
        Bloc.OnStateChanged += UpdateState;
    }

    private void UpdateState(TState state)
    {
        Bloc.State = state;
    }
}