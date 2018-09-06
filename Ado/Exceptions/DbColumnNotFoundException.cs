namespace System.Data.Common {
  /// <summary>
  /// An exception describing the condition of a missing column name.
  /// </summary>
  public class DbColumnNotFoundException : Exception {

    /// <summary>
    /// Raises an error for a missing column name.
    /// </summary>
    /// <param name="columnName">Describes the name of the column.</param>
    public DbColumnNotFoundException(string columnName)
      : base($"The specified column: \"{columnName}\" does not exist in the returned result set.") {
      this.ColumnName = columnName;
    }

    /// <summary>
    /// Gets or sets the name of the column
    /// </summary>
    public string ColumnName { get; private set; }
  }
}