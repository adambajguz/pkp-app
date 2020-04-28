namespace TrainsOnline.Desktop.Core.Extensions
{
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class Json
    {
        public static async Task<T> ToObjectAsync<T>(this string value)
        {
            return await Task.Run(() =>
            {
                return JsonConvert.DeserializeObject<T>(value);
            });
        }

        public static async Task<string> StringifyAsync(this object value)
        {
            return await Task.Run(() =>
            {
                return JsonConvert.SerializeObject(value);
            });
        }
    }
}
