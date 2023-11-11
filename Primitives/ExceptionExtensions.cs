using System.Text;

// ReSharper disable once CheckNamespace
namespace System {

  /// <summary>
  /// Extension methods for <see cref="System.Exception"/> types.
  /// </summary>
  public static class ExceptionExtensions {

    /// <summary>
    /// Unwraps an exception. Whether it is an aggregate exception or just an exception - this extension method records the exception type, message, and stacktrace
    /// to string. In the case of regular exceptions - it will recursively traverse the inner exceptions and record their details as well.
    /// For aggregate except- inner exceptions are traversed and recorded to get the  complete message/stack trace out of the errors.
    /// </summary>
    /// <param name="exception">An exception.</param>
    /// <returns>A <see cref="String"/> representing the message of the exception including all nested/inner exceptions.</returns>
    public static string Unwrap(this Exception exception)
    {
      if (exception == null)
        return null;

      var result = new StringBuilder();

      ExceptionExtensions.WriteExceptionDetails(exception, result);

      if (exception is AggregateException aggregateException)
      {
        foreach (var innerException in aggregateException.InnerExceptions)
        {
          ExceptionExtensions.InterrogateException(innerException, result);
        }

        return result.ToString();
      }

      var inner = exception.InnerException;
      ExceptionExtensions.InterrogateException(inner, result);

      return result.ToString();
    }

    /// <summary>
    /// Recursive call to unwrap inner exceptions.
    /// </summary>
    /// <param name="ex">An exception to unwrap.</param>
    /// <param name="sb">A string builder where to dump the exception details into.</param>
    private static void InterrogateException(Exception ex, StringBuilder sb)
    {
      var exceptionMessage = ex.Unwrap();

      if (string.IsNullOrEmpty(exceptionMessage))
        return;

      sb.AppendLine(exceptionMessage);
    }

    /// <summary>
    /// Write out the exception details to a string builder.
    /// </summary>
    /// <param name="ex">The exception whose details we want to write down.</param>
    /// <param name="sb">The string builder where we will dump the details of the exception to.</param>
    private static void WriteExceptionDetails(Exception ex, StringBuilder sb)
    {
      sb.AppendLine($"Error Type: {ex.GetType().FullName}.");
      sb.AppendLine($"Error Message: {ex.Message}.");

      if(ex.StackTrace != null)
        sb.AppendLine($"Stack Trace: {ex.StackTrace.Replace(Environment.NewLine, "/t/t")}.");
    }
  }
}