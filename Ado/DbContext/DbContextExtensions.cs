using System.Data;
using System.Data.Common;

namespace Microsoft.EntityFrameworkCore
{
  /// <summary>
  /// Extension methods for the DbContext.
  /// </summary>
  public static class DbContextExtensions {
    /// <summary>
    /// Retrieves the underlying connection from the DbContext.
    /// </summary>
    /// <param name="context">A <see cref="DbContext"/> instance.</param>
    /// <returns>The underlying <see cref="DbConnection"/> of the db context.</returns>
    public static DbConnection GetConnection(this DbContext context) {
      return context.Database.GetDbConnection();
    }

    /// <summary>
    /// Retrieves the connection string of the underlying connection from the DbContext.
    /// </summary>
    /// <param name="context">A <see cref="DbContext"/> instance.</param>
    /// <returns>The underlying connection string of the db context.</returns>
    public static string GetConnectionString(this DbContext context) {
      return context.Database.GetDbConnection().ConnectionString;
    }
  }
}