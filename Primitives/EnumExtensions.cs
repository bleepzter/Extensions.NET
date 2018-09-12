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

      FieldInfo field = null;

#if (NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472)
      field = enumType.GetField(value.ToString());
#elif (NETSTD13 || NETSTD14 || NETSTD15)
      field = enumType.GetTypeInfo().GetDeclaredField(value.ToString());
#elif (NETSTD16 || NETSTD20)
      field = enumType.GetTypeInfo().GetField(value.ToString());
#endif
      var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false).ToArray();

      return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
    }
  }
}