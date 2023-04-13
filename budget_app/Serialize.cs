using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using budget_app;
using Newtonsoft.Json;
using budget_app;


namespace budget_app
{
    internal static class Serialize
    {
        
        public static List<MainWindow.Note> Read()
        {
            string path = File.ReadAllText("C:\\Users\\mansu\\data.json");
            List < MainWindow.Note> list = JsonConvert.DeserializeObject<List<MainWindow.Note>>(path);
            return list;
        }

        public static void WriteObject(List<MainWindow.Note> list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("C:\\Users\\mansu\\data.json", json);
        }

        public static void Other(MainWindow.Other oth)
        {
            string json = JsonConvert.SerializeObject(oth);
            File.WriteAllText("C:\\Users\\mansu\\other.json", json);
        }

        public static MainWindow.Other Get_Other()
        {
            string path = File.ReadAllText("C:\\Users\\mansu\\other.json");
            MainWindow.Other oth = JsonConvert.DeserializeObject<MainWindow.Other>(path);
            return oth;
        }
    }
}
