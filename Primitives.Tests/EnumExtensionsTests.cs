using System;
using System.ComponentModel;
using Xunit;

namespace Primitives.Tests {
  public class EnumExtensionsTests
  {

    public enum TestEnum
    {
      [Description("First")]
      One = 1,

      [Description]
      Two = 2,

      Three,
    }


    [Fact]
    public void GetDescription_Returns_Member_Name_If_Description_Is_Not_Present()
    {
      var value = TestEnum.Three;

      string actual   = value.GetDescription();
      string expected = "Three";

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetDescription_Returns_Null_If_Description_Is_Present_Without_Value()
    {
      var value = TestEnum.Two;

      string actual   = value.GetDescription();
      string expected = "";

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetDescription_Returns_Description_Value_If_Description_Is_Present_With_Value()
    {
      var value = TestEnum.One;

      string actual   = value.GetDescription();
      string expected = "First";

      Assert.Equal(expected, actual);
    }
  }
}