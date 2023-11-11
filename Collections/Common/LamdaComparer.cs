namespace System.Collections.Generic.Common {
  
  /// <summary>
  /// An object used to provide comparison operations using a predicate.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class LambdaComparer<T> : IEqualityComparer<T> {

    /// <summary>
    /// The predicate that makes the comparisons
    /// </summary>
    readonly Func<T, T, bool> predicate;

    public LambdaComparer(Func<T, T, bool> predicate) {
      this.predicate = predicate;
    }

    /// <summary>
    /// Implementation of <see cref="IEqualityComparer{T}"/>
    /// </summary>
    /// <param name="t1">The first object</param>
    /// <param name="t2">The second object</param>
    /// <returns><see cref="Boolean"/> with the value of true indicating the values are equal or a false - indicating that the values differ.</returns>
    public bool Equals(T t1, T t2) {
      return this.predicate(t1, t2);
    }

    //
    // We need to always return the same hash code. Otherwise,
    // two objects that we consider equal may be thought to be
    // unequal because they hash to distinct values.
    //
    public int GetHashCode(T t) {
      return 0;
    }
  }
}