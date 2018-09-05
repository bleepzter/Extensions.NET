namespace System.Collections.Generic {

  /// <summary> Extension methods for dictionary implementations. </summary>
  // ReSharper disable once InconsistentNaming
  public static class IDictionaryExtensions {

    /// <summary>
    /// Returns a value for a given key. If there is no value for that key, a default(T) is returned for the value.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of the key used by the dictionary.</typeparam>
    /// <typeparam name="TValue">Represents the type of the value in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary where we are searching for values.</param>
    /// <param name="key">The key used to find the value.</param>
    /// <returns> Returns a value for a given key. If there is no value for that key, a default(T) is returned for the value.</returns>
    /// <exception cref="NullReferenceException">If the dictionary is null.</exception>
    public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) {

      if (dictionary == null)
        throw new NullReferenceException(nameof(dictionary));

      TValue result;
      return dictionary.TryGetValue(key, out result) ? result : default(TValue);
    }

    /// <summary>
    /// Returns a value for a given key or if the value (or key) is not found - it returns a user specified value.
    /// </summary>
    /// <typeparam name="TKey">Represents the type of the key used by the dictionary.</typeparam>
    /// <typeparam name="TValue">Represents the type of the value in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary where we are searching for values.</param>
    /// <param name="key">The key used to find the value.</param>
    /// <param name="defaultValue">The user supplied default value in case a value with the associated key is not found.</param>
    /// <returns>Returns a value for a given key or if the value (or key) is not found - it returns a user specified value.</returns>
    /// <exception cref="NullReferenceException">If the dictionary is null.</exception>
    public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue) {
      if(dictionary == null)
        throw new NullReferenceException(nameof(dictionary));

      TValue result;
      return dictionary.TryGetValue(key, out result) ? result : defaultValue;
    }

    /// <summary>
    /// Adds a sequence to a dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the key of the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the value of the dictionary.</typeparam>
    /// <typeparam name="T">The type of the </typeparam>
    /// <param name="dictionary">The dictionary to which we are adding new entries.</param>
    /// <param name="sequence">The sequence whose elements we are transforming into a dictionary.</param>
    /// <param name="keyAccessor">Provides means to get a dictionary key from each sequence item.</param>
    /// <param name="valueAccessor">Provides means to get a dictionary value from each sequence item. </param>
    /// <exception cref="NullReferenceException">If the dictionary is null.</exception>
    /// <exception cref="ArgumentNullException">If the key accessor is null.</exception>
    /// <exception cref="ArgumentNullException">If the value accessor is null.</exception>
    /// <exception cref="InvalidOperationException">If the key accessor of any of the items in the sequence returns null.</exception>
    public static void AddRange<TKey, TValue, T>(this IDictionary<TKey, TValue> dictionary, IEnumerable<T> sequence, Func<T, TKey> keyAccessor, Func<T, TValue> valueAccessor) {

      if(dictionary == null)
        throw new NullReferenceException(nameof(dictionary));

      if (keyAccessor == null)
        throw new ArgumentNullException(nameof(keyAccessor));

      if(valueAccessor == null)
        throw new ArgumentNullException(nameof(valueAccessor));

      foreach(var element in sequence) {
        var key = keyAccessor(element);

        if(object.ReferenceEquals(key, null))
          throw new InvalidOperationException();

        var value = valueAccessor(element);
        dictionary.Add(key, value);
      }
    }

    /// <summary>
    /// Adds the key-value paris of a given dictionary into the current instance.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="dictionary">The dictionary to which values will be added.</param>
    /// <param name="other">The dictionary that acts as source of values.</param>
    /// <exception cref="NullReferenceException">If the dictionary is null.</exception>
    /// <exception cref="InvalidOperationException">If the key of any of the key value pairs is null.</exception>
    public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> other) {
      if(dictionary == null)
        throw new NullReferenceException(nameof(dictionary));

      if (other == null)
        return;

      foreach(var pair in other) {

        if(object.ReferenceEquals(pair.Key, null))
          throw new InvalidOperationException();

        dictionary.Add(pair.Key, pair.Value);
      }
    }

    /// <summary>
    /// Adds a sequence of tupple records to the current dictionary instance.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="dictionary">The dictionary to which values will be added.</param>
    /// <param name="keyValuePairs">A sequence of tupple records.</param>
    /// <exception cref="NullReferenceException">If the dictionary is null.</exception>
    /// <exception cref="InvalidOperationException">If the key of any of the key value pairs is null.</exception>
    public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<Tuple<TKey, TValue>> keyValuePairs) {

      if(dictionary == null)
        throw new NullReferenceException(nameof(dictionary));

      if(keyValuePairs == null)
        return;

      foreach(var pair in keyValuePairs) {

        if(object.ReferenceEquals(pair.Item1, null))
          throw new InvalidOperationException();

        dictionary.Add(pair.Item1, pair.Item2);
      }
    }

    /// <summary>
    /// Adds a sequence of key value pairs the current dictionary instance.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="dictionary">The dictionary to which values will be added.</param>
    /// <param name="keyValuePairs">Sequence of key value pairs.</param>
    /// <exception cref="NullReferenceException">If the dictionary is null.</exception>
    /// <exception cref="InvalidOperationException">If the key of any of the key value pairs is null.</exception>
    public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs) {

      if(dictionary == null)
        throw new NullReferenceException(nameof(dictionary));

      if(keyValuePairs == null)
        return;

      foreach(var pair in keyValuePairs) {

        if(object.ReferenceEquals(pair.Key, null))
          throw new InvalidOperationException();

        dictionary.Add(pair.Key, pair.Value);
      }
    }
  }
}
