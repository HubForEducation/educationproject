using System;
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
        public string Get()
        {
            try
            {
                List<string> fileslist = new List<string>();

                Directory
                    .EnumerateFiles(Settings.Get, "*")
                    .Select(Path.GetFileName)
                    .ToList()
                    .ForEach(f => fileslist.Add(f));

                var files = string.Join("\n", fileslist.ToArray());
                return files;
            }
            catch (DirectoryNotFoundException)
            {
                return "Directory " + Settings.Get + "not found.";
            }
            catch (ArgumentNullException)
            {
                return "Directory " + Settings.Get + " can not be NULL.";
            }           
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

        public string Download()
        {
            try
            {
                var client = new WebClient();
                client.DownloadFile(Settings.DownloadAdress, Settings.DownloadPath);
            }
            catch (WebException)
            {
                return "WebException";
            }

            if (File.Exists(Settings.DownloadPath) != true)
            {
                return "File from " + Settings.DownloadAdress + "to " + Settings.DownloadPath +
                       " not downloaded.";
            }
            else
            {
                return "File from " + Settings.DownloadAdress + "to " + Settings.DownloadPath +
                       " downloaded successfully.";
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

        public string Check()
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
                .ForEach(f => newfiles.Add(f));

            List<string> result = oldfiles.Except(newfiles).ToList();

            var addededfiles = string.Join("\n", result.ToArray());

            if (addededfiles == null)
            {
                return null;
            }
            else
            {
                return addededfiles;
            }
        }
    }
}