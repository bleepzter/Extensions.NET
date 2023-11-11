using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

// ReSharper disable once CheckNamespace
namespace System {
  /// <summary>
  /// Extension methods for the string data type.
  /// </summary>
  public static class StringExtensions {

    /// <summary>
    /// Checks to see if a string is null or empty
    /// </summary>
    /// <param name="input">The string</param>
    /// <returns><c>true</c> if null or empty, <c>false</c> otherwise. </returns>
    public static bool IsNullOrEmpty(this string input) {
      return string.IsNullOrEmpty(input);
    }

    /// <summary>
    /// Checks to see if a string is null or white space
    /// </summary>
    /// <param name="input">The string</param>
    /// <returns><c>true</c> if null or white space, <c>false</c> otherwise.</returns>
    public static bool IsNullOrWhiteSpace(this string input) {
      return string.IsNullOrWhiteSpace(input);
    }

    /// <summary>
    /// Checks to see if a string is null or empty or white space
    /// </summary>
    /// <param name="input">The string</param>
    /// <returns><c>true</c> if null or empty or white space, <c>false</c> otherwise. </returns>
		public static bool IsNullOrEmptyOrWhiteSpace(this string input)
    {
	    return string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input);
    }
    
    /// <summary>
    /// Parses a string to an enum value of type T or throws an exception.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="input">The string.</param>
    /// <returns>Instance of the enum.</returns>
    /// <exception cref="ArgumentException">When T is not an enum.</exception>
    public static T ToEnum<T>(this string input) where T : struct {

      if(!typeof(T).GetTypeInfo().IsEnum) {
        throw new ArgumentException("T is not a valid enum.");
      }

      if(Enum.TryParse<T>(input, true, out var result))
        return result;

      throw new ArgumentException($"The specified string value {input} cannot be converted to an enum value of type: {typeof(T)}");
    }

    /// <summary>
    /// Parses a string into an enum. If not successful it returns system default value for the enum.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="input">The string.</param>
    /// <returns>Instance of the enum.</returns>
    /// <exception cref="ArgumentException">When T is not an enum.</exception>
    public static T ToEnumOrDefault<T>(this string input) where T : struct {

      if(!typeof(T).GetTypeInfo().IsEnum) {
        throw new ArgumentException("T is not a valid enum.");
      }

      return !Enum.TryParse<T>(input, true, out var result) ? default(T) : result;
    }

    /// <summary>
    /// Parses a string into an enum. If not successful it returns the user specified default value for the enum.
    /// </summary>
    /// <typeparam name="T">The type of the enum.</typeparam>
    /// <param name="input">The string.</param>
    /// <param name="defaultValue">User supplied default value for the enum if conversion is not successful.</param>
    /// <returns>Instance of the enum.</returns>
    /// <exception cref="ArgumentException">When T is not an enum.</exception>
    public static T ToEnumOrDefault<T>(this string input, T defaultValue) where T : struct {

      if(!typeof(T).GetTypeInfo().IsEnum) {
        throw new ArgumentException("T is not a valid enum.");
      }

      return !Enum.TryParse<T>(input, true, out var result) ? defaultValue : result;
    }

    /// <summary>
    /// Returns a value indicating whether the specified <see cref="string"/> object occurs within the <paramref name="input"/> string.
    /// A parameter specifies the type of search to use for the specified string.
    /// </summary>
    /// <param name="input">The string to search in</param>
    /// <param name="value">The string to seek</param>
    /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search</param>
    /// <exception cref="ArgumentNullException"><paramref name="input"/> or is <c>null</c></exception>
    /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a valid <see cref="StringComparison"/> value</exception>
    /// <returns>
    /// <c>true</c> if the <paramref name="value"/> parameter occurs within the <paramref name="input"/> parameter, 
    /// or if <paramref name="value"/> is the empty string (<c>""</c>); 
    /// otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// The <paramref name="comparisonType"/> parameter specifies to search for the value parameter using the current or invariant culture, 
    /// using a case-sensitive or case-insensitive search, and using word or ordinal comparison rules.
    /// </remarks>
    public static bool Contains(this string input, string value, StringComparison comparisonType) {
      if(input == null) {
        throw new ArgumentNullException(nameof(input));
      }

      if(value == null) {
        return false;
      }

      return input.IndexOf(value, comparisonType) >= 0;
    }

