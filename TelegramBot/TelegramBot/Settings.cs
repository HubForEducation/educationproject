using System.IO;

namespace TelegramBot
{
    public static class Settings
    {
        public static string Get { get; set; }
        public static string Read { get; set; }
        public static string DowloadAdress { get; set; }
        public static string DowloadPath { get; set; }
        public static string Command { get; set; }
        public static string CheckPath { get; set; }
        public static int CheckTime { get; set; }

        public static string SavePath { get; set; }
        public static string LoadPath { get; set; }

        public static void Save()
        {
            if (File.Exists(SavePath) != true)
            {
                throw new FileNotFoundException();
            }
            else
            {
                string[] filesource = { Get, Read, DowloadAdress, DowloadPath, Command, CheckPath, CheckTime.ToString(), SavePath, LoadPath };
                File.WriteAllLines(SavePath, filesource);
            }
        }

        public static void Load()
        {
            if (File.Exists(LoadPath) != true)
            {
                throw new FileNotFoundException();
            }
            else
            {
                string[] filesource = new string[88];
                filesource = File.ReadAllLines(LoadPath);
                Get = filesource[0];
                Read = filesource[1];
                DowloadAdress = filesource[2];
                DowloadPath = filesource[3];
                Command = filesource[4];
                CheckPath = filesource[5];
                CheckTime = int.Parse(filesource[6]);
                SavePath = filesource[7];
                LoadPath = filesource[8];
            }
        }
    }
}