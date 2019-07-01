using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Cards
{
    class Game
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
                log.Error("Error in Writelog: " + e.Message);
            }
        }




        private static int count = 10; //stores the total number of chances one can play.
        private static int totalScore = 0;//total score

        Deck deck = new Deck();//hmarey card initialize ho gye.
        public void YourCards()
        {
            try
            {
                deck.PrintDeck();
            } catch (Exception e) {
            log.Error("Exception in YourCards() function, Error: "+e.Message);}
        }
        public void play()
        {
            try
            {
                log.Debug("In Play() funnction");
                bool areMyChoicesVisible = true;
                Message.MyChoices();
                while (count > 0)
                {

                    if (areMyChoicesVisible == false) { Message.MyChoices(); areMyChoicesVisible = true; }

                    Console.Write(ConfigurationManager.AppSettings["YourChoices"], count);
                    // Console.Write("You have {0} chance left, Make your choice: ", count);
                    string options = Console.ReadLine();
                    switch (options)
                    {

                        case "1":

                            Card drawCards = deck.DrawACard();
                            Console.WriteLine(ConfigurationManager.AppSettings["YourChoosenCardAndValue"], drawCards.Face, drawCards.Suit, drawCards.Value);
                            totalScore += drawCards.Value;
                            Console.WriteLine();
                            count--;
                            break;
                        case "2":
                            deck.Shuffle();
                            break;
                        case "3":
                            Console.Clear();
                            areMyChoicesVisible = false;
                            PrintTotalScore();
                            deck = new Deck();
                            count = 10;
                            break;
                        case "4":
                            Environment.Exit(0);
                            count = 0;
                            break;
                        default:
                            Console.WriteLine(ConfigurationManager.AppSettings["CorrectValuePlease"]);
                            Console.ReadKey();
                            break;
                    }
                }
                PrintTotalScore();
                PlayMore();
            } catch (Exception e) {
                log.Error("Exception in play, Error: "+e.Message);
            }
            log.Debug("out of Play() funnction");
        }


        void PrintTotalScore()
        {
            try
            {
                log.Debug("in the PrintTotalScore()");
                Console.Clear();
                int ts = totalScore;
                totalScore = 0;
                bool isHighest = false;
                if (Reader.ReadIt() < ts)
                {
                    Writer.WriteIt("" + ts);
                    isHighest = true;


                }
                Console.Write(ConfigurationManager.AppSettings["TotalAndHighestScore"], ts, Reader.ReadIt());
                if (isHighest == true)
                {
                    Gaps.LineBreak(1);
                    Gaps.TabsSpaces(3);
                    Console.Write(ConfigurationManager.AppSettings["CongratsMessage"]);
                }
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception e) {
                log.Error("Exceptio in PrintTotalScore(), Error: "+e.Message);
            }
            log.Debug("out of the PrintTotalScore()");
        }

        bool PlayMore()
        {
            try
            {
                log.Debug("In the PlayMore() function");
                bool ans = false;
                Console.Write(ConfigurationManager.AppSettings["Re_Play"]);
                String option = Console.ReadLine();
                option = option.ToLower();
                if (option.Equals("yes"))
                { count = 10; play(); ans = true; }
                else { count = 10; ans = false; }
                Console.Clear();
                return false;
            }
            catch (Exception e) {
                log.Error("Exceptiom in playMore(), error: "+e.Message);
                return false;
            }
            log.Debug("out of  the PlayMore() function");
        }


    }
}
