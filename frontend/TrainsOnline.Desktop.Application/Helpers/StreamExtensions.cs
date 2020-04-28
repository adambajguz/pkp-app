namespace TrainsOnline.Desktop.Application.Helpers
{
    using System;
    using System.IO;

    public static class StreamExtensions
    {
        public static string ToBase64String(this Stream stream)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}
