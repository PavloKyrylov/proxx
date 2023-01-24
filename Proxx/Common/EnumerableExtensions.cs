namespace Proxx.Common;

internal static class EnumerableExtensions
{
    internal static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
    {
        foreach (var x in list)
        {
            action(x);
        }
    }
}
