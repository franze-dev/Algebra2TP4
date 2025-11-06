using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GraphMethods
{
    /// <summary>
    /// Determines whether all elements of a sequence satisfy a condition.
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
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        HashSet<TSource> distinct = new();

        foreach (var item in source1)
        {
            if (!source2.Contains(item) && distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Produces the set difference of two sequences by using the specified IEqualityComparer<T> to compare values.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Except<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
    {
        HashSet<TSource> distinct = new(comparer);

        foreach (var item in source1)
        {
            if (!source2.Contains(item) && distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Returns the first element in a sequence that satisfies a specified condition.
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
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        HashSet<TSource> distinct = new();

        foreach (var item in source1)
            foreach (var item2 in source2)
                if (distinct.Add(item2) && item2.Equals(item))
                    yield return item2;
    }
    /// <summary>
    /// Produces the set intersection of two sequences by using the specified IEqualityComparer<T> to compare values.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Intersect<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
    {
        HashSet<TSource> distinct = new(comparer);

        foreach (var item in source1)
            foreach (var item2 in source2)
                if (distinct.Add(item2) && item2.Equals(item))
                    yield return item2;
    }
    /// <summary>
    /// Returns a number that represents how many elements in the specified sequence satisfy a condition.
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
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static bool SequenceEqual<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
    {
        if (source1.Count() != source2.Count())
            return false;

        for (int i = 0; i < source1.Count(); i++)
        {
            if (!source1.ElementAt(i).Equals(source2.ElementAt(i)))
                return false;
        }

        return true;
    }
    /// <summary>
    /// Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public static TSource Single<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        TSource result = default(TSource);

        foreach (var item in source)
        {
            if (predicate(item))
            {
                if (!result.Equals(default(TSource)))
                    throw new Exception("More than one element satisfies the condition");

                result = item;
            }
        }

        return result;
    }
    /// <summary>
    /// Bypasses elements in a sequence as long as a specified condition is true and then returns the remaining elements.
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
                skip = false;

            if (!skip)
                yield return item;
        }
    }
    /// <summary>
    /// Produces the set union of two sequences by using the default equality comparer.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2)
    {
        var distinct1 = Distinct(source1);
        var distinct2 = Distinct(source2);

        HashSet<TSource> distinct = new();

        foreach (var item in distinct1)
        {
            if (distinct.Add(item))
                yield return item;
        }

        foreach (var item in distinct2)
        {
            if (distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Produces the set union of two sequences by using a specified IEqualityComparer<T>.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="source1"></param>
    /// <param name="source2"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public static IEnumerable<TSource> Union<TSource>(IEnumerable<TSource> source1, IEnumerable<TSource> source2, IEqualityComparer<TSource> comparer)
    {
        var distinct1 = Distinct(source1);
        var distinct2 = Distinct(source2);

        HashSet<TSource> distinct = new(comparer);

        foreach (var item in distinct1)
        {
            if (distinct.Add(item))
                yield return item;
        }

        foreach (var item in distinct2)
        {
            if (distinct.Add(item))
                yield return item;
        }
    }
    /// <summary>
    /// Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
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
