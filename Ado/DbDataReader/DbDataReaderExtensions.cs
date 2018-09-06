// ReSharper disable once CheckNamespace
namespace System.Data.Common {

  /// <summary>
  /// Extensions for the Data Reader object.
  /// </summary>
  public static class DbDataReaderExtensions {

    private const int COLUMN_ORDINAL_NOT_FOUND_INDEX = -1;

    /// <summary>
    /// Retrieves a <see cref="bool"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="bool"/></returns>
    public static bool GetBoolean(this DbDataReader reader, string columnName) {

      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(bool).Name);

      return reader.GetBoolean(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="bool"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="bool"/></returns>
    public static bool? TryGetBoolean(this DbDataReader reader, string columnName, bool? defaultValue = null) {

      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetBoolean(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="byte"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="byte"/></returns>
    public static byte GetByte(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(byte).Name);

      return reader.GetByte(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="byte"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="byte"/></returns>
    public static byte? TryGetByte(this DbDataReader reader, string columnName, byte? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetByte(columnOrdinal);
    }

    /// <summary>
    /// Retrieves an <see cref="ushort"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>An <see cref="ushort"/></returns>
    public static ushort GetUShort(this DbDataReader reader, string columnName) {

      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(ushort).Name);

      return (ushort)reader.GetInt16(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="ushort"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="ushort"/></returns>
    public static ushort? TryGetUShort(this DbDataReader reader, string columnName, ushort? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : (ushort)reader.GetInt16(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="short"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="short"/></returns>
    public static short GetShort(this DbDataReader reader, string columnName) {

      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(short).Name);

      return reader.GetInt16(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="short"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="short"/></returns>
    public static short? TryGetShort(this DbDataReader reader, string columnName, short? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetInt16(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="uint"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>An <see cref="uint"/></returns>
    public static uint GetUInt(this DbDataReader reader, string columnName) {

      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(uint).Name);

      return (uint)reader.GetInt32(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="uint"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="uint"/></returns>
    public static uint? TryGetUInt(this DbDataReader reader, string columnName, uint? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : (uint)reader.GetInt32(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="int"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="int"/></returns>
    public static int GetInt(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(int).Name);

      return reader.GetInt32(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="int"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="int"/></returns>
    public static int? TryGetInt(this DbDataReader reader, string columnName, int? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetInt32(columnOrdinal);
    }

    /// <summary>
    /// Retrieves an <see cref="ulong"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>An <see cref="ulong"/></returns>
    public static ulong GetULong(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(ulong).Name);

      return (ulong)reader.GetInt64(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="ulong"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="ulong"/></returns>
    public static ulong? TryGetULong(this DbDataReader reader, string columnName, ulong? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : (ulong)reader.GetInt64(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="long"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="long"/></returns>
    public static long GetLong(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(long).Name);

      return reader.GetInt64(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="long"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="long"/></returns>
    public static long? TryGetLong(this DbDataReader reader, string columnName, long? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetInt64(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="float"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="float"/></returns>
    public static float GetFloat(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(float).Name);

      return reader.GetFloat(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="float"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="float"/></returns>
    public static float? TryGetFloat(this DbDataReader reader, string columnName, float? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetFloat(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="double"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="double"/></returns>
    public static double GetDouble(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(double).Name);

      return reader.GetDouble(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="double"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="double"/></returns>
    public static double? TryGetDouble(this DbDataReader reader, string columnName, double? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetDouble(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="decimal"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="decimal"/></returns>
    public static decimal GetDecimal(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(decimal).Name);

      return reader.GetDecimal(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="decimal"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="decimal"/></returns>
    public static decimal? TryGetDecimal(this DbDataReader reader, string columnName, decimal? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetDecimal(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="DateTime"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="DateTime"/></returns>
    public static DateTime GetDateTime(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(DateTime).Name);

      return reader.GetDateTime(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="DateTime"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="DateTime"/></returns>
    public static DateTime? TryGetDateTime(this DbDataReader reader, string columnName, DateTime? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetDateTime(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="Guid"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <returns>A <see cref="Guid"/></returns>
    public static Guid GetGuid(this DbDataReader reader, string columnName) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal))
        throw new DbColumnRequiredValueException(columnName, typeof(Guid).Name);

      return reader.GetGuid(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a nullable <see cref="Guid"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="defaultValue">A default value if the column is null or doesn't have a value.</param>
    /// <returns>A nullable <see cref="Guid"/></returns>
    public static Guid? TryGetGuid(this DbDataReader reader, string columnName, Guid? defaultValue = null) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      return reader.IsDBNull(columnOrdinal) ? defaultValue : reader.GetGuid(columnOrdinal);
    }

    /// <summary>
    /// Retrieves a <see cref="string"/> value from a DbDataReader.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="columnName">The column name.</param>
    /// <param name="throwErrorIfNull">A flag indicating if an exception should be thrown if the value is null (but is required)</param>
    /// <returns>A <see cref="string"/></returns>
    public static string GetString(this DbDataReader reader, string columnName, bool throwErrorIfNull = false) {
      var columnOrdinal = reader.GetOrdinal(columnName);

      if(columnOrdinal == COLUMN_ORDINAL_NOT_FOUND_INDEX)
        throw new DbColumnNotFoundException(columnName);

      if(reader.IsDBNull(columnOrdinal)) {

        if(throwErrorIfNull) {
          throw new DbColumnRequiredValueException(columnName, typeof(string).Name);
        }

        return null;
      }

      return reader.GetString(columnOrdinal);
    }
  }
}