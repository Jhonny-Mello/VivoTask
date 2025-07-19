using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace Vivo_Task.Shared_Static_Class.Converters
{
    public static class SharedConverter
    {
        public static byte[] ConvertFile(byte[] Unconvertedfiles)
        {
            try
            {
                byte[] decompressedBytes;
                using (MemoryStream memoryStream = new MemoryStream(Unconvertedfiles))
                {
                    using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        using (MemoryStream decompressedStream = new MemoryStream())
                        {
                            gzipStream.CopyTo(decompressedStream);
                            decompressedBytes = decompressedStream.ToArray();
                            return decompressedBytes;
                        }
                    }
                }

            }
            catch
            {
                return null;
            }
        }
        public static string ConvertFileToString(byte[] Unconvertedfiles)
        {
            try
            {
                byte[] decompressedBytes;
                using (MemoryStream memoryStream = new MemoryStream(Unconvertedfiles))
                {
                    using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                    {
                        using (MemoryStream decompressedStream = new MemoryStream())
                        {
                            gzipStream.CopyTo(decompressedStream);
                            decompressedBytes = decompressedStream.ToArray();
                            return Convert.ToBase64String(decompressedBytes);
                        }
                    }
                }

            }
            catch
            {
                return string.Empty;
            }
        }
        public static string CompressFileString(byte[] Unconvertedfiles)
        {
            try
            {
                byte[] compressedbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal))
                    {
                        gzipStream.Write(Unconvertedfiles, 0, Unconvertedfiles.Length);
                        compressedbytes = memoryStream.ToArray();
                        return Convert.ToBase64String(compressedbytes);
                    }
                }

            }
            catch
            {
                return string.Empty;
            }
        }
        public static byte[] CompressFile(byte[] Unconvertedfiles)
        {
            try
            {
                byte[] compressedbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal))
                    {
                        gzipStream.Write(Unconvertedfiles, 0, Unconvertedfiles.Length);
                        compressedbytes = memoryStream.ToArray();

                        return compressedbytes;
                    }
                }
            }
            catch
            {
                return [];
            }
        }
    }

}
