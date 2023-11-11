// ReSharper disable once CheckNamespace
using System.Drawing;

namespace System.Data.Common {

  /// <summary>
  /// Extension methods for DbCommand
  /// </summary>
  public static class DbCommandExtensions {

		/// <summary>
		/// Creates a <see cref="DbParameter"/> and adds it to the command object.
		/// </summary>
		/// <param name="command">The <see cref="DbCommand"/></param>
		/// <param name="name">The name of the parameter. If the name doesn't start with '@' it will be added.</param>
		/// <param name="dbType">The SQL data type of the parameter.</param>
		/// <param name="value">The value of the parameter.</param>
		/// <param name="direction">The <see cref="ParameterDirection"/> of the parameter.</param>
		/// <returns>A reference to the <see cref="DbParameter"/></returns>
    public static DbParameter AddParameter(this DbCommand command, string name, DbType dbType, object value, ParameterDirection direction = ParameterDirection.Input, int? size = null) {

      var parameterName = name.StartsWith("@") ? name : $"@{name}";

      var parameter = command.CreateParameter();
      parameter.ParameterName = parameterName;
      parameter.DbType = dbType;
      parameter.Value = value;
      parameter.Direction = direction;

      if (size != null)
      {
	      parameter.Size = size.Value;
      }
      
      command.Parameters.Add(parameter);

      return parameter;
    }  
  }
}