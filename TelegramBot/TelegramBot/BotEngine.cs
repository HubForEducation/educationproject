using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Net;

namespace TelegramBot
{
    public class BotEngine
    {
        public List<string> Get();
        {
            List<string> files = new List<string>();

            Directory
                .GetFiles(path)
                .ToList()
                .ForEach(f => files.Add(f));

            return files;
        }

        public string Read(string path)
        {
            string fileText;
            fileText = File.ReadAllText(path);
            return fileText;
        }

        public bool Dowload(string address, string path)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(address, path);
            }

            return true;
        }
        
    }
}