    /// <summary>
    /// Removes the first occurance of a piece of the string based on an match.
    /// </summary>
    /// <param name="input">The string to remove from.</param>
    /// <param name="whatToRemove">The string to remove</param>
    /// <param name="caseSensitive">A flag indicating if the string to be removed should be searched for in a case sensitive manner.</param>
    /// <returns><see cref="string"/> with the content removed from it.</returns>
    public static string Remove(this string input, string whatToRemove, bool caseSensitive = true) {
      if (input.IsNullOrEmpty())
        return input;

      if (string.IsNullOrEmpty(whatToRemove))
        return input;

      var stringComparison = caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

      var firstIndex = input.IndexOf(whatToRemove, stringComparison);

      if (firstIndex < 0) //The parameter "whatToRemove" was not found.
        return input;

      var result = input.Substring(0, firstIndex);
      result += input.Substring(firstIndex + whatToRemove.Length);

      return result;
    }

    /// <summary>
    /// Trims a string from both ends. This method matches the search parameter as a whole and removes it from the front and back of the string if it exists.
    /// </summary>
    /// <param name="input">The string.</param>
    /// <param name="whatToTrim">The stuff to trim.</param>
    /// <param name="caseSensitive">A flag indicating if the string to be removed from both ends of the underlying string should be matched in a case sensitive manner.</param>
    /// <returns>String</returns>
    public static string Trim(this string input, string whatToTrim, bool caseSensitive = true) {
      
      if (input.IsNullOrEmpty())
        return input;

      var result = input;

      var stringComparison = caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

      if (result.StartsWith(whatToTrim, stringComparison))
        result = result.Substring(whatToTrim.Length);

      if (result.IsNullOrEmpty())
        return result;

      if(result.EndsWith(whatToTrim, stringComparison)) {
        int resultLength = result.Length;
        int trimLenght = whatToTrim.Length;

        result = result.Substring(0, (resultLength - trimLenght));
      }

      return result;
    }

    /// <summary>
    /// Trims at the end.  This method matches the search parameter as a whole and removes it from the back of the string if it exists.
    /// </summary>
    /// <param name="input">The string.</param>
    /// <param name="whatToTrim">The stuff to trim.</param>
    /// <param name="caseSensitive">A flag indicating if the string to be removed from the right end of the underlying string should be matched in a case sensitive manner.</param>
    /// <returns>String</returns>
    public static string TrimEnd(this string input, string whatToTrim, bool caseSensitive = true) {
      if(input.IsNullOrEmpty())
        return input;

      var result = input;

      var stringComparison = caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

      if(result.EndsWith(whatToTrim, stringComparison)) {
        int resultLenght = result.Length;
        int trimLenght = whatToTrim.Length;

        result = result.Substring(0, (resultLenght - trimLenght));
      }

      return result;
    }

    /// <summary> Trims a string from the begining.  This method matches the search parameter as a whole and removes it from the front of the string if it exists. </summary>
    /// <param name="input">The string.</param>
    /// <param name="whatToTrim">The stuff to trim.</param>
    /// <param name="caseSensitive">A flag indicating if the string to be removed from the left end of the underlying string should be matched in a case sensitive manner.</param>
    /// <returns>String</returns>
    public static string TrimStart(this string input, string whatToTrim, bool caseSensitive = true) {

      if(input.IsNullOrEmpty())
        return input;

      var result = input;

      var stringComparison = caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

      if(result.StartsWith(whatToTrim, stringComparison))
        result = result.Substring(whatToTrim.Length);

      return result;
    }

