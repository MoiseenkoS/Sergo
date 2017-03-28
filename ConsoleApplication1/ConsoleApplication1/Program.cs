using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Barley_break
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] returnInt = ClassWhichReadOfFile.ReadFromFile("C:\\Users\\student\\Desktop\\txt.txt");
            Console.Write("\tВы можете поиграть в ТРИ игры\nВ превой игре у вас не будет говорится о победе\n\tВо второй игре у вас будет реализация перемешивания и выйграша" +
                          "\n\tВ третьей игре вы играете в полноценную игру\n\tВыберете цифры от 1-3 = ");
            int usersName = Convert.ToInt32(Console.ReadLine());
           
            switch (usersName)
            {
                case 1:
                    {
                        ClassGameOne game1 = new ClassGameOne(returnInt);
                        StatGame1(game1);
                        break;
                    }
                case 2:
                    {
                        ClassGameSecond game2 = new ClassGameSecond(5);
                        StartGame2(game2);
                        break;
                    }
                case 3:
                    {
                        ClassGameThird game3 = new ClassGameThird(returnInt);
                        StartGame3(game3);
                        break;
                    }
            }
            Console.ReadKey();
        }

        static void StatGame1(ClassGameOne game1)
        {
            int moveValue = 0;
            Console.Clear();
            PrintGameField.MethodWhichPrintGameField(game1);
            try
            {
                Console.Write("Eсли хотите поменять числа, введите число = ");
                moveValue = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {

                throw new Exception("Введен неопознанный символ");
            }

            Console.Clear(); PrintGameField.MethodWhichPrintGameField(game1);
            Console.Write("Как надоест играть, нажмите введите '1000' = ");
            while (!(moveValue == 1000))
            {
                if (game1.Shift(moveValue))
                {
                    Console.Clear();
                    PrintGameField.MethodWhichPrintGameField(game1);
                }
                else
                {
                    Console.WriteLine("\t\tНекорректные данные!!!");
                }
                Console.Write("Введите число = ");
                moveValue = Convert.ToInt32(Console.ReadLine());
            }
            
        }
        static void StartGame2(ClassGameSecond game2)
        {
            int moveValue = 0;
            Console.Write("\n\tХотите ли вы сыграть? \n\t если да наберите Y \n\t если нет то любую клавишу = ");
            while (Convert.ToString(Console.ReadLine()) == "Y")
            {
                Console.Clear();
                PrintGameField.MethodWhichPrintGameField(game2);

                while (!game2.CheckWin())
                {
                    try
                    {
                        Console.Write("Eсли хотите поменять числа, введите число = ");
                        moveValue = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                        throw new Exception("Введен неопознанный символ");
                    }

                    Console.Clear(); PrintGameField.MethodWhichPrintGameField(game2);
                    if (game2.Shift(moveValue))
                    {
                        Console.Clear(); PrintGameField.MethodWhichPrintGameField(game2);
                    }
                    else
                    {
                        Console.WriteLine("\t\tНекорректные данные!!!");
                    }
                }
               
                Console.WriteLine("Вы выиграли!");
                Console.Write("Если вы хотите сыграть еще раз, намите Y = ");
            }
        }
        static void StartGame3(ClassGameThird game3)
        {
            int moveValue = 0;
            Console.Write("\n\tХотите ли вы сыграть? \n\t если да наберите Y \n\t если нет то любую клавишу = ");
            while (Convert.ToString(Console.ReadLine()) == "Y")
            {
                Console.Clear();
                PrintGameField.MethodWhichPrintGameField(game3);

                while (!game3.CheckWin())
                {
                    try
                    {
                        Console.Write("Eсли хотите поменять числа, введите число = ");
                        moveValue = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {

                        throw new Exception("Введен неопознанный символ");
                    }

                    Console.Clear(); PrintGameField.MethodWhichPrintGameField(game3);
                    if (game3.Shift(moveValue))
                    {
                        Console.Clear(); PrintGameField.MethodWhichPrintGameField(game3);
                        PrintGameField.PrintHistory(game3.saveValueGameField);
                        Console.Write("Чтобы сделать откат на один шаг нажмите 'r' = ");

                        while (Convert.ToString(Console.ReadLine()) == "r")
                        {
                            Console.Clear();
                            game3.Rollback();
                            PrintGameField.MethodWhichPrintGameField(game3);
                            PrintGameField.PrintHistory(game3.saveValueGameField);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\tНекорректные данные!!!");
                    }
                }
                Console.WriteLine("Вы выиграли!");
                Console.Write("Если вы хотите сыграть еще раз, намите Y = ");
            }
        }
    }
}