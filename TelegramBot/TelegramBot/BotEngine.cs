using System;
using System.Collections.Generic;
using System.Data;
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
            var fileText = File.ReadAllText(Settings.Read);
            
            if (File.Exists(Settings.Read) != true)
            {
                return "File " + Settings.Read + " not found."; 
            }
            else
            {
                return fileText;
            }
            
            
        }

        public bool Dowload()
        {
            try
            {
                var client = new WebClient();
                client.DownloadFile(Settings.DowloadAdress, Settings.DowloadPath);
            }
            catch(WebException)
            {
                
            }
            
            if (File.Exists(Settings.DowloadPath) != true)
            {
                return false; 
            }
            else
            {
                return true;
            }

        }

        public string Command()
        {
            ProcessStartInfo request = new ProcessStartInfo(@"cmd.exe", @"/C " + Settings.Command);
            request.WindowStyle = ProcessWindowStyle.Hidden;
            request.RedirectStandardOutput = true;
            request.UseShellExecute = false;
            request.CreateNoWindow = true;
            Process procCommand = Process.Start(request);
            if (procCommand != null)
            {
                StreamReader answer = procCommand.StandardOutput;
                return answer.ReadToEnd();
            }

            return "Something went wrong.";
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