using System.Data;
using System.Data.Common;

// ReSharper disable once CheckNamespace
namespace System.Data.Common {
  /// <summary>
  /// Extension methods for the <see cref="DbConnection"/> object.
  /// </summary>
  public static class DbConnectionExtensions {
    
    /// <summary>
    /// Creates a new command associated to a stored procedure.
    /// </summary>
    /// <param name="connection">The connection.</param>
    /// <param name="storedProcedureName">The name of the stored procedure.</param>
    /// <returns><see cref="DbCommand"/></returns>
    public static DbCommand CreateStoredProcedure(this DbConnection connection, string storedProcedureName) {
      var command = connection.CreateCommand();
      command.CommandText = storedProcedureName;
      command.CommandType = CommandType.StoredProcedure;
      return command;
    }
  }
}