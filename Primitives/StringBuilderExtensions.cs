using System.Text;

namespace System.Text {
  public static class StringBuilderExtensions {

    /// <summary>
    /// Trims the beginning and the end of the contents of a <see cref="StringBuilder"/>
    /// </summary>
    /// <param name="sb">The <see cref="StringBuilder"/></param>
    /// <param name="whatToTrim">The characters to trim.</param>
    /// <param name="caseSensitive">Whether the trim character matching is case sensitive.</param>
    /// <exception cref="ArgumentNullException">If the <paramref name="sb"/> is null.</exception>
    public static void Trim(this StringBuilder sb, string whatToTrim, bool caseSensitive = true)
    {
      if (sb == null)
        throw new ArgumentNullException(nameof(sb));

      if (whatToTrim.IsNullOrEmpty())
        return;

      var temp = sb.ToString();
      temp.Trim(whatToTrim, caseSensitive);

      sb.Clear();
      sb.Append(temp);
      return;
    }

		/// <summary>
		/// Trims the beginning of the contents of a <see cref="StringBuilder"/>
		/// </summary>
		/// <param name="sb">The <see cref="StringBuilder"/></param>
		/// <param name="whatToTrim">The characters to trim.</param>
		/// <param name="caseSensitive">Whether the trim character matching is case sensitive.</param>
		/// <exception cref="ArgumentNullException">If the <paramref name="sb"/> is null.</exception>
		public static void TrimStart(this StringBuilder sb, string whatToTrim, bool caseSensitive = true)
    {
      if (sb == null)
        throw new ArgumentNullException(nameof(sb));

      if (whatToTrim.IsNullOrEmpty())
        return;

      var temp = sb.ToString();
      temp.TrimStart(whatToTrim, caseSensitive);

      sb.Clear();
      sb.Append(temp);
      return;
    }

		/// <summary>
		/// Trims the end of the contents of a <see cref="StringBuilder"/>
		/// </summary>
		/// <param name="sb">The <see cref="StringBuilder"/></param>
		/// <param name="whatToTrim">The characters to trim.</param>
		/// <param name="caseSensitive">Whether the trim character matching is case sensitive.</param>
		/// <exception cref="ArgumentNullException">If the <paramref name="sb"/> is null.</exception>
		public static void TrimEnd(this StringBuilder sb, string whatToTrim, bool caseSensitive = true)
    {
      if (sb == null)
        throw new ArgumentNullException(nameof(sb));

      if (whatToTrim.IsNullOrEmpty())
        return;

      var temp = sb.ToString();
      temp.TrimEnd(whatToTrim, caseSensitive);

      sb.Clear();
      sb.Append(temp);
      return;
    }
  }
}