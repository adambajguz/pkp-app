using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace TrainsOnline.Desktop.Helpers
{
    public static class ImageHelper
    {
        public static async Task<BitmapImage> ImageFromStringAsync(string data)
        {
            byte[] byteArray = Convert.FromBase64String(data);
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(byteArray.AsBuffer());
                stream.Seek(0);
                await image.SetSourceAsync(stream);
            }

            return image;
        }

        public static BitmapImage ImageFromAssetsFile(string fileName)
        {
            BitmapImage image = new BitmapImage(new Uri($"ms-appx:///Assets/{fileName}"));
            return image;
        }
    }
}
