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
        public string Get(string get)
        {
            try
            {
                List<string> fileslist = new List<string>();

                Directory
                    .EnumerateFiles(get, "*")
                    .Select(Path.GetFileName)
                    .ToList()
                    .ForEach(f => fileslist.Add(f));

                var files = string.Join("\n", fileslist.ToArray());
                return files;
            }
            catch (DirectoryNotFoundException)
            {
                return "Directory " + get + "not found.";
            }
            catch (ArgumentNullException)
            {
                return "Directory " + get + " can not be NULL.";
            }           
        }

        public string Read(string read)
        {
            var fileText = File.ReadAllText(read);

            if (File.Exists(read) != true)
            {
                return "File " + read + " not found.";
            }
            else
            {
                return fileText;
            }
        }

        public string Download(string downloadAdress, string downloadPath)
        {
            try
            {
                var client = new WebClient();
                client.DownloadFile(downloadAdress, downloadPath);
            }
            catch (WebException)
            {
                return "WebException";
            }

            if (File.Exists(downloadPath) != true)
            {
                return "File from " + downloadAdress + "to " + downloadPath +
                       " not downloaded.";
            }
            else
            {
                return "File from " + downloadAdress + "to " + downloadPath +
                       " downloaded successfully.";
            }
        }

        public string Command(string command)
        {
            ProcessStartInfo request = new ProcessStartInfo(@"cmd.exe", @"/C " + command);
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

        public string Check(string checkPath, int checkTime)
        {
            List<string> oldfiles = new List<string>();

            Directory
                .GetFiles(checkPath)
                .ToList()
                .ForEach(f => oldfiles.Add(f));

            Thread.Sleep(checkTime);

            List<string> newfiles = new List<string>();

            Directory
                .GetFiles(checkPath)
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