using Newtonsoft.Json;
namespace json_serializer
{
    public class Json
    {
        public static string convert_to_json<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T read_json<T>(string path)
        {
            if (!File.Exists(path)) throw new NullReferenceException("No such file found");
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }
    }
}