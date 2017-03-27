using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    internal class ClassGameSecond : ClassGameOne
    {
        public ClassGameSecond(params int[] numbers)
            : base(numbers)
        {
            GenerationNumbersOnField();
        }
        public ClassGameSecond(int size)
            : base(size)
        {
            GenerationNumbersOnField();
        }

        public void GenerationNumbersOnField()
        {
            Random gen = new Random();
            int temp = 0;
            //int temp = gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 1];
            //gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 1] = gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 2];
            //gameField[gameField.GetLength(0) - 1, gameField.GetLength(1) - 2] = temp;

            int index = 0;
            //========================
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    int x = gen.Next(0, gameField.GetLength(0));
                    int y = gen.Next(0, gameField.GetLength(1));
                    temp = gameField[x, y];
                    gameField[x, y] = gameField[i, j];
                    gameField[i, j] = temp;
                }

            }
            //========================
        }
        public bool CheckWin()
        {
            int[] numbers = new int[gameField.Length];
            int count = 0;
            //=======================================
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    numbers[count] = gameField[i, j];
                    count++;
                }
            }
            count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[numbers.Length - 1] == 0)
                    {
                        if ((i == numbers.Length - 1) || (j == numbers.Length - 1))
                        {
                        }
                        else
                        {
                            if (j > i)
                            {
                                if (numbers[i] > numbers[j])
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
            //==================================
        }
    }
}