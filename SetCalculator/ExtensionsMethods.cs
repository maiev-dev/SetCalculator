using System;
using System.Collections.Generic;

namespace SetCalculator {
    public static class ExtensionMethods
    {   
        public static string DeleteSpaces(this string s)
        {
            string result = String.Empty;
            foreach (var symbol in s)
            {
                if (symbol != ' ') result += symbol; 
            }
            return result;
        }

        public static string CorrectCommutativeOperations(this string operation)
        {
            if (operation == "B&A") return "A&B";
            if (operation == "B|A") return "A|B";
            return operation;
        }
    }
}
