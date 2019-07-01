using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Spades
//clubs
//Diamonds
//heart


namespace Game_Of_Cards
{
    class Deck
    {



        private static readonly log4net.ILog log = LogHelper.GetLogger(); // Read only object of the log.
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

        private List<Card> LeftCards;
    //    private List<Card> PlayedCards;

        public Deck()
        {
            this.Initialize();//whenever the contructer will be called, it will make the new deck, by calling to the initiallize function.
        }

        public void Initialize()
        {
            try
            {
                log.Debug("In Deck Class, in Initialize() function.");
                LeftCards = new List<Card>();

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        LeftCards.Add(new Card() { Suit = (Suit)i, Face = (Face)j });


                        if (i == 2 && j == 0)
                        {
                            LeftCards[LeftCards.Count - 1].Value = 10;
                        }
                        else if (j % 2 != 0 && j < 9)
                            LeftCards[LeftCards.Count - 1].Value = j + 1;
                        else if (j % 2 == 0 && j != 8 && j < 9)
                            LeftCards[LeftCards.Count - 1].Value = -1 * (j + 1);
                        else if (j == 9)
                            LeftCards[LeftCards.Count - 1].Value = -10;
                        else if (j == 10)
                            LeftCards[LeftCards.Count - 1].Value = 5;
                        else if (j == 11)
                            LeftCards[LeftCards.Count - 1].Value = 6;
                        else if (j == 12)
                            LeftCards[LeftCards.Count - 1].Value = 7;
                    }
                }
            }
            catch (Exception e) {
                log.Error("In initialize, Error: "+e.Message);
            }
            log.Debug("In Deck Class, out of Initialize() function.");
        }

        public void Shuffle()
        {
            try
            {
                log.Debug("In shuffle, in function() ");
                Random rng = new Random();
                int n = LeftCards.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    Card card = LeftCards[k];
                    LeftCards[k] = LeftCards[n];
                    LeftCards[n] = card;
                }
            }
            catch (Exception e ) {
                log.Error("Exception e "+e.Message);
            }
            log.Debug("In shuffle, in function() ");

        }

        public Card DrawACard()
        {
            try
            {
                log.Debug("In the DrawCard() function ");
                if (LeftCards.Count <= 0)
                {
                    this.Initialize();
                }
             //   this.Shuffle();
                Card cardToReturn = LeftCards[LeftCards.Count - 1];
                LeftCards.RemoveAt(LeftCards.Count - 1);
                log.Debug("out of the DrawCard() function ");
                return cardToReturn;
            }
            catch (Exception e)
            {
                log.Error("Exception in DrawCard: "+e.Message);
                return null;
            }
        }

        public int GetAmountOfRemainingCrads()
        {
            try
            {
                return LeftCards.Count;
            }
            catch (Exception e) {
               
                log.Error(e.Message);
                return 0;
            }
        }

        public void PrintDeck()
        {
            try
            {
                int i = 1;
                foreach (Card card in LeftCards)
                {

                    Console.WriteLine(ConfigurationManager.AppSettings["CardsAndValue"], i, card.Face, card.Suit, card.Value);
                    i++;
                }
            }
            catch (Exception e ) {
                log.Error("Exceptio in PrintDECK() error: "+e.Message);

            }
        }



    }
}
