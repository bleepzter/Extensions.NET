using System.Linq;

// ReSharper disable once CheckNamespace
namespace System.Collections.Generic {
  // ReSharper disable once InconsistentNaming
  /// <summary>
  /// Denotes extensions for <see cref="IList{T}"/> types.
  /// </summary>
  public static class IListExtensions {

    private const string EMPTY_LIST_MESSAGE = "The list is empty - there are no elements to reorder in the list.";
    private const string ITEM_NOT_PART_OF_LIST_MESSAGE = "The item is not part of this list.";

    /// <summary>
    /// Returns the last index of a list or -1 if the list is empty.
    /// </summary>
    /// <typeparam name="T">The underlying typ eof each element in the list.</typeparam>
    /// <param name="list">The actual list</param>
    /// <returns>A positive integer describing the last index of a list structure. -1 if the list doesn't have any items.</returns>
    /// <exception cref="NullReferenceException">If the list is null.</exception>
    public static int LastElementIndex<T>(this IList<T> list) {
      if(list == null)
        throw new NullReferenceException(nameof(list));

      return list.Count - 1;
    }

    /// <summary>
    /// Moves an element towards the front (element index 0) of the list.
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the list.</typeparam>
    /// <param name="list">The list of items.</param>
    /// <param name="element">The element which we want to move up.</param>
    /// <exception cref="NullReferenceException">If the list is null.</exception>
    /// <exception cref="InvalidOperationException">If the item is not found in the list - the item has to be already in the list in order for the operation to complete.</exception>
    /// <remarks>When the list contains integers, this method actually calls the move up by index because the runtime can't distinguish between the two signatures.</remarks>
    public static void MoveUpByValue<T>(this IList<T> list, T element) {

      if (list == null)
        throw new NullReferenceException(nameof(list));

      var elementIndex = list.IndexOf(element);

      if(elementIndex < 0) {
        throw new InvalidOperationException(ITEM_NOT_PART_OF_LIST_MESSAGE);
      }

      if(elementIndex == 0) {
        return; //the item is already at the top of the list.
      }

      IListExtensions.SwapInternal(list, elementIndex, elementIndex - 1);
    }

    /// <summary>
    /// Moves an element at a specific index towards the front (index 0) of the list.
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the list.</typeparam>
    /// <param name="list">The list of items.</param>
    /// <param name="elementAtIndex">The index of the element we want to move up</param>
    /// <exception cref="NullReferenceException">If the list is null.</exception>
    /// <exception cref="IndexOutOfRangeException">If the elementAtIndex parameter is a negative number.</exception>
    /// <exception cref="IndexOutOfRangeException">If the elementAtIndex parameter exceeds the value of the last index within the list.</exception>
    public static void MoveUpByIndex<T>(this IList<T> list, int elementAtIndex) {
      
      if (list == null)
        throw new NullReferenceException(nameof(list));

      if (elementAtIndex < 0) {
        throw new IndexOutOfRangeException(nameof(elementAtIndex));
      }

      if(elementAtIndex == 0) {
        return; //the item is already at the top of the list.
      }

      if(elementAtIndex > list.LastElementIndex()) {
        throw new IndexOutOfRangeException(nameof(elementAtIndex));
      }

      IListExtensions.SwapInternal(list, elementAtIndex, elementAtIndex - 1);
    }

    /// <summary>
    /// Moves an element towards the end (last index) of the list.
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the list.</typeparam>
    /// <param name="list">The list of items.</param>
    /// <param name="element">The element which we want to move up.</param>
    /// <exception cref="NullReferenceException">If the list is null</exception>
    /// <exception cref="InvalidOperationException">If the item is not found in the list - the item has to be already in the list in order for the operation to complete.</exception>
    public static void MoveDownByValue<T>(this IList<T> list, T element) {
      
      if (list == null)
        throw new NullReferenceException(nameof(list));

      var elementIndex = list.IndexOf(element);

      if(elementIndex < 0) {
        throw new InvalidOperationException(ITEM_NOT_PART_OF_LIST_MESSAGE);
      }

      if(elementIndex == list.LastElementIndex()) {
        return; //item already at the end of the list.
      }

      IListExtensions.SwapInternal(list, elementIndex, elementIndex + 1);
    }

    /// <summary>
    /// Moves an element towards the end (last index) of the list.
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the list.</typeparam>
    /// <param name="list">The list of items.</param>
    /// <param name="elementAtIndex">The index of the element we want to move down.</param>
    /// <exception cref="NullReferenceException">If the list is null.</exception>
    /// <exception cref="IndexOutOfRangeException">If the elementAtIndex parameter is a negative number.</exception>
    /// <exception cref="IndexOutOfRangeException">If the elementAtIndex parameter exceeds the value of the last index within the list.</exception>
    public static void MoveDownByIndex<T>(this IList<T> list, int elementAtIndex) {

      if (list == null)
        throw new NullReferenceException(nameof(list));

      if (elementAtIndex < 0) {
        throw new IndexOutOfRangeException(nameof(elementAtIndex));
      }

      if(elementAtIndex == list.LastElementIndex()) {
        return; //element already at the end of the list.
      }

      if(elementAtIndex > list.LastElementIndex()) {
        throw new IndexOutOfRangeException(nameof(elementAtIndex));
      }

      IListExtensions.SwapInternal(list, elementAtIndex, elementAtIndex + 1);
    }

