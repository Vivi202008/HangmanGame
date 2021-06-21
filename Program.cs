using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Program
    {
        static int guessFelTimes = 0;
        static string[] words = new string[5] { "LEXIKON", "COMPUTER", "CSHARP", "PROGRAM", "BOOK" };
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
                Console.WriteLine("Input your choice. ");

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
                        int scoreOfPlayer1 = 0, scoreOfPlayer2 = 0;
                        bool endGame = false;
                        bool guessRight = false;

                        do
                        {
                            Console.WriteLine();   //player1 and player2 match
                            scoreOfPlayer2 = scoreOfPlayer2 + scoreOfPlayer(1, 2);
                            Console.WriteLine("Player1's score: {0}, Player2's score: {1}", scoreOfPlayer1, scoreOfPlayer2);
                            scoreOfPlayer1 = scoreOfPlayer1 + scoreOfPlayer(2, 1);
                            Console.WriteLine("Player1's score: {0}, Player2's score: {1}", scoreOfPlayer1, scoreOfPlayer2);
                            Console.WriteLine();
                            bool inputYN = true;
                            do
                            {  //next round
                                Console.WriteLine("Will you play next round? Input Y/N");
                                string playAgain = Console.ReadLine();

                                switch (playAgain)
                                {
                                    case "Y":
                                        endGame = false;
                                        inputYN = true;
                                        break;
                                    case "y":
                                        endGame = false;
                                        inputYN = true;
                                        break;
                                    case "n":
                                        endGame = true;
                                        inputYN = true;
                                        break;
                                    case "N":
                                        endGame = true;
                                        inputYN = true;
                                        break;
                                    default:
                                        Console.WriteLine("You choose fel, input Y/N ");
                                        inputYN = false;
                                        break;
                                }
                            } while (!inputYN);

                        } while (!endGame);

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

        static int scoreOfPlayer(int v1, int v2)
        {
            //one player generates a word, the other guesses. return the score if the other guesses right.
            bool guessRight;
            int score = 0;
            string wordToGuess;
            Console.WriteLine();
            Console.WriteLine("Nu, player{0} writes a secret word, and player{1} guesses the word.", v1, v2);
            Console.WriteLine("Player{0} inputs a word.", v1);
            wordToGuess = GenerateAWordFromUser();
            Console.WriteLine("Player{0} guesses the word.", v2);
            guessRight = UserGuessWord(wordToGuess);
            if (guessRight)
            {
                score++;
            }
            return score;
        }

        static string GenerateAWordFromUser()
        {
            bool generateWordRight = false;
            string wordGuess;
            int m;
            do   //Ueser inputs a letter or a word
            {
                Console.WriteLine("Please input a new word: ");
                m = 0;
                wordGuess = Console.ReadLine().Replace(" ", "");
                foreach (char letter in wordGuess)
                {    //Is every letter valid?  a-z or A-Z 
                    int b = (int)letter;
                    if (b < 65 || (b > 90 && b < 97) || b > 122)
                    {
                        Console.WriteLine("Input a ovalid word,  please input a word again.");
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
                    wordGuess = wordGuess.ToUpper(); //convert to big letters
                    generateWordRight = true;
                }
            } while (!generateWordRight || wordGuess == "");
            Console.Clear();
            //Console.WriteLine(wordGuess);
            return wordGuess;
        }

        static void PrintHangman()
        {
            if (guessFelTimes == 1)
            {
                Console.WriteLine("  ");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 2)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" | ");
                Console.WriteLine(" | ");
                Console.WriteLine(" | ");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 3)
            {
                Console.WriteLine(" __________");
                Console.WriteLine(" |        |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
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
                Console.WriteLine(" | ");
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
                Console.WriteLine(" |        |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine(" |");
                Console.WriteLine("_|__");
            }
            else if (guessFelTimes == 6)
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
            else if (guessFelTimes == 7)
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
            else if (guessFelTimes == 8)
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
            else if (guessFelTimes == 9)
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
            else if (guessFelTimes == 10)
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
            int wordIndex = rngWord.Next(words.Length);
            string wordGuess = words[wordIndex].ToUpper();

            //Console.WriteLine(wordGuess);
            return wordGuess;

        }

        static bool UserGuessWord(string wordGuess)
        {
            int wordLettersCount = wordGuess.Length;
            StringBuilder lettersFel = new StringBuilder();
            StringBuilder wordsFel = new StringBuilder();
            bool guessRight = false;
            Console.WriteLine("Now, there is a word to you, guess! The word har {0} letters, please input a specific letter or a whole word. ", wordLettersCount);
            for (int i = 0; i < wordLettersCount; i++)
            {
                Console.Write("_ ");
            }
            Console.WriteLine();
            char[] wordUserGuessLetters = new char[wordLettersCount];
            int k = 0;

            int guessRightTimes = 0;
            string letterUserGuess;
            guessFelTimes = 0;

            Array.Fill(wordUserGuessLetters, '_');


            do
            {
                letterUserGuess = InputALetterOrWord();
                k = 0;
                bool guessLetterRight = false;
                // player inputs only a letter.
                if (letterUserGuess.Length == 1)
                {
                    foreach (char letter in wordGuess)  //letter that player input is right?
                    {
                        if (letterUserGuess == letter.ToString())
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

                        k = 0;
                        string lettersGuessFel = lettersFel.ToString().Replace(" ", "");
                        foreach (char letter in lettersGuessFel)
                        {
                            if (letterUserGuess == letter.ToString())
                            {
                                Console.WriteLine("You input a same fel letter {0}", letter);
                                break;
                            }
                            else
                            {
                                k++;
                                //Console.WriteLine("You input a fel letter {0}", letter);
                            }
                        }
                        if (k == lettersGuessFel.Length)
                        {
                            guessFelTimes++;
                        }
                        lettersFel.Append(letterUserGuess.ToString() + " ");
                        Console.Write("You har inputed fel letters:  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(lettersFel);
                        Console.WriteLine(wordsFel);
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.WriteLine("You have guessed fel {0} times.", guessFelTimes);
                        if (guessFelTimes == 10)
                        {
                            Console.WriteLine("You have no chance! The word is {0} .", wordGuess);
                            PrintHangman();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You have {0} lifes left!", 10 - guessFelTimes);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Oj! you guess right! The word har letter " + letterUserGuess);
                        guessRightTimes = 0;
                        if (!(lettersFel.ToString() == "") || !(wordsFel.ToString() == ""))
                        {
                            Console.Write("You har inputed fel letters:  ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(lettersFel);
                            Console.WriteLine(wordsFel);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine();
                        }
                        for (int i = 0; i < wordGuess.Length; i++)
                        {
                            if (wordUserGuessLetters[i] != char.Parse("_"))
                            {
                                guessRightTimes++;
                            }
                        }
                        if (guessRightTimes == wordLettersCount)
                        {
                            PrintRightResult(wordGuess);
                            guessRight = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You have {0} lifes left! Try again!", 10 - guessFelTimes);
                        }
                    }
                }


                if (letterUserGuess.Length > 1)  //input more letters than 1.
                {
                    if (letterUserGuess == wordGuess)
                    {
                        PrintRightResult(wordGuess);
                        guessRight = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("NO!NO! You input a fel word {0}, please input again ", letterUserGuess);
                        guessFelTimes++;
                        for (int j = 0; j < wordLettersCount; j++)
                        {
                            Console.Write(wordUserGuessLetters[j] + " ");
                        }
                        Console.WriteLine();
                        wordsFel.Append(letterUserGuess.ToString() + " ");
                        Console.Write("You har inputed fel letters:  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(lettersFel);
                        Console.WriteLine(wordsFel);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (guessFelTimes < 10)
                        {
                            Console.WriteLine("You have {0} lifes left! Try again!", 10 - guessFelTimes);
                        }
                        else
                        {
                            Console.WriteLine("You have no life. The word to guess is " + wordGuess + ", try other word.");
                            PrintHangman();
                            break;
                        }

                    }
                }



                PrintHangman();
            } while (guessFelTimes < 10 || guessRightTimes < wordLettersCount);
            return guessRight;
        }

        static void PrintRightResult(string wordGuess)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Hurry! You guess succeed!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("The word is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(wordGuess);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        static string InputALetterOrWord()
        {
            String userInputString = "";

            bool inputRight = false;
            do
            {
                userInputString = Console.ReadLine().Replace(" ", "");  
                int countOfInput = 0;
                foreach (char aLetter in userInputString)
                {
                    int a = (int)aLetter;
                    if (a < 65 || (a > 90 && a < 97) || a > 122)
                    {
                        Console.WriteLine("Character is not valid. Input again.");
                        inputRight = false;
                        break;
                    }
                    else
                    {
                        inputRight = true;
                        countOfInput++;
                        if (countOfInput == userInputString.Length)
                        {
                            userInputString = userInputString.ToUpper();
                            Console.WriteLine("Input is valid. Input is: " + userInputString);
                        }
                    }
                }
            } while (!inputRight);
            return userInputString;
        }


    }
}

