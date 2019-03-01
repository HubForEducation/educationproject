using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramBot
{
    public class Settings
    {
        public string Get { get; set; }
        public string Read { get; set; }
        public string DownloadAdress { get; set; }
        public string DownloadPath { get; set; }
        public string Command { get; set; }
        public string CheckPath { get; set; } = "C:/Users/Anonymous/Desktop";
        public int CheckTime { get; set; }
        public string SavePath { get; set; }
        public string LoadPath { get; set; } 

        public static async Task Save(Settings settings)
        {
            var serializeObject = JsonConvert.SerializeObject(settings);

            await File.WriteAllTextAsync(settings.SavePath, serializeObject);
            
            Console.WriteLine( "Settings saved");
        }

        public static async Task<Settings> Load()
        {
            Settings _setting = null;
            if (File.Exists("./settings.json") != true)
            {
                throw new FileNotFoundException("./settings.json");
            }

            var text = File.ReadAllText("./settings.json");

            _setting = JsonConvert.DeserializeObject<Settings>(text);

            Console.WriteLine("Setting load from file " + "./settings.json");
            return _setting;
        }
    }
}