using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Game_Of_Cards
{
    class Message
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
            catch (Exception e) {
                log.Error("Error in Writelog: "+e.Message);
            }
        }
        public static void WelcomeMessage()
        {
            try
            {
                log.Debug("In Message class, in WelcomeMessage() function. ");
                Console.WriteLine(ConfigurationManager.AppSettings["WelcomeMessage"]);
                System.Console.Write('\u003A');
                System.Console.WriteLine('\u0029');
                log.Debug("In Message class, out of WelcomeMessage() function. ");
            }
            catch(Exception e) {
                log.Error("In Message class Ist function: "+e.Message); 
            }

        }

        public static void QuestionAboutMode()
        {
            try
            {
                log.Debug("In Message class, in QuestionAboutMode() function. ");
                Gaps.LineBreak(2);
                Gaps.TabsSpaces(3);
                //   ConfigurationManager.AppSettings["WelcomeMessage"]);
                Console.Write(ConfigurationManager.AppSettings["MainMenu"]);
                Gaps.LineBreak(1);
                Console.Write(ConfigurationManager.AppSettings["DoYouKnow"]);
                log.Debug("In Message class, out QuestionAboutMode() function. ");
            }
            catch (Exception e)
            {
                log.Error("In Message class IInd function: " + e.Message);
            }
        }



        public static void ManualMess()
        {
            try
            {
                Console.Clear();
                log.Debug("In Message class, ManualMess() function");
                StreamReader sr = new StreamReader("Man.txt");
                //Read the first line of text
                string line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }

                log.Debug("In Message class, out of ManualMess() function");
                sr.Close();
             }
            catch (Exception e)
            {
                log.Error(" In Message class, ManualMess() function error: "+e.Message);
               // Console.WriteLine("Exception: " + e.Message);
                // return 404;
            }

        }


        public static void MyChoices()
        {
            try {

                log.Debug("In Message class, in MyChoice() function");
                StreamReader sr = new StreamReader("MyChoices.txt");
                //Read the first line of text
                string line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                log.Debug("In Message class, out of MyChoice() function");
                sr.Close();
         
            }
            catch (Exception e)
            {
                Console.WriteLine("In Message class, MyChoices() function error: " + e.Message);
                // return 404;
            }
        }
           
           
        }

    }
