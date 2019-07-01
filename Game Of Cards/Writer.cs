using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Game_Of_Cards
{
    class Writer
    {

        public static void WriteIt(string highestScore)
        {
            try
            { 
                StreamWriter sw = new StreamWriter("Text.txt");
                sw.WriteLine(highestScore);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        }
    }
/*
using System;


Write a Text File(Version 1)
//Write a text file - Version-1
using System;
using System.IO;

namespace readwriteapp
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
           
    }
}*/