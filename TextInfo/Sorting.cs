using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInfo
{
    internal class Sorting
    {
        public static string SortString(string input, bool reverse) // Этот метод выполняет сортировку строки. Если true - по убыванию, иначе - по возрастанию
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            if (reverse)
                Array.Reverse(characters);
            return new string(characters);
        }
    }
}
