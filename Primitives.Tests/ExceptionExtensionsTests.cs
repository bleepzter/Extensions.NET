using System;
using Xunit;

namespace Primitives.Tests {
  public class ExceptionExtensionsTests {
    [Fact]
    public void Unwrap_Returns_Null_When_Exception_Is_Null()
    {

      Exception ex = null;

      var actual = ex.Unwrap();

      Assert.Null(actual);
    }

    [Fact]
    public void Unwrap_Returns_An_Error_Message_From_Single_Exception()
    {

      var ex = new Exception("This is a test");

      var actual = ex.Unwrap();

      Assert.NotNull(actual);
      Assert.Contains("This is a test", actual);
    }

    [Fact]
    public void Unwrap_Returns_An_Error_Message_From_Exception_Hierarchy()
    {

      var exChild  = new Exception("This is child error test");
      var exParent = new Exception("This is a parent error test", exChild);

      var actual = exParent.Unwrap();

      Assert.NotNull(actual);
      Assert.Contains("This is a parent error test", actual);
      Assert.Contains("This is child error test", actual);
    }

    [Fact]
    public void Unwrap_Returns_An_Error_Message_From_Aggregate_Exception_Hierarchy() {
      
      var innerExceptions = new Exception[] {
        new Exception("This is child 1 error test"),
        new Exception("This is child 2 error test"),
        new Exception("This is child 3 error test")
      };

      var aggregate = new AggregateException(innerExceptions);
      var actual = aggregate.Unwrap();

      Assert.NotNull(actual);
      Assert.Contains("AggregateException", actual);
      Assert.Contains("This is child 1 error test", actual);
      Assert.Contains("This is child 2 error test", actual);
      Assert.Contains("This is child 3 error test", actual);
    }

    [Fact]
    public void Unwrap_Returns_An_Error_Message_From_Complex_Aggregate_Exception_Hierarchy()
    {
      var superDuperInerExceptions = new Exception[] {
        new Exception("This is sub child 1 error test"),
        new Exception("This is sub child 2 error test"),
        new Exception("This is sub child 3 error test")
      };


      var innerExceptions = new Exception[] {
        new AggregateException(superDuperInerExceptions),
        new Exception("This is child 2 error test"),
        new Exception("This is child 3 error test")
      };

      var aggregate = new AggregateException(innerExceptions);
      var actual    = aggregate.Unwrap();

      Assert.NotNull(actual);
      Assert.Contains("AggregateException", actual);
      Assert.Contains("This is sub child 1 error test", actual);
      Assert.Contains("This is sub child 2 error test", actual);
      Assert.Contains("This is sub child 3 error test", actual);
      Assert.Contains("This is child 2 error test", actual);
      Assert.Contains("This is child 3 error test", actual);
    }
  }
}