using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    public static class PrintGameField
    {
        // Вывод игрового поля
        public static void MethodWhichPrintGameField(ClassGameOne game)
        {
            Console.CursorTop = 2;
           

            int[,] helperMassive = new int[(int)Math.Sqrt(game.returnfield().Length), (int)Math.Sqrt(game.returnfield().Length)];
            for (int i = 0; i < helperMassive.GetLength(0); i++)
            {
                Console.Write("\t\t\t");
                for (int j = 0; j < helperMassive.GetLength(1); j++)
                {
                    if (game[i, j] == 0)
                    {
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(game[i, j]);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|" + "\t");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("|" + game[i, j] + "|" + "\t");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void PrintHistory(List<int> history)
        {
            Console.Write("Ваша история: ");
            int count = 1;
            foreach (int i in history)
            {
                Console.Write(count + ") " + i + "\t");
                count++;
            }
            Console.WriteLine();
        }
    }
}