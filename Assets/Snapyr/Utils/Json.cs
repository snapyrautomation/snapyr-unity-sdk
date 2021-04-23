using Newtonsoft.Json;

namespace Snapyr.Utils
{
    public class Json
    {
        private static JsonSerializerSettings defaultSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public static string toString(object value) =>
            value != null ? JsonConvert.SerializeObject(value, defaultSettings) : null;
    }
}