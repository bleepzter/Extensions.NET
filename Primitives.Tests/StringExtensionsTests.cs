using System;
using System.Text;
using Xunit;

namespace Primitives.Tests
{
  public class StringExtensionsTests
  {
    public enum TestEnum
    {
      One,
      Two,
      Three
    }

    #region - Is Null Or Empty -

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_String_Is_Null()
    {
      string test = null;

      var expectedValue = true;
      var actualValue = test.IsNullOrEmpty();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_True_When_String_Is_Empty()
    {
      string test = string.Empty;

      var expectedValue = true;
      var actualValue = test.IsNullOrEmpty();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_String_Is_NewLine()
    {
      string test = Environment.NewLine;

      var expectedValue = false;
      var actualValue = test.IsNullOrEmpty();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_String_Is_Tab()
    {
      string test = "\t";

      var expectedValue = false;
      var actualValue = test.IsNullOrEmpty();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_String_Is_Space()
    {
      string test = " ";

      var expectedValue = false;
      var actualValue = test.IsNullOrEmpty();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrEmpty_Returns_False_When_String_Is_Anything()
    {
      string test = "asdfasd";

      var expectedValue = false;
      var actualValue = test.IsNullOrEmpty();

      Assert.Equal(expectedValue, actualValue);
    }

    #endregion

    #region - Is Null Or White Space -

    [Fact]
    public void IsNullOrWhiteSpace_Returns_True_When_String_Is_Null()
    {
      string test = null;

      var expectedValue = true;
      var actualValue = test.IsNullOrWhiteSpace();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrWhiteSpace_Returns_True_When_String_Is_Empty()
    {
      string test = string.Empty;

      var expectedValue = true;
      var actualValue = test.IsNullOrWhiteSpace();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrWhiteSpace_Returns_True_When_String_Is_NewLine()
    {
      string test = Environment.NewLine;

      var expectedValue = true;
      var actualValue = test.IsNullOrWhiteSpace();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrWhiteSpace_Returns_True_When_String_Is_Tab()
    {
      string test = "\t";

      var expectedValue = true;
      var actualValue = test.IsNullOrWhiteSpace();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrWhiteSpace_Returns_True_When_String_Is_Space()
    {
      string test = " ";

      var expectedValue = true;
      var actualValue = test.IsNullOrWhiteSpace();

      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void IsNullOrWhiteSpace_Returns_False_When_String_Is_Anything()
    {
      string test = "asdfasd";

      var expectedValue = false;
      var actualValue = test.IsNullOrWhiteSpace();

      Assert.Equal(expectedValue, actualValue);
    }

    #endregion

    #region - To Enum -

    [Fact]
    public void ToEnum_Throws_Exception_If_Type_Argument_Is_Not_Enum()
    {
      string test = null;

      Assert.Throws<ArgumentException>(() => test.ToEnum<double>());
    }

    [Fact]
    public void ToEnum_Throws_Exception_If_Input_Argument_Is_Null()
    {
      string test = null;

      Assert.Throws<ArgumentException>(() => test.ToEnum<TestEnum>());
    }

    [Fact]
    public void ToEnum_Throws_Exception_If_Input_Argument_Does_Not_Match_Enum_Members()
    {
      string test = "Asdf";

      Assert.Throws<ArgumentException>(() => test.ToEnum<TestEnum>());
    }

    [Fact]
    public void ToEnum_Retruns_Enum_Instance_If_Input_Argument_Matches_Exeactly_Any_Enum_Members()
    {
      string test = "Two";

      var expected = TestEnum.Two;
      var actual = test.ToEnum<TestEnum>();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToEnum_Retruns_Enum_Instance_If_Input_Argument_Matches_Case_Insensitive_Any_Enum_Members()
    {
      string test = "two";

      var expected = TestEnum.Two;
      var actual = test.ToEnum<TestEnum>();

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - To Enum Or Default -

    [Fact]
    public void ToEnumOrDefault_Throws_Exception_If_Type_Argument_Is_Not_Enum()
    {
      string test = null;

      Assert.Throws<ArgumentException>(() => test.ToEnumOrDefault<double>());
    }

    [Fact]
    public void ToEnumOrDefault_Returns_Default_Enum_Value_If_Input_Argument_Is_Null()
    {
      string test = null;

      var expected = TestEnum.One;
      var actual = test.ToEnumOrDefault<TestEnum>();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToEnumOrDefault_Returns_Default_Enum_Value_If_Input_Argument_Does_Not_Match_Enum_Members()
    {
      string test = "Asdf";

      var expected = TestEnum.One;
      var actual = test.ToEnumOrDefault<TestEnum>();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToEnumOrDefault_Retruns_Enum_Instance_If_Input_Argument_Matches_Exeactly_Any_Enum_Members()
    {
      string test = "Two";

      var expected = TestEnum.Two;
      var actual = test.ToEnumOrDefault<TestEnum>();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToEnumOrDefault_Retruns_Enum_Instance_If_Input_Argument_Matches_Case_Insensitive_Any_Enum_Members()
    {
      string test = "two";

      var expected = TestEnum.Two;
      var actual = test.ToEnumOrDefault<TestEnum>();

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - To Enum Or Default With User Value-

    [Fact]
    public void ToEnumOrDefault_With_User_Value_Returns_User_Value_If_Input_Argument_Is_Null()
    {
      string test = null;

      var expected = TestEnum.Three;
      var actual = test.ToEnumOrDefault<TestEnum>(TestEnum.Three);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToEnumOrDefault_With_User_Value_Returns_User_Value_If_Input_Argument_Does_Not_Match_Enum_Members()
    {
      string test = "Asdf";

      var expected = TestEnum.Three;
      var actual = test.ToEnumOrDefault<TestEnum>(TestEnum.Three);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToEnumOrDefault_With_User_Value_Retruns_Enum_Instance_If_Input_Argument_Matches_Exeactly_Any_Enum_Members()
    {
      string test = "Two";

      var expected = TestEnum.Two;
      var actual = test.ToEnumOrDefault<TestEnum>(TestEnum.Three);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToEnumOrDefault_With_User_Value_Retruns_Enum_Instance_If_Input_Argument_Matches_Case_Insensitive_Any_Enum_Members()
    {
      string test = "two";

      var expected = TestEnum.Two;
      var actual = test.ToEnumOrDefault<TestEnum>(TestEnum.Three);

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - Contains -

    [Fact]
    public void Contains_Throws_Exception_If_Underlying_String_Is_Null()
    {
      string test = null;

      Assert.Throws<NullReferenceException>(() => test.Contains("asdf", StringComparison.CurrentCulture));
    }

    [Fact]
    public void Contains_Throws_Exception_If_Search_String_Is_Null()
    {
      string test = "This is a test";
      Assert.Throws<ArgumentNullException>(() => test.Contains(null, StringComparison.CurrentCulture));
    }

    [Fact]
    public void Contains_Returns_False_If_Search_String_Is_Not_Contained_Case_Sensitive()
    {
      string test = "This is a test";

      var expected = false;
      var actual = test.Contains("ASDF", StringComparison.CurrentCulture);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Contains_Returns_False_If_Search_String_Is_Not_Contained_Case_Insensitive()
    {
      string test = "This is a test";

      var expected = false;
      var actual = test.Contains("ASDF", StringComparison.CurrentCultureIgnoreCase);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Contains_Returns_False_If_Search_String_Is_Semantically_Contained_But_Comparison_Is_Case_Sensitive()
    {
      string test = "This is a test";

      var expected = false;
      var actual = test.Contains("Test", StringComparison.CurrentCulture);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Contains_Returns_True_If_Search_String_Is_Semantically_Contained_But_Comparison_Is_Case_Insensitive()
    {
      string test = "This is a test";

      var expected = true;
      var actual = test.Contains("Is A", StringComparison.CurrentCultureIgnoreCase);

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - Remove -

    [Fact]
    public void Remove_Returns_Null_If_Underlying_String_Is_Null()
    {
      string test = null;

      var actual = test.Remove("asdf");

      Assert.Null(actual);
    }

    [Fact]
    public void Remove_Returns_Empty_If_Underlying_String_Is_Empty()
    {
      string test = string.Empty;

      var expected = string.Empty;
      var actual = test.Remove("asdf");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_Returns_Self_If_Search_String_Is_Null()
    {
      string test = "test";

      var expected = "test";
      var actual = test.Remove(null);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_Returns_Self_If_Search_String_Is_Empty()
    {
      string test = "test";

      var expected = "test";
      var actual = test.Remove(string.Empty);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_Returns_Self_If_Search_String_Is_NewLine()
    {
      string test = "test";

      var expected = "test";
      var actual = test.Remove(Environment.NewLine);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_Returns_Self_If_Search_String_Is_Longer_Than_Self()
    {
      string test = "test";

      var expected = "test";
      var actual = test.Remove("this is a test");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_Returns_Self_If_Search_String_Not_Found()
    {
      string test = "test";

      var expected = "test";
      var actual = test.Remove("ab");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_Returns_Self_If_Search_String_Not_Found_Case_Sensitive()
    {
      string test = "test";

      var expected = "test";
      var actual = test.Remove("Es", true);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_Removes_Matched_Parameter_When_Searched_String_Is_Found_Case_Insensitive()
    {
      string test = "test";

      var expected = "tt";
      var actual = test.Remove("Es", false);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Remove_Removes_NewLine_If_Newline_Is_Found()
    {
      string test = "test" + Environment.NewLine + 123;

      var expected = "test123";
      var actual   = test.Remove(Environment.NewLine);

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - Trim -

    [Fact]
    public void Trim_Returns_Null_When_Underlying_String_Is_Null()
    {
      string input = null;

      var actual = input.Trim("things to trim");

      Assert.Null(actual);
    }

    [Fact]
    public void Trim_Returns_Empty_When_Underlying_String_Is_Empty()
    {
      string input = string.Empty;

      var expected = string.Empty;
      var actual = input.Trim("things to trim");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Trim_Returns_Self_When_Trim_Parameter_Not_Found_Regardless_Of_Case()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2test";
      var actual = input.Trim("things to trim");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Trim_Does_Not_Trim_From_Front_When_Trim_Parameter_Not_Found_With_Case_Sensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2test";
      var actual = input.Trim("Test1");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Trim_Removes_From_Front_When_Trim_Parameter_Is_Found_With_Case_Insensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = " someotherstuff 2test";
      var actual = input.Trim("Test1", false);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Trim_Does_Not_Trim_From_Back_When_Trim_Parameter_Not_Found_With_Case_Sensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2test";
      var actual = input.Trim("2Test");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Trim_Removes_From_Back_When_Trim_Parameter_Is_Found_With_Case_Insensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff ";
      var actual = input.Trim("2Test", false);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Trim_Does_Not_Trim_From_Front_And_Back_When_Trim_Parameter_Not_Found_With_Case_Sensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2test";
      var actual = input.Trim("Test");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Trim_Removes_From_Front_And_Back_When_Trim_Parameter_Is_Found_With_Case_Insensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "1 someotherstuff 2";
      var actual = input.Trim("Test", false);

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - Trim Start -

    [Fact]
    public void TrimStart_Returns_Null_When_Underlying_String_Is_Null()
    {
      string input = null;

      var actual = input.TrimStart("things to trim");

      Assert.Null(actual);
    }

    [Fact]
    public void TrimStart_Returns_Empty_When_Underlying_String_Is_Empty()
    {
      string input = string.Empty;

      var expected = string.Empty;
      var actual = input.TrimStart("things to trim");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TrimStart_Returns_Self_When_Trim_Parameter_Not_Found_Regardless_Of_Case()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2test";
      var actual = input.TrimStart("things to trim");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TrimStart_Does_Not_Trim_When_Trim_Parameter_Not_Found_With_Case_Sensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2test";
      var actual = input.TrimStart("Test1");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TrimStart_Removes_From_Front_When_Trim_Parameter_Is_Found_With_Case_Insensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "1 someotherstuff 2test";
      var actual = input.TrimStart("Test", false);

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - Trim End -

    [Fact]
    public void TrimEnd_Returns_Null_When_Underlying_String_Is_Null()
    {
      string input = null;

      var actual = input.TrimEnd("things to trim");

      Assert.Null(actual);
    }

    [Fact]
    public void TrimEnd_Returns_Empty_When_Underlying_String_Is_Empty()
    {
      string input = string.Empty;

      var expected = string.Empty;
      var actual = input.TrimEnd("things to trim");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TrimEnd_Returns_Self_When_Trim_Parameter_Not_Found_Regardless_Of_Case()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2test";
      var actual = input.TrimEnd("things to trim");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TrimEnd_Does_Not_Trim_When_Trim_Parameter_Not_Found_With_Case_Sensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2test";
      var actual = input.TrimEnd("Test");

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void TrimEnd_Removes_From_Back_When_Trim_Parameter_Is_Found_With_Case_Insensitive_Matching()
    {
      string input = "test1 someotherstuff 2test";

      var expected = "test1 someotherstuff 2";
      var actual = input.TrimEnd("Test", false);

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - Base 64 Encoding -

    [Fact]
    public void ToBase64String_Returns_Null_If_Underlying_String_Is_Null()
    {
      string test = null;

      var actual = test.ToBase64String();

      Assert.Null(actual);
    }

    [Fact]
    public void ToBase64String_Returns_Correct_Base64EncodedString_With_Default_Encoding()
    {
      string test = "testing";

      var expected = "dGVzdGluZw==";
      var actual = test.ToBase64String();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToBase64String_Returns_Correct_Base64EncodedString_With_UTF7_Encoding()
    {
      string test = "testing";

      var expected = "dGVzdGluZw==";
      var actual = test.ToBase64String(Encoding.UTF7);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToBase64String_Returns_Correct_Base64EncodedString_With_UTF8_Encoding()
    {
      string test = "testing";

      var expected = "dGVzdGluZw==";
      var actual = test.ToBase64String(Encoding.UTF8);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToBase64String_Returns_Correct_Base64EncodedString_With_ASCII_Encoding()
    {
      string test = "testing";

      var expected = "dGVzdGluZw==";
      var actual = test.ToBase64String(Encoding.ASCII);

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - Base 64 Decoding -

    [Fact]
    public void FromBase64String_Returns_Null_If_Underlying_String_Is_Null()
    {
      string test = null;

      var actual = test.FromBase64String();

      Assert.Null(actual);
    }

    [Fact]
    public void FromBase64String_Returns_Correct_String_With_Default_Encoding()
    {
      string test = "dGVzdGluZw==";

      var expected = "testing";
      var actual = test.FromBase64String();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromBase64String_Returns_Correct_String_With_UTF7_Encoding()
    {
      string test = "dGVzdGluZw==";

      var expected = "testing";
      var actual = test.FromBase64String(Encoding.UTF7);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromBase64String_Returns_Correct_String_With_UTF8_Encoding()
    {
      string test = "dGVzdGluZw==";

      var expected = "testing";
      var actual = test.FromBase64String(Encoding.UTF8);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromBase64String_Returns_Correct_String_With_ASCII_Encoding()
    {
      string test = "dGVzdGluZw==";

      var expected = "testing";
      var actual = test.FromBase64String(Encoding.ASCII);

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - To SHA1 -

    [Fact]
    public void ToSHA1Hash_Returns_Null_If_Underlying_String_Is_Null()
    {
      string test = null;

      var actual = test.ToSHA1Hash();

      Assert.Null(actual);
    }

    [Fact]
    public void ToSHA1Hash_Returns_Null_If_Underlying_String_Is_Empty()
    {
      string test = string.Empty;

      var actual = test.ToSHA1Hash();

      Assert.Null(actual);
    }

    [Fact]
    public void ToSHA1Hash_Returns_Hash_If_Underlying_String_Is_Valid()
    {
      string test = "testing";

      var expected = "dc724af18fbdd4e59189f5fe768a5f8311527050";
      var actual = test.ToSHA1Hash();

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - To MD5 -

    [Fact]
    public void ToMD5Hash_Returns_Null_If_Underlying_String_Is_Null()
    {
      string test = null;

      var actual = test.ToMD5Hash();

      Assert.Null(actual);
    }

    [Fact]
    public void ToMD5Hash_Returns_Null_If_Underlying_String_Is_Empty()
    {
      string test = string.Empty;

      var actual = test.ToMD5Hash();

      Assert.Null(actual);
    }

    [Fact]
    public void ToMD5Hash_Returns_Hash_If_Underlying_String_Is_Valid()
    {
      string test = "ThisIsATest";

      var expected = "4c0b569e4c96df157eee1b65dd0e4d41";
      var actual   = test.ToMD5Hash();

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - To HEX -

    [Fact]
    public void ToHex_Throws_Exception_If_Underlying_String_Is_Null()
    {
      string test = null;

      Assert.Throws<ArgumentNullException>(() => test.ToHex());
    }

    [Fact]
    public void ToHex_Returns_Empty_If_Underlying_String_Is_Empty()
    {
      string test = string.Empty;

      var expected = string.Empty;
      var actual = test.ToHex();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToHex_Returns_Hex_String_If_Underlying_String_Is_Valid()
    {
      string test = "ThisIsATest";

      var expected = "5468697349734154657374";
      var actual   = test.ToHex();

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - From HEX -

    [Fact]
    public void FrowmHex_Throws_Exception_If_Underlying_String_Is_Null()
    {
      string test = null;

      Assert.Throws<NullReferenceException>(() => test.FromHex());
    }

    [Fact]
    public void FromHex_Returns_Empty_If_Underlying_String_Is_Empty()
    {
      string test = string.Empty;

      var expected = string.Empty;
      var actual   = test.FromHex();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void FromHex_Returns_Valid_String_If_Underlying_Hex_String_Is_Valid()
    {
      string test = "5468697349734154657374";

      var expected = "ThisIsATest";
      var actual   = test.FromHex();

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - To Bytes -

    [Fact]
    public void ToBytes_Returns_Empty_If_Underlying_String_Is_Null()
    {
      string test = null;
      
      byte[] expected = new byte[0];
      var actual = test.ToBytes();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToBytes_Returns_Empty_If_Underlying_String_Is_Empty()
    {
      string test = string.Empty;

      var expected = new byte[0];
      var actual   = test.ToBytes();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToBytes_Returns_Byte_Array_If_Underlying_String_Is_Valid()
    {
      string test = "ThisIsATest";

      var expected = new byte[] {(byte) 84, (byte) 104, (byte) 105, (byte) 115, (byte) 73, (byte) 115, (byte) 65, (byte) 84, (byte) 101, (byte) 115, (byte) 116};
      var actual   = test.ToBytes();

      Assert.Equal(expected, actual);
    }

    #endregion

    #region - IsRegexMatch Tests - 

    [Fact]
    public void Match_Returns_False_When_Input_Is_Null()
    {
      string test = null;
      string regex =
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

      var expected = false;
      var actual = test.IsRegexMatch(regex);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Match_Returns_False_When_Regex_Is_Null()
    {
      string test = "martin_stefanov@test.abc.com";
      string regex = null;

      var expected = false;
      var actual = test.IsRegexMatch(regex);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Match_Returns_True_When_Regex_Matches_Term()
    {
      string test = "martin_stefanov@test.abc.com";
      string regex =
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

      var expected = true;
      var actual = test.IsRegexMatch(regex);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Match_Returns_False_When_Regex_Does_Not_Match_Term()
    {
      string test = "martin_stefanov_test.abc.com";
      string regex =
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

      var expected = false;
      var actual = test.IsRegexMatch(regex);

      Assert.Equal(expected, actual);
    }

    #endregion
  }
}
