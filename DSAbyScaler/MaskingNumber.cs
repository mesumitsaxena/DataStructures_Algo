using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAbyScaler
{
    internal class MaskingNumber
    {
        public void MaskNmbr()
        {
            string number = "(123) 234-4567";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] >= 48 && number[i] <= 57 && i < number.Length - 4)
                {
                    sb.Append('X');
                }
                else
                {
                    sb.Append(number[i]);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
