using System.Linq;

namespace DotUtils;

public static class Calculator
{
    public static int Sum(params string[] numbers)
        => Enumerable.Sum(numbers.Cast<int>());
}