    /// <summary>
    /// Swaps two elements that live in the same list using a 3-way swap. 
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the list.</typeparam>
    /// <param name="list">The list of items.</param>
    /// <param name="fromIndex">Source element index.</param>
    /// <param name="toIndex">Destination element index.</param>
    /// <exception cref="NullReferenceException">If the list is null.</exception>
    /// <exception cref="IndexOutOfRangeException">If the fromIndex index is a negative number or exceeds the index value of the last element in the list.</exception>
    /// <exception cref="IndexOutOfRangeException">If the toIndex index is a negative number or exceeds the index value of the last element in the list</exception>
    public static void SwapByIndex<T>(this IList<T> list, int fromIndex, int toIndex) {

      if(list == null)
        throw new NullReferenceException(nameof(list));

      if(list.IsEmpty()) {
        throw new InvalidOperationException("Unable to swap elements in an empty list.");
      }

      if(fromIndex < 0 || fromIndex > list.LastElementIndex()) {
        throw new IndexOutOfRangeException(nameof(fromIndex));
      }

      if(toIndex < 0 || toIndex > list.LastElementIndex()) {
        throw new IndexOutOfRangeException(nameof(fromIndex));
      }

      IListExtensions.SwapInternal(list, fromIndex, toIndex);
    }

    /// <summary>
    /// Swaps two elements that live in the same list using a 3-way swap. 
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the list.</typeparam>
    /// <param name="list">The list of items.</param>
    /// <param name="fromIndex">Source element.</param>
    /// <param name="toIndex">Destination element.</param>
    /// <exception cref="NullReferenceException">If the list is null.</exception>
    /// <exception cref="IndexOutOfRangeException">If the list is empty.</exception>
    /// <exception cref="IndexOutOfRangeException">If any of the elements being swapped do are not actually in the list</exception>
    public static void SwapByValue<T>(this IList<T> list, T fromValue, T toValue) {
      if (list == null)
        throw new NullReferenceException(nameof(list));

      if (list.IsEmpty())
        throw new InvalidOperationException("Unable to swap elements in an empty list.");
      
      int fromIndex = -1;
      bool fromIndexFound = false;

      int toIndex = -1;
      bool toIndexFound = false;

      var comparer = EqualityComparer<T>.Default;

      for(int i = 0; i < list.Count; i++) {

        if(!fromIndexFound) {
          if(comparer.Equals(list[i], fromValue)) {
            fromIndex = i;
            fromIndexFound = true;
          }
        }

        if(!toIndexFound) {
          if(comparer.Equals(list[i], toValue)) {
            toIndex = i;
            toIndexFound = true;
          }
        }
      }

      if(fromIndex == -1 || toIndex == -1)
        throw new InvalidOperationException("Unable to swap elements that do not exist in the list.");

      if(fromIndex == toIndex)
        return;

      IListExtensions.SwapInternal(list, fromIndex, toIndex);
    }

    /// <summary> Basic 3 way swap, no error checking. </summary>
    /// <typeparam name="T">The underlying type of each element in the list.</typeparam>
    /// <param name="list">The list of items.</param>
    /// <param name="fromIndex">Source element index.</param>
    /// <param name="toIndex">Destination element index.</param>
    /// <exception cref="NullReferenceException">If the list is null.</exception>
    /// <exception cref="IndexOutOfRangeException">If the fromIndex index is a negative number or exceeds the index value of the last element in the list.</exception>
    /// <exception cref="IndexOutOfRangeException">If the toIndex index is a negative number or exceeds the index value of the last element in the list</exception>
    private static void SwapInternal<T>(IList<T> list, int fromIndex, int toIndex) {
      var temp = list[toIndex];
      list[toIndex] = list[fromIndex];
      list[fromIndex] = temp;
    }

    /// <summary>
    /// Removes a number of items from a list based on a predicate selector
    /// </summary>
    /// <typeparam name="T">The underlying type of each element in the list.</typeparam>
    /// <param name="list">The list of items.</param>
    /// <param name="predicate">A predicate that determines if a given element within the list should be removed.</param>
    /// <exception cref="NullReferenceException">If the list is null.</exception>
    /// <exception cref="NullReferenceException">If the predicate discriminator is null.</exception>
    public static void Remove<T>(this IList<T> list, Func<T, bool> predicate) {

      if(list == null) {
        throw new NullReferenceException("List is null.");
      }

      if(predicate == null) {
        throw new ArgumentNullException(nameof(predicate));
      }

      if(list.IsEmpty())
        return;

      var items = list.Where(predicate).ToList();

      foreach(var item in items) {
        list.Remove(item);
      }
    }
  }
}