    /// <summary>
    /// Converts a string to Base64 encoded string with an optonal user supplied encoding.
    /// </summary>
    /// <param name="input">The actual string</param>
    /// <param name="encoding">An optional <see cref="Encoding"/>. If the Encoding is not supplied UTF8 will be used by default.</param>
    /// <returns>A base 64 encoded <see cref="string"/>.</returns>
    public static string ToBase64String(this string input, Encoding encoding = null) {

      if (input == null)
        return null;

      var actualEncoding = encoding ?? Encoding.UTF8;
      var bytes = actualEncoding.GetBytes(input);

      return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// Converts a Base64 encoded string to a regular string with an optonal user supplied encoding.
    /// </summary>
    /// <param name="input">The actual string</param>
    /// <param name="encoding">An optional <see cref="Encoding"/>. If the Encoding is not supplied UTF8 will be used by default.</param>
    /// <returns>A base 64 encoded <see cref="string"/>.</returns>
    public static string FromBase64String(this string input, Encoding encoding = null) {

      if(input == null)
        return null;

      var actualEncoding = encoding ?? Encoding.UTF8;
      var bytes = Convert.FromBase64String(input);

      return actualEncoding.GetString(bytes);
    }

    /// <summary>
    /// Gets a SHA1 hash from a string.
    /// </summary>
    /// <param name="input">A string</param>
    /// <returns>A hex encoded string representing a SHA1 hash.</returns>
    // ReSharper disable once InconsistentNaming
    public static string ToSHA1Hash(this string input) {

      if (input.IsNullOrEmpty())
        return null;

      var encoding = Encoding.ASCII;
      var data = encoding.GetBytes(input);

      using(var sha1 = SHA1.Create()) {
        var hash = sha1.ComputeHash(data);
        return BitConverter.ToString(hash).ToLower().Replace("-", "");
      }
    }

    /// <summary>
    /// Gets an MD5 hash from a string.
    /// </summary>
    /// <param name="input">A string</param>
    /// <returns>A hex encoded string representing a MD5 hash.</returns>
    // ReSharper disable once InconsistentNaming
    public static string ToMD5Hash(this string input) {
      if (input.IsNullOrEmpty())
        return null;

      var encoding = Encoding.ASCII;
      var data = encoding.GetBytes(input);

      using (var md5 = MD5.Create())
      {
        var hash = md5.ComputeHash(data);
        return BitConverter.ToString(hash).ToLower().Replace("-", "");
      }
    }

    /// <summary>
    /// Converts a string to the hex representation of its characters.  
    /// </summary>
    /// <param name="input">The string to convert to hex</param>
    /// <returns>A <see cref="string"/> of hex characters</returns>
    public static string ToHex(this string input)
    {
      return string.Concat(Encoding.UTF8.GetBytes(input).Select(x => x.ToString("x2")));
    }

    /// <summary>
    /// Converts a string of hex characters to the equivalent UTF8 encoded string.
    /// </summary>
    /// <param name="hex">The hex string to convert</param>
    /// <returns>A UTF8 encoded <see cref="string"/></returns>
    public static string FromHex(this string hex)
    {
      return Encoding.UTF8.GetString(Enumerable.Range(0, hex.Length / 2).Select(x => Byte.Parse(hex.Substring(2 * x, 2), NumberStyles.HexNumber)).ToArray());
    }

    /// <summary>
    /// Gets the bytes out of a string.
    /// </summary>
    /// <param name="input">The string.</param>
    /// <returns>A byte array representing the characters of the string.</returns>
    public static byte[] ToBytes(this string input) {
      if(input.IsNullOrEmpty())
        return Array.Empty<byte>();

      return Encoding.ASCII.GetBytes(input);
    }

    /// <summary>
    /// Indicates if the regex finds a match in the current string
    /// </summary>
    /// <param name="input">The string</param>
    /// <param name="regexPattern">The regular expression patern</param>
    /// <returns>True or false</returns>
    public static bool IsRegexMatch(this string input, string regexPattern) {

      if (input.IsNullOrEmpty())
        return false;

      if (regexPattern.IsNullOrEmpty())
        return false;

      Regex regex = new Regex(regexPattern);
      return regex.IsMatch(input);
    }
  }
}