using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Tic_Tac_Toe_Challenge
{
    class Program
    {
        static char[,] array = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        static int choice = 0;
        static int player = 2;
        static bool validInput = false;

        static void Main(string[] args)
        {

            // run the code as long as the program runs
            do
            {
                Field();
                if (player == 2)
                {
                    player = 1;

                }
                else if (player == 1)
                {
                    player = 2;

                }
                do
                {
                    Console.Write("Player's {0} turn: ", player);
                    try
                    {
                        choice = int.Parse(Console.ReadLine());

                        if (choice < 1 || choice > 9)
                        {
                            throw new FormatException();
                        }

                        validInput = true;
                        // call replace char method
                        ChoiceXorO(player, choice);
                    }
                    catch (Exception)
                    {
                        validInput = false;
                        Console.WriteLine("Please select a valid number from the field.");
                    }


                } while (!validInput);
            } while (true);


        }

        // Field method, creates the game field
        public static void Field()

        {
            Console.Clear();
            Console.WriteLine("Player 1: X" + "\n" + "Player 2: O");
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", array[0, 0], array[0, 1], array[0, 2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", array[1, 0], array[1, 1], array[1, 2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", array[2, 0], array[2, 1], array[2, 2]);

            Console.WriteLine("     |     |      ");
        }
        public static void ChoiceXorO(int player, int choice)
        // Assign player sigh X or O
        {
            char playerChar = ' ';
            if (player == 1)
            {
                playerChar = 'X';
            }
            else if (player == 2)
            {
                playerChar = 'O';
            }

            switch (choice)
            {
                case 1:
                    Replace(0, 0, playerChar);
                    break;
                case 2:
                    Replace(0, 1, playerChar);
                    break;
                case 3:
                    Replace(0, 2, playerChar);
                    break;
                case 4:
                    Replace(1, 0, playerChar);
                    break;
                case 5:
                    Replace(1, 1, playerChar);
                    break;
                case 6:
                    Replace(1, 2, playerChar);
                    break;
                case 7:
                    Replace(2, 0, playerChar);
                    break;
                case 8:
                    Replace(2, 1, playerChar);
                    break;
                case 9:
                    Replace(2, 2, playerChar);
                    break;
            }

            // winning condition
            //[0,0],[0,1],[0,2]
            //[],[],[]
            //[],[],[]
            for (int y = 0; y < 3; y++)
            {
                if (array[y, 0] == array[y, 1] && array[y, 2] == array[y, 1])
                {
                    Console.WriteLine("Winner is player {0}", player);
                    Console.ReadKey();
                    Reset();
                }
            }
            for (int x = 0; x < 3; x++)
            {
                if (array[0, x] == array[1, x] && array[2, x] == array[1, x])
                {
                    Console.WriteLine("Winner is player {0}", player);
                    Console.ReadKey();
                    Reset();
                }
            }
            if (array[2, 0] == array[1, 1] && array[0, 2] == array[1, 1] || array[0, 0] == array[2, 2] && array[1, 1] == array[2, 2])
            {
                Console.WriteLine("Winner is player {0}", player);
                Console.ReadKey();
                Reset();
            }


            bool isDraw = true;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (array[x, y] != 'X' && array[x, y] != 'O')
                    {
                        isDraw = false;
                    }
                }
            }
            if (isDraw)
            {
                Console.WriteLine("It's a draw!");
                Console.ReadKey();
                Reset();
            }


        }


        public static void Replace(int x, int y, char playerChar)
        {
            if (array[x, y] != 'X' && array[x, y] != 'O')
            {
                array[x, y] = playerChar;
            }
            else
            {
                validInput = false;
                Console.WriteLine("Field already taken. Please select a valid one.");
            }

        }
        public static void Reset()
        {
            array = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            player = 2;

        }
    }
}
