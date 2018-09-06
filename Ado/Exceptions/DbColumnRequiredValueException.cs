// ReSharper disable once CheckNamespace
namespace System.Data.Common {
  /// <summary>
  /// An exception representing a condition in which a required column has nulls.
  /// </summary>
  public class DbColumnRequiredValueException : Exception {
    /// <summary>
    /// An exception representing a condition in which a required column has nulls.
    /// </summary>
    /// <param name="columnName">The name of the column.</param>
    /// <param name="dataType">The type of data stored in the column.</param>
    public DbColumnRequiredValueException(string columnName, string dataType)
      : base($"Unable to read a {dataType} value from colum {columnName} because it's null.") {
      this.ColumnName = columnName;
      this.DataType = dataType;
    }

    /// <summary>
    /// Gets or sets the name of the column
    /// </summary>
    public string ColumnName { get; private set; }

    /// <summary>
    /// Gets or sets the data type of the 
    /// </summary>
    public string DataType { get; private set; }
  }
}
