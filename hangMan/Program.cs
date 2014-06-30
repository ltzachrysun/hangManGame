using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HangMan
{
    class Program
    {

        //Pulbic Variable
        static string userName = "";
        static string input = "";
        static List<string> lettersGuessed = new List<string>() { };
        static int guesses = 10;
        static bool gotOne = false;
        static bool wordGuessed = false;
        static string[] wordArray = { "binary", "code", "integer", "syntax", "function", "string", "bool", "loop", "comment", "error", "seedpaths" };
        static System.Random randomTemp = new Random();
        static int random = randomTemp.Next(0, wordArray.Length);
        static string word = wordArray[random];

        static void Main(string[] args)
        {
            Print("Please enter your name");
            userName = Console.ReadLine();
            Console.Clear();
            Welcome();
            Stats();
        }

        //Welcome Function
        static void Welcome()
        {
            Print("Welcome to the text adventure that is Hang Man. " + userName);
            Thread.Sleep(500);
            Print("You will be guessing letters to find a randomly generated word.");
            Thread.Sleep(500);
            Print("You also have the chance to guess the entire word.");
            Thread.Sleep(500);
            Print("If you guess the word correctly, you claim victory.");
            Thread.Sleep(500);
            Print("If you take too many guesses, you suffer riddicule.");
            Thread.Sleep(500);
            Console.WriteLine();
            Print("Press any key to begin..");
            Console.ReadKey();
        }

        //Stats Function
        static void Stats()
        {
            Console.Clear();
            Console.Write("Letters Guessed: ");
            foreach (var item in lettersGuessed)
            {
                Console.Write(item.ToUpper() + " ");
            }
            Console.WriteLine();
            Print("remaining guesses: " + guesses);
            Console.WriteLine("Word: " + Mask(word, lettersGuessed));
            Console.ForegroundColor = ConsoleColor.Blue;
            Print("Enter a letter or word now");
            Console.ResetColor();
            Console.WriteLine();
            input = Console.ReadLine().ToString().ToLower();
            Add();
        }

        //Add Function
        static void Add()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (input == word[i].ToString())
                {
                    gotOne = true;
                }
                else if (input == word)
                {
                    wordGuessed = true;
                }
            }

            if (gotOne)
            {
                Print("Good job, you guessed a letter!");
                lettersGuessed.Add(input);
                gotOne = false;
                Thread.Sleep(1500);
                Stats();
            }
            else if (wordGuessed)
            {
                Winner();
            }
            else if (guesses == 0)
            {
                Loser();
            }
            else
            {
                Print("The word does not contain '" + input + "'");
                lettersGuessed.Add(input);
                guesses--;
                Thread.Sleep(1500);
                Stats();
            }
        }

        //Mask Function
        static string Mask(string word, List<string> guessedLetters)
        {
            string returnString = "";
            int i = 0;
            bool gotOne = false;

            while (i < word.Length)
            {
                var letter = word[i].ToString();
                foreach (var item in guessedLetters)
                {
                    if (item == letter)
                    {
                        gotOne = true;
                    }
                }
                if (gotOne)
                {
                    returnString += letter.ToUpper() + " ";
                    gotOne = false;
                }
                else
                {
                    returnString += "_ ";
                }
                i++;
            }
            return returnString;
        }

        //Winner Function
        static void Winner()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Print("Congratulations " + userName + ". victory is yours.");
            Console.ResetColor();
            Console.WriteLine();
            Print("Remaining guesses: " + guesses);
            Print("Word: " + word.ToUpper());
            End();
        }

        //Loser Function
        static void Loser()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Print("Bad luck i'm afraid.. " + userName + ", You have failed");
            Console.ResetColor();
            Print("Your guesses exceeded the limit");
            Console.WriteLine();
            Print("Remaining guesses: " + guesses);
            Print("Word: " + word.ToUpper());
            End();
        }

        //Print Function
        static void Print(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i]);
                Thread.Sleep(1);
            }
            Console.WriteLine();
        }

        //End Function
        static void End()
        {
            Console.WriteLine();
            Print("be sure to play again..");
            Console.ReadKey();
        }
    }
}