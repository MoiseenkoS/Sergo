using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barley_break
{
    class ClassGameThird : ClassGameSecond
    {
        //public readonly List<int[]> saveCoordinateGameField;
        public readonly List<int> saveValueGameField;
        //public int[] help;
        public ClassGameThird(params int[] numbers)
            : base(numbers)
        {
            //saveCoordinateGameField = new List<int[]>();
            saveValueGameField = new List<int>();
            //help = new int[4];
        }
        public ClassGameThird(int size)
            : base(size)
        {
            saveValueGameField = new List<int>();
            //help = new int[4];
        }

        public override bool Shift(int mValue)
        {
            //int[] massiveCoordinateZero = GetLocation(0);
            //int[] massiveMoveValue = GetLocation(mValue);
            int value = mValue;

            if (base.Shift(mValue))
            {
                //saveCoordinateGameField.Add(massiveCoordinateZero);
                //saveCoordinateGameField.Add(massiveMoveValue);

                //help = new[] { massiveCoordinateZero[0], massiveCoordinateZero[1], massiveMoveValue[0], massiveMoveValue[1] };
                saveValueGameField.Add(value);
                return true;
            }
            return false;
        }
        public void Rollback()
        {
            if (!(saveValueGameField.Count - 1 == -1))
            {
                int valueWhichSaveLastNumbers = saveValueGameField[saveValueGameField.Count - 1];
                saveValueGameField.Remove(valueWhichSaveLastNumbers);
                base.Shift(valueWhichSaveLastNumbers);
            }
        }
        //public int[] returnHelp()
        //{
        //    return help;
        //}
    }
}
