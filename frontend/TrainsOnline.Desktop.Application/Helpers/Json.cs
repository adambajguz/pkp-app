namespace TrainsOnline.Desktop.Application.Helpers
{
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class Json
    {
        public static async Task<T> ToObjectAsync<T>(this string value)
        {
            return await Task.Run<T>(() =>
            {
                return JsonConvert.DeserializeObject<T>(value);
            });
        }

        public static async Task<string> StringifyAsync(this object value)
        {
            return await Task.Run<string>(() =>
            {
                return JsonConvert.SerializeObject(value);
            });
        }
    }
}
