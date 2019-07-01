using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Of_Cards
{
    //  log.Error("In Gaps class, ClearScreen() function error: "+e.Message);

    public enum Suit
    {
        Heart,    //0
        Diamond,  //1
        Spade,    //2
        Club      //3
    }

    public enum Face
    {
        Ace,    //0     10
        Two,    //1     2
        Three,  //2     
        Four,   //3     4
        Five,   //4
        Six,    //5     6
        Seven,  //6
        Eight,  //7     8
        Nine,   //8
        Ten,    //9     
        Jack,   //10    5
        Queen,  //11    6
        King,   //12    7
    }

    public class Card
    {
        public Suit Suit { get; set; }
        public Face Face { get; set; }
        public int Value { get; set; }
    }
}
