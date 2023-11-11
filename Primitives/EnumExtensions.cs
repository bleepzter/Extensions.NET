using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace System {

  /// <summary>
  /// Extension methods for enum types.
  /// </summary>
  public static class EnumExtensions {

    /// <summary>
    /// Retrieves the value of the <see cref="DescriptionAttribute"/> of an enum member
    /// </summary>
    /// <param name="value">Enum member.</param>
    /// <returns>String</returns>
    public static string GetDescription(this Enum value) {

      var enumType = value.GetType();

      var field = enumType.GetTypeInfo().GetField(value.ToString());

      if (field == null)
      {
	      return null;
      }

      var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false).ToArray();

      return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
    }
  }
}