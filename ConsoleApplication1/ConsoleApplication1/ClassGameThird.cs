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
        
        public readonly List<int> saveValueGameField;
        
        public ClassGameThird(params int[] numbers)
            : base(numbers)
        {
           
            saveValueGameField = new List<int>();
           
        }
        public ClassGameThird(int size)
            : base(size)
        {
            saveValueGameField = new List<int>();
            
        }

        public override bool Shift(int mValue)
        {
     
            int value = mValue;

            if (base.Shift(mValue))
            {
                
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
       
    }
}
