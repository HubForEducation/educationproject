using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramBot
{
    [Serializable]
    public class Settings
    {
        public string Get;
        public string Read;
        public string DownloadAdress;
        public string DownloadPath;
        public string Command;
        public string CheckPath;
        public string SaveLoadSettingsPath;

        public async Task Save(Settings settings)
        {
            var serializeObject = JsonConvert.SerializeObject(settings);

            await File.WriteAllTextAsync(SaveLoadSettingsPath + "./settings.json", serializeObject);
            
            Console.WriteLine( "Settings saved");
        }

        public async Task<Settings> Load()
        {
            if (File.Exists(SaveLoadSettingsPath + "./settings.json") != true)
            {
                throw new FileNotFoundException("./settings.json");
            }

            var text = File.ReadAllText("./settings.json");

            var settings = JsonConvert.DeserializeObject<Settings>(text);

            Console.WriteLine("Setting load from file " + "./settings.json");

            return settings;

        }
    }
}