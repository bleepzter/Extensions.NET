using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

// ReSharper disable once CheckNamespace
namespace System {
  
  /// <summary>
  /// Extension methods for byte and byte array
  /// </summary>
  public static class ByteExtensions {

    /// <summary>
    /// Calculates a SHA1 hash of a byte array.
    /// </summary>
    /// <param name="data">A byte array</param>
    /// <returns><see cref="string"/> that represents the SHA1 hash of a byte array.</returns>
    // ReSharper disable once InconsistentNaming
    public static string GetSHA1Hash(this byte[] data) {

      if(data == null || !data.Any())
        return null;

      using(var sha1 = SHA1.Create()) {
        return BitConverter.ToString(sha1.ComputeHash(data)).ToLower().Replace("-", "");
      }
    }


    /// <summary>
    /// Compresses a byte array using GZip.
    /// </summary>
    /// <param name="data">The data</param>
    /// <returns>An array of <see cref="byte"/> representing the compressed data.</returns>
    public static byte[] GZipCompress(this byte[] data) {
      if(data == null || !data.Any())
        return new byte[0];

      byte[] result = null;

      using (var compressedStream = new MemoryStream()) {
        using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress, true)) {
          zipStream.Write(data, 0, data.Length);
        }

        result = compressedStream.ToArray();
      }

      return result;
    }

    /// <summary>
    /// Decompresses a byte array using GZip.
    /// </summary>
    /// <param name="data">The compressed byte array data.</param>
    /// <returns>An array of <see cref="byte"/> representing the decompressed data.</returns>
    public static byte[] GZipDecompress(this byte[] data) {
      if(data == null || !data.Any())
        return new byte[0];

      byte[] result = null;

      using (var compressedStream = new MemoryStream(data)) {
        using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress)) {
          using (var resultStream = new MemoryStream()) {
            zipStream.CopyTo(resultStream);
            result = resultStream.ToArray();
          }
        }
      }

      return result;
    }

    /// <summary>
    /// Converts a byte array to a <see cref="MemoryStream"/>
    /// </summary>
    /// <param name="data">The byte array.</param>
    /// <returns><see cref="MemoryStream"/></returns>
    public static MemoryStream ToStream(this byte[] data) {
      if (data == null || !data.Any())
        return null;

      var result = new MemoryStream(data);
      result.Position = 0L;
      return result;
    }
  }
}