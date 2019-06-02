using System.IO;

namespace SitecoreCognitiveServices.Foundation.IBMSDK.Http.Extensions
{
    public static class StreamExtension
    {
        public static byte[] ReadAllBytes(this Stream _stream)
        {
            byte[] buffer = new byte[_stream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = _stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }
    }
}