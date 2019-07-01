using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Game_Of_Cards
{
    class Program
    {



        // static int chips;
      //  [assembly: log4net.Config.XmlConfigurator(Watch = true)]
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        public static void WriteLog(string strLog)
        {
            try
            {
                string logFilePath = @"C:\Logs\Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
                FileInfo logFileInfo = new FileInfo(logFilePath);
                DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
                {
                    using (StreamWriter log = new StreamWriter(fileStream))
                    {
                        log.WriteLine(strLog);
                    }
                }
            }
            catch (Exception e) {
                log.Error(e.Message);
            }
        }
       // static Deck deck;

        static void Main(string[] args)
        {
            try
            {
                Manager.MainManager();
            }
            catch (Exception e) {
                log.Error("Error in main "+e.Message);
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}