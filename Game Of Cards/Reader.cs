using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Game_Of_Cards
{
    class Reader
    {


        private static readonly log4net.ILog log = LogHelper.GetLogger();
        public static void WriteLog(string strLog)
        {
            try
            {
                string logFilePath = @"C:\Logs\Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";//this gives the formmat in which logs should be displayed.
                FileInfo logFileInfo = new FileInfo(logFilePath);// it stores the info of the path.
                DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))// it will simply append the message to the file
                {
                    using (StreamWriter log = new StreamWriter(fileStream))
                    {
                        log.WriteLine(strLog);
                    }
                }
            }
            catch (Exception e)
            {
                //save the exception in the form of error in the log fil
                log.Error("Error in Writelog: " + e.Message);
            }
        }
        public static int  ReadIt() {//A function to read from the file.
            try
            {
                StreamReader sr = new StreamReader("Text.txt");
                //Read the first line of text
                string line = "";
                string b = "";
                //Continue to read until you reach end of file
                while (line != null)
                {
                    b = line;
                    line = sr.ReadLine();
                }
               int marks = Int32.Parse(b);
           //     Console.Write(marks);
                sr.Close();
                return marks;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return 404;
            }          
        }
    }
}


/*
    StreamReader sr = new StreamReader("D:\\Text.txt");
            //Read the first line of text
            string line = "";
            string b = "";
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                //Console.WriteLine(line);
                b = line;
                //Read the next line
                line = sr.ReadLine();
            }
            string m="";
            int len = m.Length;
            //Console.Write(b);
          
            
           long marks = Int64.Parse(b);
            marks += 1;
            Console.Write(marks);
            //close the file
            sr.Close();
            Console.ReadKey();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Sample.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}*/
