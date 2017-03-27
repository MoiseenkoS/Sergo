using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Barley_break
{
    public class ClassGameOne
    {
        protected int[,] gameField;
        private int[] numbersMassive;

        public ClassGameOne(params int[] valueForPlay)
        {
            numbersMassive = valueForPlay;
            gameField = new int[(int)Math.Sqrt(valueForPlay.Length), (int)Math.Sqrt(valueForPlay.Length)];

            if (IsExsistGameField())
            {
                FilingArrayValueOfFile();
            }
            else
            {
                throw new Exception();
            }
        }
        public ClassGameOne(int size)
        {
            this.gameField = new int[size, size];
            numbersMassive = new int[size * size];

            numbersMassive = FilingNumbers();
            FilingArayNumbersValue();

            if ((size > 2) && (IsExsistGameField()))
            {
            }
            else
            {
                throw new Exception();
            }
        }
        private void FilingArrayValueOfFile()
        {
            int temp = 0;

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    gameField[i, j] = numbersMassive[temp];
                    temp++;
                }
            }
        }
        private int[] FilingNumbers()
        {
            int temp = 1;

            for (int i = 0; i < numbersMassive.Length; i++)
            {
                if (numbersMassive.Length - 1 == i)
                {
                    numbersMassive[i] = 0;
                }
                else
                {
                    numbersMassive[i] = temp;
                }
                temp++;
            }

            return numbersMassive;
        }
        private void FilingArayNumbersValue()
        {
            int temp = 0;
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    gameField[i, j] = numbersMassive[temp];
                    temp++;
                }
            }
        }
        private bool IsExsistGameField()
        {
            int count = 0;

            if (Math.Sqrt(numbersMassive.Length) % 1 == 0)
            {
                count = 1;
            }
            //=====================
            int zeroCount = 0;
            for (int i = 0; i < numbersMassive.Length; i++)
            {
                if (numbersMassive[i] == 0)
                {
                    zeroCount++;
                }
            }

            for (int i = 0; i < numbersMassive.Length; i++)
            {
                for (int j = 0; j < numbersMassive.Length; j++)
                {
                    if (i < j)
                    {
                        if (numbersMassive[i] == numbersMassive[j])
                        {
                            return false;
                        }
                    }
                }
            }

            if ((count == 1) && (zeroCount == 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Индексатор
        public int this[int i, int j]
        {
            get { return gameField[i, j]; }
        }
        // Метод, который находит координаты
        protected int[] GetLocation(int moveValue)
        {
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == moveValue)
                    {
                        return new[] { i, j };
                    }
                }
            }
            return null;
        }
        // Метод, который отвечает за перемещение
        public virtual bool Shift(int moveValue)
        {
            int count = 0;
            int temp = 0;
            int[] massiveZero;
            int[] massiveMoveValue;

            massiveZero = GetLocation(0);
            massiveMoveValue = GetLocation(moveValue);

            if ((massiveMoveValue != null) && (Math.Sqrt(Math.Pow(massiveMoveValue[0] - massiveZero[0], 2) + Math.Pow(massiveMoveValue[1] - massiveZero[1], 2)) == 1))
            {
                // Перемещение
                temp = gameField[massiveMoveValue[0], massiveMoveValue[1]];
                gameField[massiveMoveValue[0], massiveMoveValue[1]] = gameField[massiveZero[0], massiveZero[1]];
                gameField[massiveZero[0], massiveZero[1]] = temp;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int[,] returnfield()
        {
            return gameField;
        }
    }
}
