namespace Delegates.Example.Extensions;

public static class LinqExtensions
{
    public static IEnumerable<(TSource, TSource)> ZipIntersectBy<TSource, TKey>(
        this ICollection<TSource> sourceA,
        ICollection<TSource> sourceB,
        Func<TSource, TKey> keySelector
    ) where TKey : notnull
    {
        if (sourceA is null)
            throw new ArgumentNullException(nameof(sourceA));

        if (sourceB is null)
            throw new ArgumentNullException(nameof(sourceB));

        if (keySelector is null)
            throw new ArgumentNullException(nameof(keySelector));

        return ZipIntersectByIterator(sourceA, sourceB, keySelector);
    }

    private static IEnumerable<(TSource, TSource)> ZipIntersectByIterator<TSource, TKey>(
        this ICollection<TSource> sourceA,
        ICollection<TSource> sourceB,
        Func<TSource, TKey> keySelector
    ) where TKey : notnull
    {
        foreach (var itemA in sourceA)
        {
            var key = keySelector(itemA);
            var itemB = sourceB.FirstOrDefault(element => keySelector(element).Equals(key));

            if (itemB != null)
                yield return (itemA, itemB);
        }
    }
}