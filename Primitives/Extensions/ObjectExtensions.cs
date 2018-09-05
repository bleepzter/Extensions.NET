using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace System {

  /// <summary>
  /// Extension methods for the object type.
  /// </summary>
  public static class ObjectExtensions {

    /// <summary>
    /// Checks an object if it is null.
    /// </summary>
    /// <param name="o">The object.</param>
    /// <returns>A <see cref="bool"/> <c>true</c> value if the object is null, <c>false</c> value otherwise.</returns>
    public static bool IsNull(this object o) {
      return object.ReferenceEquals(o, null);
    }

    /// <summary>
    /// Returns the second parameter if the first is null.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="x">The first parameter.</param>
    /// <param name="y">Acts as a replacement value if the first parameter is null.</param>
    /// <returns>An instance of <see cref="T"/>.</returns>
    public static T Coalesce<T>(this T x, T y) where T : class
    {
      return x ?? y;
    }

    /// <summary>
    /// Returns the second parameter if the first is null.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="x">The first parameter.</param>
    /// <param name="y">Acts as a replacement value if the first parameter is null.</param>
    /// <returns>An instance of <see cref="T"/>.</returns>
    public static T Coalesce<T>(this T? x, T y) where T : struct
    {
      return x ?? y;
    }
 
    /// <summary>
    /// Converts a single object to an <see cref="IEnumerable{T}"/> of the same type
    /// </summary>
    /// <typeparam name="T">Describes the type of the object.</typeparam>
    /// <param name="object">The object to convert to enumerable.</param>
    /// <returns><see cref="IEnumerable{T}"/>.</returns>
    public static IEnumerable<T> ToEnumerable<T>(this T @object) {

      if(@object == null) {
        yield break;
      }

      yield return @object;
    }

    /// <summary>
    /// Makes a deep copy of an object by serializing it to a stream and then deserializing a new instance.
    /// </summary>
    /// <typeparam name="T">The type of the object to clone.</typeparam>
    /// <param name="object">The object to clone.</param>
    /// <returns>A deep copy of the object</returns>
    /// <exception cref="NullReferenceException">If the object being cloned is null.</exception>
    public static bool TryClone<T>(this T @object, out T result) {

      if (@object == null)
        throw new NullReferenceException(nameof(@object));

      try {
        var json = JsonConvert.SerializeObject(@object);
        result = (T) JsonConvert.DeserializeObject<T>(json);
        return true;
      }
      catch {
        result = default(T);
        return false;
      }
    }

    /// <summary>
    /// Makes a deep copy of an object by serializing it to a stream and then deserializing a new instance.
    /// </summary>
    /// <typeparam name="T">The type of the object to clone.</typeparam>
    /// <param name="object">The object to clone.</param>
    /// <returns>A deep copy of the object</returns>
    /// <exception cref="NullReferenceException">If the object being cloned is null.</exception>
    public static T Clone<T>(this T @object)
    {
      if (@object == null)
        throw new NullReferenceException(nameof(@object));

      var json = JsonConvert.SerializeObject(@object);
      return (T)JsonConvert.DeserializeObject<T>(json);
    }
  }
}