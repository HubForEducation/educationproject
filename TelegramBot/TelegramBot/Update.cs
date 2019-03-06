using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace TelegramBot
{
    public class Update
    {

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

        public string Checkedstring;

        public string Checked(string checkedstring)
        {
            return checkedstring;
        }

        private void CheckOnChanged(object source, FileSystemEventArgs e)
        {
            Checkedstring = "File: " + e.FullPath + " " + e.ChangeType;
            Checked(Checkedstring);
        }

        public void CheckUpdate(string ApiToken, string ChatId, string CheckPath, int CheckTime)
        {
            while (true)
            {
                Check(CheckPath);
                string checkedanswer = Checked(Checkedstring);
                if (checkedanswer != null)
                {
                    //api.telegram.org/bot<Bot_token>/getUpdates

                    string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                    string apiToken = ApiToken;
                    string chatId = ChatId;
                    string text = checkedanswer;
                    urlString = String.Format(urlString, apiToken, chatId, text);
                    WebRequest request = WebRequest.Create(urlString);
                    Stream rs = request.GetResponse().GetResponseStream();
                    StreamReader reader = new StreamReader(rs ?? throw new InvalidOperationException());
                    string line = "";
                    StringBuilder sb = new StringBuilder();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                            sb.Append(line);
                    }
                }

                Checkedstring = null;
                Thread.Sleep(CheckTime);
            }
        }
    }
}