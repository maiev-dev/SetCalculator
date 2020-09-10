using System;
using System.Collections.Generic;

namespace SetCalculator {
    public static class ExtensionMethods
    {
        
        public static bool Equals<T>(this List<T> leftList, List<T> rightList)
        {
            if (leftList.Count != rightList.Count) return false;

            for (int i = 0; i < leftList.Count; ++i)
            {
                if ((leftList[i] as IComparable).Equals(rightList[i])) return false;
            }
            return true;
        }

        public static string DeleteSpaces(this string s)
        {
            string result = String.Empty;
            foreach (var symbol in s)
            {
                if (symbol != ' ') result += symbol; 
            }
            return result;
        }

        
    }
}
