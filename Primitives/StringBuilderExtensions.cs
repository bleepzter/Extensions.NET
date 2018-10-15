using System.Text;

namespace System.Text {
  public static class StringBuilderExtensions {

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