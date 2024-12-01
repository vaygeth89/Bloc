using Bloc.Models;
using Bloc.Test.Models.Count;

namespace Bloc.Test.Count;

public class BlocCountUnitTest
{
    private readonly BlocBuilder<CountCubit, CountState> _blocBuilder
        = new(new CountCubit());

    private int _valueToAdd = 5;
    
    [Fact]
    public void WatchChanges_Successfully()
    {
        #region Setup

        BlocCountListener1 countListener1 = new BlocCountListener1(_blocBuilder);
        BlocCountListener2 countListener2 = new BlocCountListener2(_blocBuilder);
        countListener2.BlocBuilder.Bloc.OnStateChanged += (countState) => ListenForValueToAdd(countState, _valueToAdd);
        #endregion

        Assert.False(countListener1.BlocBuilder.State is null);

        #region Events

        countListener1.BlocBuilder.Bloc.IncrementCount(_valueToAdd);

        #endregion

        #region Assertions
        
        Assert.True(countListener2.BlocBuilder.State.Count == _valueToAdd);

        _valueToAdd = 0;
        countListener1.BlocBuilder.Bloc.Dispose();
        Assert.True(countListener1.BlocBuilder.State.Count == 0);

        #endregion
    }

    private void ListenForValueToAdd(CountState state, int valueToCompare)
    {
        Assert.True(state.Count == valueToCompare);
    }
}