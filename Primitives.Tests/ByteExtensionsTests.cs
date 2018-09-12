using System;
using System.Text;
using Xunit;

namespace Primitives.Tests {
  public class ByteExtensionsTests {
    [Fact]
    public void GetSHA1Hash_Returns_Null_If_Underlying_Byte_Array_Is_Null()
    {
      byte[] source = null;

      string actual = source.GetSHA1Hash();

      Assert.Null(actual);
    }

    [Fact]
    public void GetSHA1Hash_Returns_Valid_Hash_Null()
    {
      byte[] source = Encoding.UTF8.GetBytes("testing");

      var expected = "dc724af18fbdd4e59189f5fe768a5f8311527050";
      string actual = source.GetSHA1Hash();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GZipCompress_Returns_Empty_Array_When_Underlying_Data_Is_Null()
    {
      byte[] result = null;

      var expected = new byte[0];
      var actual = result.GZipCompress();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GZipCompress_Returns_Empty_Array_When_Underlying_Data_Is_Empty()
    {
      byte[] result = null;

      var expected = new byte[0];
      var actual = result.GZipCompress();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GZipCompress_Returns_Compressed_Data_Array_When_Underlying_Data_Is_Valid()
    {
      var input = "testing";

      var raw = Encoding.UTF8.GetBytes(input);
      var compressedBytes = raw.GZipCompress();

      var expected = "H4sIAAAAAAAACytJLS7JzEsHAAZa8+gHAAAA";
      var actual = Convert.ToBase64String(compressedBytes);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GZipDecompress_Returns_Empty_Array_When_Underlying_Data_Is_Null()
    {
      byte[] input = null;

      var expected = new byte[0];
      var actual = input.GZipDecompress();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GZipDecompress_Returns_Empty_Array_When_Underlying_Data_Is_Empty()
    {
      byte[] input = null;

      var expected = new byte[0];
      var actual = input.GZipDecompress();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void GZipDecompress_Returns_Original_Data_Array_When_Compressed_Data_Is_Valid()
    {
      var input = "H4sIAAAAAAAEACtJLS7JzEsHAAZa8+gHAAAA";

      var compressedBytes = Convert.FromBase64String(input);
      var decompressedBytes = compressedBytes.GZipDecompress();

      var expected = "testing";
      var actual = Encoding.UTF8.GetString(decompressedBytes);

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToMemoryStream_Returns_Null_When_Underlying_Data_Is_Null()
    {

      byte[] input = null;

      var actual = input.ToStream();

      Assert.Null(actual);

    }

    [Fact]
    public void ToMemoryStream_Returns_Null_When_Underlying_Data_Is_Empty()
    {

      byte[] input = new byte[0];

      var actual = input.ToStream();

      Assert.Null(actual);

    }

    [Fact]
    public void ToMemoryStream_Returns_Memory_Stream_When_Data_Is_Legin()
    {

      byte[] input = new byte[1] { 0x1 };


      var result = input.ToStream();

      Assert.True(result.Position == 0);
      Assert.True(result.Length == input.Length);

    }
  }
}