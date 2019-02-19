using System;
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
        public static string CheckPath { get; set; } = "D:/";
        public static int CheckTime { get; set; } = 8000;

        public static string SavePath { get; set; }
        public static string LoadPath { get; set; }

        public static void Save()
        {
            string[] filesource = new string[] {Get, Read, DowloadAdress, DowloadPath, Command,CheckPath,CheckTime,SavePath,LoadPath};
            File.WriteAllLines(SavePath, filesource);
        }

        public static void Load()
        {
            string[] filesource = new string[88];
            filesource = File.ReadAllLines(LoadPath);
        }
    }
}