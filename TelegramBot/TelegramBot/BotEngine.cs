using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Net;
using System.Threading;

namespace TelegramBot
{
    public class BotEngine
    {
        public List<string> Get()

        {
            List<string> files = new List<string>();

            Directory
                .GetFiles(Settings.Get)
                .ToList()
                .ForEach(f => files.Add(f));

            return files;
        }

        public string Read()
        {
            string fileText;
            fileText = File.ReadAllText(Settings.Read);
            return fileText;
        }

        public bool Dowload()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(Settings.DowloadAdress, Settings.DowloadPath);
            }

            return true;
        }

        public string Command()
        {
            ProcessStartInfo request = new ProcessStartInfo(@"cmd.exe", @"/C " + Settings.Command);
            request.WindowStyle = ProcessWindowStyle.Hidden;
            request.RedirectStandardOutput = true;
            request.UseShellExecute = false;
            request.CreateNoWindow = true;
            Process procCommand = Process.Start(request);
            StreamReader answer = procCommand.StandardOutput;
            return answer.ReadToEnd();
        }

        public bool Check()
        {
            List<string> oldfiles = new List<string>();

            Directory
                .GetFiles(Settings.CheckPath)
                .ToList()
                .ForEach(f => oldfiles.Add(f));
            
            Thread.Sleep(Settings.CheckTime);
            
            List<string> newfiles = new List<string>();

            Directory
                .GetFiles(Settings.CheckPath)
                .ToList()
                .ForEach(f => oldfiles.Add(f));
            
            List<string> result = oldfiles.Except(newfiles).ToList();
            
            if (result.Count == 0)
                return false;
            return true;
        }
    }
}