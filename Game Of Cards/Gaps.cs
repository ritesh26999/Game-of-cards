using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Cards
{
    class Gaps
    {
        //  log.Error("In Gaps class, ClearScreen() function error: "+e.Message);
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
            catch (Exception e)
            {
                log.Error("Error in Writelog: " + e.Message);
            }
        }


        public static void LineBreak(int Lines)
        {
            try
            {
                log.Debug("In Gaps class, in LineBreak() function. ");
                for (int i = 0; i < Lines; i++)
                {
                    Console.WriteLine();
                }
                log.Debug("In Gaps class, out LineBreak() function. ");
            }
            catch (Exception e) {
                log.Error("In Gaps class, LineBreak() Error: "+ e.Message);
            }
        }


        public static void TabsSpaces(int spaces)
        {
            try
            {
                log.Debug("In Gaps class, in TabsSpaces() function. ");
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write("\t");
                }
                log.Debug("In Gaps class, out of TabsSpaces() function. ");
            }
            catch (Exception e) {

                log.Error("In Gaps class, TabSpaces() Error: " + e.Message);
            }
        }


        public static void ClearScreen() {
            try
            {
                log.Debug("In Gaps class, in ClearScreen() function. ");
                Console.Clear();
            }
            catch (Exception e) {
                log.Error("In Gaps class, ClearScreen() function error: "+e.Message);
            }
        }
        public static void Sleeps(int time)
        {
            try
            {
                log.Debug("In Gaps class, in Sleeps() function. ");
                int millisec = time * 1000;
                System.Threading.Thread.Sleep(millisec);
            }
            catch (Exception e) {
                log.Error("In Gaps class,Sleeps() function error: " + e.Message);
            }
        }
    }

}
