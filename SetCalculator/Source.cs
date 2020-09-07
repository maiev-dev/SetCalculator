using System;
using System.Collections.Generic;
using System.Text;

namespace SetCalculator
{
    class SetCalculator
    {
        public static int Main()
        {
            List<int> UniversalSet = new List<int>() { 1, 2, 3, 4, 5 };

            Set<int> set1 = new Set<int>(UniversalSet, 1, 2, 3);
            Set<int> set2 = new Set<int>(UniversalSet, 3, 4, 5);

            Set<int> result = !set1;


            result.Print();
            return 0;
        }
    }
}
