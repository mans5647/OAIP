using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace calendar
{
    public class Serialize
    {
        public static void to_json<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            string common_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            File.WriteAllText(common_path + "\\Points.json", json);
        }

        public static T from_json<T>()
        {
            string common_path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Points.json";
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(common_path));
        }
    }
}
