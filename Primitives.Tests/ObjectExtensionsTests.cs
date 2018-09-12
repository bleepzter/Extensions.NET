using System;
using System.Linq;
using Xunit;

namespace Primitives.Tests {
  public class ObjectExtensionsTests
  {

    public class TestFixture
    {
      public int Value { get; set; }
    }

    public class OtherFixture : TestFixture
    {
      public new string Value { get; set; }
    }

    [Fact]
    public void ToEnumerable_Returns_Empty_Enumerable_When_Object_Is_Null()
    {
      object test = null;

      var expectedValue = Enumerable.Empty<object>();
      var actualValue = test.ToEnumerable();

      var expectedEnumerator = expectedValue.GetEnumerator().MoveNext();
      var actualEnumerator = actualValue.GetEnumerator().MoveNext();


      Assert.Equal(expectedEnumerator, actualEnumerator);
    }

    [Fact]
    public void ToEnumerable_Returns_Enumerable_When_Object_Value_Type()
    {
      int test = 12;

      var expectedSequence = Enumerable.Range(12, 1);
      var actualSequence = test.ToEnumerable();

      var expectedEnumerator = expectedSequence.GetEnumerator();
      var actualEnumerator = actualSequence.GetEnumerator();

      bool expectedEquality = true;
      bool actualEquality = expectedSequence.SequenceEqual(actualSequence);

      var expectedValue = expectedEnumerator.Current;
      var actualValue = expectedEnumerator.Current;

      Assert.Equal(expectedSequence.Count(), actualSequence.Count());
      Assert.Equal(expectedEquality, actualEquality);
      Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void ToEnumerable_Returns_Enumerable_When_Object_Is_Reference_Type()
    {
      var testFixture = new TestFixture() { Value = 12 };

      var expectedSequence = Enumerable.Repeat(testFixture, 1);
      var actualSequence = testFixture.ToEnumerable();

      var expectedEnumerator = expectedSequence.GetEnumerator();
      var actualEnumerator = actualSequence.GetEnumerator();

      bool expectedEquality = true;
      bool actualEquality = expectedSequence.SequenceEqual(actualSequence);

      var expectedValue = expectedEnumerator.Current;
      var actualValue = actualEnumerator.Current;

      Assert.Equal(expectedSequence.Count(), actualSequence.Count());
      Assert.Equal(expectedEquality, actualEquality);
      
    }

    [Fact]
    public void Clone_Returns_Null_When_Object_Null()
    {
      object test = null;
      Assert.Throws<NullReferenceException>(() => test.Clone());
    }

    [Fact]
    public void Clone_Returns_Clone_Of_Value_Type()
    {
      int test = 12;

      object expected = 12;
      object actual = test.Clone();

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Clone_Returns_Clone_Of_Reference_Type()
    {
      var test = new TestFixture() { Value = 12 };

      var expected = test;
      var actual = test.Clone();

      Assert.Equal(expected.Value, actual.Value);
      Assert.NotEqual(expected.GetHashCode(), actual.GetHashCode());
    }

    [Fact]
    public void Clone_Returns_Clone_Of_Derived_Reference_Type()
    {
      var test = new OtherFixture() { Value = "ASDF" };

      var expected = test;
      var actual = test.Clone();

      Assert.Equal(expected.Value, actual.Value);
      Assert.NotEqual(expected.GetHashCode(), actual.GetHashCode());
    }

  }
}