using System;
using System.Collections.Generic;

namespace SetCalculator {
    public static class ExtensionMethods
    {
        public static bool Contains<T>(this List<dynamic> list, T elementToSearch)
        {
            foreach (var element in list)
            {
                if (element == elementToSearch) return true;
            }
            return false;
        }

    }
}
