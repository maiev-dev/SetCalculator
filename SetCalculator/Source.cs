using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SetCalculator
{
   
   
    class SetCalculator
    {
        const string endOfInput = "eof";
        const string close = "close";
        public static int Main()
        {

            Console.Write("Добро пожаловать в калькулятор множеств! \n" +
                            "Текущая версия приложения - 0.9.0 \n" +
                            "\n");

            Console.WriteLine("Введите члены универсального множества, ввод закончите символом endOfInput");
            List<int> UniversalSet = new List<int>();
            string candidate = Console.ReadLine();
            while (candidate != endOfInput)
            {
                int i_candidate = Convert.ToInt32(candidate);
                if (!UniversalSet.Contains(i_candidate))
                {
                    UniversalSet.Add(i_candidate);
                }
                else
                {
                    Console.WriteLine("Такой элемент уже содержится во множестве, повторите ввод");
                }
                candidate = Console.ReadLine();
            }
            Set<int> set1 = new Set<int>(UniversalSet);
            Set<int> set2 = new Set<int>(UniversalSet);

            Console.WriteLine("Введите множество A");
            candidate = Console.ReadLine();
            while (candidate != endOfInput)
            {
                int i_candidate = Convert.ToInt32(candidate);
                try
                {
                    set1.Push(i_candidate);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                candidate = Console.ReadLine();
            }

            set1.Print();
            set1.PrintDescribeVector();
            Console.WriteLine("Введите множество B");
            candidate = Console.ReadLine();
            while (candidate != endOfInput)
            {
                int i_candidate = Convert.ToInt32(candidate);
                
                try
                {
                    set2.Push(i_candidate);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                candidate = Console.ReadLine();
            }

            set2.Print();
            set2.PrintDescribeVector();

            Console.WriteLine(
                "Время выполнять операции, доступны следующие операции: \n" +
                "A & B - Пересечение множеств \n" + 
                "A | B - Объединение множеств \n" +
                "!A - Дополнение множества A до универсального \n" +
                "A / B - Разность множеств \n" + 
                "Когда надоест введите close"
                );

            string operation = Console.ReadLine().DeleteSpaces();

            while(operation != close)
            {
                Set<int> result = new Set<int>(UniversalSet);
                switch (operation)
                {
                    case "A&B":
                        result = set1 & set2;
                        break;
                    case "A|B":
                        result = set1 | set2;
                        break;
                    case "!A":
                        result = !set1;
                        break;
                    case "!B":
                        result = !set2;
                        break;
                    case "A/B":
                        result = set1 / set2;
                        break;
                    case "B/A":
                        result = set2 / set1;
                        break;
                    default:
                        Console.WriteLine("Такой операции у меня нет");
                        break;
                }
                result.Print();
                operation = Console.ReadLine().DeleteSpaces();
            }
            return 0;
        }
    }
}
