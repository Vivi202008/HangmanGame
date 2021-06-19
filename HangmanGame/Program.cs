using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static int guessFelTimes = 0;
        static List<string> wordList = new List<string> { "LEXIKON", "COMPUTER", "CSHARP", "PROGRAM", "BOOK" };
        static void Main(string[] arg)
        {
            Console.WriteLine("Hello, welcome to game ---- Hangman!");
            string userSelect;
            string wordToGuess;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("-------- Menu ----------");
                Console.WriteLine("1: PC VS Player.");
                Console.WriteLine("2: Player1 VS Player2.");
                Console.WriteLine("0: Quit.");
                Console.WriteLine("------------------------");
                Console.WriteLine("Input your choise. ");

                guessFelTimes = 0;

                userSelect = Console.ReadLine().Replace(" ", "");
                switch (userSelect)
                {
                    case "1":
                        Console.WriteLine("1: PC VS Player.");
                        wordToGuess = GenerateAWord();
                        UserGuessWord(wordToGuess);
                        break;
                    case "2":
                        Console.WriteLine("2: Player1 VS Player2");
                        wordToGuess = GenerateAWordFromUser();
                        UserGuessWord(wordToGuess);
                        break;

                    case "0":
                        Console.WriteLine("Thanks for Play this game.");
                        Console.WriteLine("Press any key to close program.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Not a valid selection.");
                        break;
                }
            } while (userSelect != "0");




        }

        static string GenerateAWordFromUser()
        {
            bool generateWordRight = false;
            string wordGuess;
            int m;
            do
            {
                Console.WriteLine("Please input a new word: ");
                m = 0;
                wordGuess = Console.ReadLine().Replace(" ", "");
                foreach (char letter in wordGuess)
                {
                    int b = (int)letter;
                    if (b < 65 || (b > 90 && b < 97) || b > 122)
                    {
                        Console.WriteLine("Input a ovalid word, please input a word again.");
                        generateWordRight = false;
                        break;
                    }
                    else
                    {
                        m++;
                    }
                }
                if (m == wordGuess.Length)
                {
                    wordGuess = wordGuess.ToUpper();
                    generateWordRight = true;
                }
            } while (!generateWordRight||wordGuess=="");

            Console.WriteLine(wordGuess);
            return wordGuess;
        }

        static void PrintHangman()
        {
            if (guessFelTimes == 1)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |        O");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 2)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |        O");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 3)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |        O");
                Console.WriteLine(" |       \\|");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 4)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |        O");
                Console.WriteLine(" |       \\|/");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 5)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |        O");
                Console.WriteLine(" |       \\|/");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 6)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |        O");
                Console.WriteLine(" |       \\|/");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |       /");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 7)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |        O");
                Console.WriteLine(" |       \\|/");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |       / \\");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
        }

        static string GenerateAWord()
        {
            Random rngWord = new Random();
            int wordIndex = rngWord.Next(wordList.Count);
            string wordGuess = wordList[wordIndex].ToUpper();

            Console.WriteLine(wordGuess);
            return wordGuess;

        }

        static void UserGuessWord(string wordGuess)
        {
            int wordLettersCount = wordGuess.Length;
            Console.WriteLine("Now, PC har a word to you, guess! The word har {0} letters, please input a letter", wordLettersCount);
            char[] wordUserGuessLetters = new char[wordLettersCount];
            int k = 0;

            int guessRightTimes = 0;
            char letterUserGuess;

            Array.Fill(wordUserGuessLetters, '*');


            do
            {
                letterUserGuess = InputALetter();
                k = 0;
                bool guessLetterRight = false;
                foreach (char letter in wordGuess)
                {
                    if (letterUserGuess == letter)
                    {
                        guessLetterRight = true;
                        wordUserGuessLetters[k] = letter;
                    }

                    //Console.WriteLine("letter {0} is {1}", k, letter);
                    k++;
                }

                Console.Clear();

                Console.WriteLine(letterUserGuess);
                for (int j = 0; j < wordLettersCount; j++)
                {
                    Console.Write(wordUserGuessLetters[j] + " ");
                }
                Console.WriteLine();
                if (!guessLetterRight)
                {
                    Console.WriteLine("So sorry, no {0} ! you guess fel, you lose a chance!", letterUserGuess);
                    guessFelTimes++;
                    Console.WriteLine("You have guessed fel {0} times.", guessFelTimes);
                    if (guessFelTimes == 7)
                    {
                        Console.WriteLine("You have no chance! The word is {0} .", wordGuess);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have {0} lifes left!", 7 - guessFelTimes);
                    }
                }
                else
                {
                    Console.WriteLine("Oj! you guess right! The word har letter " + letterUserGuess);
                    guessRightTimes = 0;
                    for (int i = 0; i < wordGuess.Length; i++)
                    {
                        if (wordUserGuessLetters[i] != char.Parse("*"))
                        {
                            guessRightTimes++;
                        }
                    }
                    if (guessRightTimes == wordLettersCount)
                    {
                        Console.WriteLine("Hurry! You guess succeed! The word is " + wordGuess);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have {0} lifes left! Try again!", 7 - guessFelTimes);
                    }
                }
                PrintHangman();
            } while (guessFelTimes < 7 || guessRightTimes < wordLettersCount);
        }

        static char InputALetter()
        {
            char ALetter = char.Parse("A");
            string userInputString = "";

            bool inputALetterRight = false;
            do
            {
                userInputString = Console.ReadLine().Replace(" ", "");

                if (userInputString.Length == 1)
                {
                    ALetter = Char.Parse(userInputString.ToUpper());
                    int a = (int)ALetter;
                    if (a < 65 || a > 90)
                    {
                        Console.WriteLine("Character is not valid. Input only a letter.");
                    }
                    else
                    {
                        inputALetterRight = true;
                    }
                }
                else
                {
                    Console.WriteLine("Character is not valid. Input only a letter.");
                }

            } while (!inputALetterRight);

            return ALetter;
        }


    }
}

