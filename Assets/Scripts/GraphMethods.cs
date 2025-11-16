using System;
using System.Collections.Generic;
using System.Linq;

public class GraphMethods
{
    /// <summary>
    /// Determines whether all elements of a sequence satisfy a condition.
    /// Time: O(n); Memory: O(1)
    /// https://learn.microsoft.com/es-es/dotnet/api/system.linq.enumerable.all?view=net-8.0
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool All<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (!predicate(item))
                return false;
        }
        return true;
    }
    /// <summary>
    /// Determines whether any element of a sequence satisfies a condition.
    /// Time: O(n); Memory: O(1)
    /// https://learn.microsoft.com/es-es/dotnet/api/system.linq.enumerable.any?view=net-8.0
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static bool Any<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                return true;
        }
        return false;
    }
    /// <summary>
    /// Determines whether a sequence contains a specified element by using the default equality comparer.
    /// Time: O(n); Memory: O(1)
    /// https://learn.microsoft.com/es-es/dotnet/api/system.linq.enumerable.contains?view=net-8.0
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public static bool Contains<TSource>(IEnumerable<TSource> source, TSource item)
    {
        foreach (var element in source)
        {
            if (element.Equals(item))
                return true;
        }
        return false;
    }
    /// <summary>
    /// Determines whether a sequence contains a specified element by using a specified IEqualityComparer<T>.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="item"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static bool Contains<TSource>(IEnumerable<TSource> source, TSource item, IEqualityComparer<TSource> comparer)
    {
        foreach (var element in source)
        {
            if (comparer.Equals(element, item))
                return true;
        }
        return false;
    }
    /// <summary>
    /// Returns distinct elements from a sequence by using the default equality comparer to compare values.
    /// Time: O(n); Memory: O(n)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source)
    {
        HashSet<TSource> distinct = new();

        foreach (var item in source)
        {
            if (distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Returns distinct elements from a sequence by using a specified IEqualityComparer<T> to compare values.
    /// Time: O(n); Memory: O(n)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Distinct<TSource>(IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
    {
        HashSet<TSource> distinct = new(comparer);

        foreach (var item in source)
        {
            // The .Add function checks if the item is already in the list. If it is, it doesn't add the item.
            if (distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Returns the element at a specified index in a sequence.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static TSource ElementAt<TSource>(IEnumerable<TSource> source, int index)
    {
        if (index < 0 || index >= source.Count())
            throw new ArgumentOutOfRangeException(nameof(index));

        int i = 0;

        foreach (var item in source)
        {
            if (i == index)
                return item;
            i++;
        }

        throw new ArgumentOutOfRangeException(nameof(index));
    }
    /// <summary>
    /// Produces the set difference of two sequences by using the default equality comparer to compare values.
    /// Time: O(n + m) (n = source1.Count(), m = source2.Count())
    /// Memory: O(n + m)
    /// https://stackoverflow.com/questions/25247854/what-is-the-time-complexity-performance-of-hashset-contains-in-java
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        HashSet<TSource> other = new(source2, EqualityComparer<TSource>.Default);
        HashSet<TSource> distinct = new();

        foreach (var item in source1)
        {
            if (!other.Contains(item) && distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Produces the set difference of two sequences by using the specified IEqualityComparer<T> to compare values.
    /// Time: O(n + m) (n = source1.Count(), m = source2.Count())
    /// Memory: O(n + m)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
    {
        HashSet<TSource> other = new(source2, comparer);
        HashSet<TSource> distinct = new(comparer);

        foreach (var item in source1)
        {
            if (!other.Contains(item) && distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Returns the first element in a sequence that satisfies a specified condition.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static TSource First<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                return item;
        }

        return default(TSource);
    }
    /// <summary>
    /// Returns the last element of a sequence that satisfies a specified condition.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static TSource Last<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        for (int item = source.Count() - 1; item >= 0; item--)
        {
            if (predicate(source.ElementAt(item)))
                return source.ElementAt(item);
        }

        return default(TSource);
    }
    /// <summary>
    /// Produces the set intersection of two sequences by using the default equality comparer to compare values.
    /// Time: O(n + m); Memory: O(m + k)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        HashSet<TSource> other = new(source2, EqualityComparer<TSource>.Default);
        HashSet<TSource> distinct = new();

        foreach (var item in source1)
        {
            if (distinct.Add(item) && other.Contains(item))
                yield return item;
        }
    }
    /// <summary>
    /// Produces the set intersection of two sequences by using the specified IEqualityComparer<T> to compare values.
    /// Time: O(n + m); Memory: O(m + k)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
    {
        HashSet<TSource> other = new(source2, comparer);
        HashSet<TSource> distinct = new(comparer);

        foreach (var item in source1)
        {
            if (distinct.Add(item) && other.Contains(item))
                yield return item;
        }
    }
    /// <summary>
    /// Returns a number that represents how many elements in the specified sequence satisfy a condition.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static int Count<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        int count = 0;

        foreach (var item in source)
        {
            if (predicate(item))
                count++;
        }

        return count;
    }
    /// <summary>
    /// Determines whether two sequences are equal by comparing their elements by using a specified IEqualityComparer<T>.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static bool SequenceEqual<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
    {
        using var enumerator1 = source1.GetEnumerator();
        using var enumerator2 = source2.GetEnumerator();

        while (true)
        {
            bool next1 = enumerator1.MoveNext();
            bool next2 = enumerator2.MoveNext();

            if (!next1 && !next2)
                return true;

            if (next1 != next2)
                return false;

            if (!comparer.Equals(enumerator1.Current, enumerator2.Current))
                return false;
        }
    }
    /// <summary>
    /// Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static TSource Single<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        TSource result = default(TSource);
        bool found = false;

        foreach (var item in source)
        {
            if (predicate(item))
            {
                if (found)
                    throw new Exception("More than one element satisfies the condition");

                result = item;
                found = true;
            }
        }

        return result;
    }
    /// <summary>
    /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> SkipWhile<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        bool skip = true;

        foreach (var item in source)
        {
            if (predicate(item) && skip)
                continue;

            skip = false;
            yield return item;
        }
    }
    /// <summary>
    /// Produces the set union of two sequences by using the default equality comparer.
    /// Time: O(n + m); Memory: O(n + m)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        HashSet<TSource> distinct = new();

        foreach (var item in Distinct(source1))
        {
            if (distinct.Add(item))
                yield return item;
        }

        foreach (var item in Distinct(source2))
        {
            if (distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Produces the set union of two sequences by using a specified IEqualityComparer<T>.
    /// Time: O(n + m); Memory: O(n + m)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
    {
        HashSet<TSource> distinct = new(comparer);

        foreach (var item in Distinct(source1))
        {
            if (distinct.Add(item))
                yield return item;
        }

        foreach (var item in Distinct(source2))
        {
            if (distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
    /// Time: O(n); Memory: O(1)
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
                yield return item;
        }
    }
}
