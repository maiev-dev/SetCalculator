using System;
using System.Collections.Generic;

namespace SetCalculator {
    public static class ExtensionMethods
    {
        /*
        public static bool Contains<T>(this List<T> list, T elementToSearch) 
        {
            foreach (var element in list)
            {
                if ((IComparable)element == (IComparable)elementToSearch) 
                    return true;
            }
            return false;
        }
        */
        public static bool Equals<T>(this List<T> leftList, List<T> rightList)
        {
            if (leftList.Count != rightList.Count) return false;

            for (int i = 0; i < leftList.Count; ++i)
            {
                if ((dynamic)leftList[i] != (dynamic)rightList[i]) return false;
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
