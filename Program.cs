using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkMaps
{
    class Program
    {
        static void Main(string[] args)
        {
            int userX = 1;
            int userY = 1;
            int allDollarMap = 7;
            Console.CursorVisible = false;
            char[] bag = new char[0];
            char[,] map = {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','$',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','$','#' },
                {'#',' ',' ',' ','#',' ','#',' ','#',' ',' ',' ','#','#','#','#','#','#','#','#',' ',' ','#' },
                {'#',' ',' ',' ','#','$','#',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ','#',' ','#',' ',' ',' ',' ',' ','$',' ','#',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#' },
                {'#',' ','#','#','#','#','#','#','#','#','#','#','#',' ',' ',' ','#',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','$','#' },
                {'#',' ',' ',' ','#','#','#','#',' ','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#','$',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ','#',' ','#','#','#','#','#' },
                {'#',' ',' ',' ',' ',' ',' ','#','#','#','#','#',' ','#',' ',' ','#',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ',' ','$','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' }
            };

            while (allDollarMap != 0)
            {
                ShowMap(map, userX, userY);
                ShowBag(bag);
                MoveUser(map, ref userX, ref userY);
                PickUpDollar(map, ref bag, ref allDollarMap, userX, userY);
            }

            Console.SetCursorPosition(35, 2);
            Console.WriteLine("Поздравляем вы собрали все доллары!");
        }

        static void ShowMap(char[,] map, int x, int y)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(y, x);
            Console.Write('@');
        }

        static void MoveUser(char[,] map, ref int userX, ref int userY)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[userX - 1, userY] != '#')
                    {
                        userX--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[userX + 1, userY] != '#')
                    {
                        userX++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[userX, userY - 1] != '#')
                    {
                        userY--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[userX, userY + 1] != '#')
                    {
                        userY++;
                    }
                    break;
            }
        }

        static void PickUpDollar(char[,] map, ref char[] bag, ref int allDollarMap, int userX, int userY)
        {
            if (map[userX, userY] == '$')
            {
                map[userX, userY] = ' ';
                char[] tempBag = new char[bag.Length + 1];
                for (int i = 0; i < bag.Length; i++)
                {
                    tempBag[i] = bag[i];
                }
                tempBag[tempBag.Length - 1] = '$';
                bag = tempBag;
                allDollarMap--;
            }
        }

        static void ShowBag(char[] bag)
        {
            Console.SetCursorPosition(35, 0);
            Console.Write("Собраное доллары:");
            for (int i = 0; i < bag.Length; i++)
            {
                Console.Write(bag[i] + "");
            }
        }
    }
}
