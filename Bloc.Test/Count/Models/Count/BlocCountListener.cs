using Bloc.Models;

namespace Bloc.Test.Models.Count;

public class BlocCountListener1(BlocBuilder<CountCubit, CountState> blocBuilder)
{
    public BlocBuilder<CountCubit, CountState> BlocBuilder { get; } = blocBuilder;
}

public class BlocCountListener2(BlocBuilder<CountCubit, CountState> blocBuilder)
{
    public BlocBuilder<CountCubit, CountState> BlocBuilder { get; } = blocBuilder;
}