﻿using System.Collections.Generic.Common;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
namespace System.Collections.Generic {

  // ReSharper disable once InconsistentNaming
  /// <summary>
  /// Denotes extensions for <see cref="IEnumerable{T}"/> types.
  /// </summary>
  public static class IEnumerableExtensions {

    /// <summary>
    /// Checks a sequence to see if it doesn't have any items.
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the sequence</typeparam>
    /// <param name="sequence">The sequence of items we are testing to see if it is empty</param>
    /// <returns><c>true</c> if the sequence is empty, <c>false</c> otherwise.</returns>
    /// <exception cref="NullReferenceException">If the sequence is null.</exception>
    public static bool IsEmpty<T>(this IEnumerable<T> sequence) {

      if (sequence == null)
        throw new NullReferenceException(nameof(sequence));

      return !sequence.Any();
    }

    /// <summary>
    /// Checks a sequence of items to see if it is null or empty.
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the sequence</typeparam>
    /// <param name="sequence">The sequence of items we are testing to see if it is null or empty</param>
    /// <returns><c>true</c> if the sequence is null or empty, <c>false</c> otherwise.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> sequence) {
      return sequence == null || !sequence.Any();
    }

    /// <summary>
    /// Returns a not-nullable collection of T
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the sequence</typeparam>
    /// <param name="sequence">The sequence of items to be worked with as not null collection</param>
    /// <returns><see cref="IEnumerable{T}"/></returns>
    public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> sequence) {
      return sequence ?? Enumerable.Empty<T>();
    }

    /// <summary>
    /// Executes an action for each element in the sequence.
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the sequence</typeparam>
    /// <param name="sequence">The sequence of items for which we want to execute an action for each element.</param>
    /// <param name="action">The action to be executed for each element in the sequence.</param>
    /// <exception cref="NullReferenceException">If the sequence is null.</exception>
    /// <exception cref="ArgumentNullException">If the action is null.</exception>
    public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action) {

      if(sequence == null)
        throw new NullReferenceException(nameof(sequence));

      if (action == null)
        throw new ArgumentNullException(nameof(action));

      foreach(var element in sequence) {
        action(element);
      }
    }

    /// <summary>
    /// Executes an action for each element in the sequence, also providing the element's index.
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the sequence</typeparam>
    /// <param name="sequence">The sequence of items for which we want to execute an action for each element.</param>
    /// <param name="action">The action to be executed for each element in the sequence.</param>
    /// <exception cref="NullReferenceException">If the sequence is null.</exception>
    /// <exception cref="ArgumentNullException">If the action is null.</exception>
    public static void ForEach<T>(this IEnumerable<T> sequence, Action<T, int> action) {

      if(sequence == null)
        throw new NullReferenceException(nameof(sequence));

      if(action == null)
        throw new ArgumentNullException(nameof(action));

      var index = 0;

      foreach(var element in sequence) {
        action(element, index);
        index += 1;
      }
    }

    /// <summary>
    /// Returns the index of an item in a sequence
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence">The sequence of items</param>
    /// <param name="item">The item being searched for</param>
    /// <returns>Integer denoting the index of the item or -1.</returns>
    /// <exception cref="NullReferenceException">If the sequence is null.</exception>
    public static int IndexOf<T>(this IEnumerable<T> sequence, T item) {

      if(sequence == null)
        throw new NullReferenceException(nameof(sequence));

      int i = 0;

      foreach(var element in sequence) {

        if(element.Equals(item)) {
          return i;
        }

        i += 1;
      }

      return -1;
    }

    /// <summary>
    /// Left join
    /// </summary>
    /// <typeparam name="TLeft">Denotes the type of items in the Left sequence</typeparam>
    /// <typeparam name="TRight">Denotes the type of items in the right sequence</typeparam>
    /// <typeparam name="TCommon">Denotes the matching type common between the left and right sequences.</typeparam>
    /// <typeparam name="TResult">Denotes the type of the result</typeparam>
    /// <param name="leftSequence">Denotes the left sequence</param>
    /// <param name="rightSequence">Denotes the right sequence</param>
    /// <param name="leftSelector">Denotes the selector used to find matching items in the left sequence.</param>
    /// <param name="rightSelector">Denotes the selector used to find matching items in the right sequence.</param>
    /// <param name="resultSelector">Denotes the selector used to convert the common matching items between the the left and sequence into the desired result.</param>
    /// <returns></returns>
    public static IEnumerable<TResult> LeftOuterJoin<TLeft, TRight, TCommon, TResult>(
      this IEnumerable<TLeft> leftSequence,
      IEnumerable<TRight> rightSequence,
      Func<TLeft, TCommon> leftSelector,
      Func<TRight, TCommon> rightSelector,
      Func<TLeft, TRight, TResult> resultSelector)
      where TLeft : class
      where TRight : class {


      var leftItems = leftSequence.Select(leftSelector)
        .Except(rightSequence.Select(rightSelector));
      
      return leftSequence.Join(rightSequence, leftSelector, rightSelector, resultSelector)
        .Union(leftSequence.Where(leftItem => leftItems.Contains(leftSelector(leftItem))).Select(lItem => resultSelector(lItem, (TRight)null)));

    }


    /// <summary>
    /// Returns the first index of an item in a sequence matching a given condition
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence">The sequence of items</param>
    /// <param name="selector">The selector used to find the item</param>
    /// <returns><see cref="int"/> denoting the index of the item or -1.</returns>
    /// <exception cref="NullReferenceException">If the sequence is null.</exception>
    /// <exception cref="ArgumentNullException">If the selector is null.</exception>
    public static int IndexOf<T>(this IEnumerable<T> sequence, Func<T, bool> selector) {

      if(sequence == null)
        throw new NullReferenceException(nameof(sequence));

      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      int i = 0;

      foreach(var element in sequence) {

        if(selector(element)) {
          return i;
        }

        i += 1;
      }

      return -1;
    }

    /// <summary>
    /// Returns the last index of an item in a sequence matching a given condition
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence">The sequence of items</param>
    /// <param name="selector">The selector used to find the item</param>
    /// <returns><see cref="int"/> denoting the index of the item or -1.</returns>
    /// <exception cref="NullReferenceException">If the sequence is null.</exception>
    /// <exception cref="ArgumentNullException">If the selector is null.</exception>
    public static int LastIndexOf<T>(this IEnumerable<T> sequence, Func<T, bool> selector)
    {

	    if (sequence == null)
		    throw new NullReferenceException(nameof(sequence));

	    if (selector == null)
		    throw new ArgumentNullException(nameof(selector));

	    int i = 0;
	    int lastFoundIndex = -1;

	    foreach (var element in sequence)
	    {

		    if (selector(element))
		    {
			    lastFoundIndex = i;
		    }

		    i += 1;
	    }

	    return lastFoundIndex;
    }

		/// <summary>
		/// Checks to see if there is an element in the sequence that satisfies a condition
		/// </summary>
		/// <typeparam name="T">The type of each item in the sequence</typeparam>
		/// <param name="sequence">The sequence of items</param>
		/// <param name="selector">The selector used to find the item</param>
		/// <returns>A <c>true</c> <see cref="bool"/> value if the sequence contains an element fitting the predicate condition, <c>false</c> otherwise.</returns>
		/// <exception cref="NullReferenceException">If the sequence is null.</exception>
		/// <exception cref="ArgumentNullException">If the selector is null.</exception>
		public static bool Contains<T>(this IEnumerable<T> sequence, Func<T, bool> selector) {

      if (sequence == null)
        throw new NullReferenceException(nameof(sequence));

      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      return sequence.Any(selector);
    }

    /// <summary>
    /// Finds distinct elements in a sequence, using a lamda expression to compare the items for equality.
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence">The sequence of items</param>
    /// <param name="comparer">A lambda expression used to test two objects of the same type for equality.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of distinct elements from the original sequence.</returns>
    /// <exception cref="NullReferenceException">If the sequence is null.</exception>
    /// <exception cref="ArgumentNullException">If the comparer is null.</exception>
    public static IEnumerable<T> Distinct<T>(this IEnumerable<T> sequence, Func<T, T, bool> comparer) {

      if (sequence == null)
        throw new NullReferenceException(nameof(sequence));

      if (comparer == null) 
        throw new ArgumentNullException(nameof(comparer));
      
      return sequence.Distinct(new LambdaComparer<T>(comparer));
    }

    /// <summary>
    /// Returns all unique elements from both sequences, using a lamda expression as an equality comparer. 
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence1">The first sequence</param>
    /// <param name="sequence2">The second sequence</param>
    /// <param name="comparer">A lambda expression used to test two objects of the same type for equality.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of distinct elements from the original sequence.</returns>
    /// <exception cref="NullReferenceException">If sequence1 is null.</exception>
    /// <exception cref="NullReferenceException">If sequence2 is null.</exception>
    /// <exception cref="ArgumentNullException">If the comparer is null.</exception>
    public static IEnumerable<T> Union<T>(this IEnumerable<T> sequence1, IEnumerable<T> sequence2, Func<T, T, bool> comparer)
    {
      if (sequence1 == null)
        throw new NullReferenceException(nameof(sequence1));

      if (sequence2 == null)
        throw new NullReferenceException(nameof(sequence2));

      if (comparer == null)
        throw new ArgumentNullException(nameof(comparer));

      return sequence1.Union(sequence2, new LambdaComparer<T>(comparer));
    }

    /// <summary>
    /// Returns the elements in the first sequence that do not appear in the second, using a lambda expression as an equality comparer
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence1">The first sequence</param>
    /// <param name="sequence2">The second sequence</param>
    /// <param name="comparer">A lambda expression used to test two objects of the same type for equality.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of distinct elements from the original sequence.</returns>
    /// <exception cref="NullReferenceException">If sequence1 is null.</exception>
    /// <exception cref="NullReferenceException">If sequence2 is null.</exception>
    /// <exception cref="ArgumentNullException">If the comparer is null.</exception>
    public static IEnumerable<T> Except<T>(this IEnumerable<T> sequence1, IEnumerable<T> sequence2, Func<T, T, bool> comparer)
    {
      if (sequence1 == null)
        throw new NullReferenceException(nameof(sequence1));

      if (sequence2 == null)
        throw new NullReferenceException(nameof(sequence2));

      if (comparer == null)
        throw new ArgumentNullException(nameof(comparer));

      return sequence1.Except(sequence2, new LambdaComparer<T>(comparer));
    }

    /// <summary>
    /// Returns the elements that appear in each of the two sequences, using a lambda expression as an equality comparer.
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence1">The first sequence</param>
    /// <param name="sequence2">The second sequence</param>
    /// <param name="comparer">A lambda expression used to test two objects of the same type for equality.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> of distinct elements from the original sequence.</returns>
    /// <exception cref="NullReferenceException">If sequence1 is null.</exception>
    /// <exception cref="NullReferenceException">If sequence2 is null.</exception>
    /// <exception cref="ArgumentNullException">If the comparer is null.</exception>
    public static IEnumerable<T> Intersect<T>(this IEnumerable<T> sequence1, IEnumerable<T> sequence2, Func<T, T, bool> comparer)
    {
      return sequence1.Intersect(sequence2, new LambdaComparer<T>(comparer));
    }

    /// <summary>
    /// Splits a sequence into chunks of predefined maximum size
    /// </summary>
    /// <typeparam name="T">The type of each element in the sequence</typeparam>
    /// <param name="sequence">The sequence</param>
    /// <param name="size">The maximum size of each element</param>
    /// <returns>A list, each containing a list of maximum size</returns>
    /// <exception cref="NullReferenceException">If the sequence is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">If the sequence is null.</exception>
    public static List<List<T>> Split<T>(this IEnumerable<T> sequence, int size) {

      if(sequence == null)
        throw new NullReferenceException(nameof(sequence));

      if(size <= 0)
        throw new ArgumentOutOfRangeException(nameof(size));

      return sequence
        .Select((x, i) => new {
          Index = i,
          Value = x
        })
        .GroupBy(x => x.Index / size)
        .Select(x => x.Select(v => v.Value).ToList())
        .ToList();
    }

    /// <summary>
    /// Creates a new collection from a sequence.
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence">The sequence of items</param>
    /// <returns>An <see cref="ObservableCollection{T}"/></returns>
    /// <exception cref="NullReferenceException">If sequence1 is null.</exception>
    public static Collection<T> ToCollection<T>(this IEnumerable<T> sequence) {
      
      if (sequence == null)
        throw new NullReferenceException(nameof(sequence));

      var collection = new Collection<T>();

      foreach (T item in sequence)
        collection.Add(item);
      
      return collection;
    }

    /// <summary>
    /// Creates a new observable collection from a sequence.
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence">The sequence of items</param>
    /// <returns>An <see cref="ObservableCollection{T}"/></returns>
    /// <exception cref="NullReferenceException">If sequence1 is null.</exception>
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> sequence) {

      if(sequence == null)
        throw new NullReferenceException(nameof(sequence));

      return new ObservableCollection<T>(sequence);
    }


    /// <summary>
    /// Converts an IEnumerable to a HashSet
    /// </summary>
    /// <typeparam name="T">The type of each item in the sequence</typeparam>
    /// <param name="sequence">The sequence of items</param>
    /// <returns>An <see cref="HashSet{T}"/></returns>
    /// <exception cref="NullReferenceException">If sequence1 is null.</exception>
    public static HashSet<T> ToHashSet<T>(this IEnumerable<T> sequence) {

      if (sequence == null)
        throw new NullReferenceException(nameof(sequence));

      return new HashSet<T>(sequence);
    }
  }
}

