using System.IO;

namespace TelegramBot
{
    public static class Settings
    {
        public static string Get { get; set; }
        public static string Read { get; set; }
        public static string DownloadAdress { get; set; }
        public static string DownloadPath { get; set; }
        public static string Command { get; set; }
        public static string CheckPath { get; set; } = "C:/Users/Anonymous/Desktop";
        public static int CheckTime { get; set; }

        public static string SavePath { get; set; }
        public static string LoadPath { get; set; }

        public static string Save()
        {
            if (File.Exists(SavePath) != true)
            {
                return "File not found.";
            }
            else
            {
                string[] filesource =
                {
                    Get, Read, DownloadAdress, DownloadPath, Command, CheckPath, CheckTime.ToString(), SavePath,
                    LoadPath
                };
                File.WriteAllLines(SavePath, filesource);
                return "Settings safe to file " + SavePath;
            }
        }

        public static string Load()
        {
            if (File.Exists(LoadPath) != true)
            {
                return "File not found";
            }
            else
            {
                var filesource = File.ReadAllLines(LoadPath);
                Get = filesource[0];
                Read = filesource[1];
                DownloadAdress = filesource[2];
                DownloadPath = filesource[3];
                Command = filesource[4];
                CheckPath = filesource[5];
                CheckTime = int.Parse(filesource[6]);
                SavePath = filesource[7];
                LoadPath = filesource[8];
                return "Setting load from file " + LoadPath;
            }
        }
    }
}