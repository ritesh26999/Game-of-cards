using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Cards
{
    class Manager
    {


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
                log.Error(e.Message);
            }
        }
       public static void MainManager()
        {
            try
            {
                log.Debug("Entered in the MainManager function.");
                Gaps.LineBreak(5);//a function to break lines
                Gaps.TabsSpaces(3);//a function to give tabs spaces.
                Message.WelcomeMessage();//it will display welcome message.
                Gaps.Sleeps(3);//a function for sleep.  
                Console.Clear();
                Gaps.TabsSpaces(1);
                Gaps.LineBreak(2);

                while (true)
                {
                    Message.QuestionAboutMode();// asks Question form the suer.
                    Console.Write("\n Option: ");
                    String option = Console.ReadLine();
                    option = option.ToLower();
                    if (option.Equals("exit")) { Environment.Exit(0); }
                    else if (option.Equals("continue"))//this will led you to the game.
                    {
                        Game game = new Game_Of_Cards.Game();
                        Console.Clear();
                        game.play();
                    }
                    else if (option.Equals("manual"))//this will led you to the manual of the game.
                    {
                        Message.ManualMess();
                        Console.WriteLine(ConfigurationManager.AppSettings["CorrectValuePlease"]);//it will display message to enter the correct value.
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine(ConfigurationManager.AppSettings["CorrectValuePlease"]);
                        Console.WriteLine(ConfigurationManager.AppSettings["PressAnykey"]);//it will display mesage to Press any key.
                        Console.ReadKey();
                    }
                    log.Debug("out of the MainManager function.");
                    Console.Clear();
                }
             //   log.Debug("out of the MainManager function.");
            }
            catch (Exception e)
            {
                log.Error("Error in main " + e.Message);
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
