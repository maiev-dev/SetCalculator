using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SetCalculator
{
   
   
    class SetCalculator
    {
        
        private const string endOfInput = "eof";
        private const string close = "close";
        private static Set<int> GetSetFromConsole(List<int> UniversalSet)
        {
            Set<int> set = new Set<int>(UniversalSet);
            string candidate = Console.ReadLine();
            while (candidate != endOfInput)
            {
                int i_candidate;
                try
                {
                    i_candidate = Convert.ToInt32(candidate);
                    try
                    {
                        set.Push(i_candidate);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Входная строка имела неверный формат");
                }
                candidate = Console.ReadLine();
            }
            return set;
        }
        public static int Main()
        {
          
            Console.Write("Добро пожаловать в калькулятор множеств! \n" +
                            "Текущая версия приложения - 0.9.4 \n" +
                            "Автор - Гурков Денис \n" +
                            "Последняя версия проекта доступна по ссылке - https://github.com/maiev-dev/SetCalculator \n"+
                            "\n");

            Console.WriteLine("Введите члены универсального множества, ввод закончите символом eof");

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
          
            Console.WriteLine("Введите множество A");

            Set<int> set1 = GetSetFromConsole(UniversalSet);
            set1.Print();
            set1.PrintDescribeVector();
            
            Console.WriteLine("Введите множество B");
            Set<int> set2 = GetSetFromConsole(UniversalSet);
            set2.Print();
            set2.PrintDescribeVector();

            Console.WriteLine(
                "Время выполнять операции, доступны следующие операции: \n" +
                "A & B - Пересечение множеств \n" + 
                "A | B - Объединение множеств \n" +
                "!A - Дополнение множества A до универсального \n" +
                "A / B - Разность множеств \n" + 
                "A C B - A является подмножеством B \n", 
                "Когда надоест введите close"
                );

            string operation = Console.ReadLine().DeleteSpaces();
            
            while(operation != close)
            {
                if (operation == "B&A") operation = "A&B";
                if (operation == "B|A") operation = "A|B"; 
                if (operation == "ACB" || operation == "BCA")
                {
                    bool result;
                    if (operation == "ACB") result = set1.IsSubset(set2);
                    else result = set2.IsSubset(set1);
                    Console.WriteLine(result);
                    operation = Console.ReadLine().DeleteSpaces();
                }
                else
                {
                    try { 
                        var result = operation switch
                        {
                            "A&B" => set1 & set2,
                            "A|B" => set1 | set2,
                            "!A" => !set1,
                            "!B" => !set2,
                            "A/B" => set1 / set2,
                            "B/A" => set2 / set1,
                            _ => throw new ArgumentException("У меня нет такой операции")
                        };
                        result.Print();
                        result.PrintDescribeVector();
                        Console.Write("\n");
                    }

                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    finally
                    {
                        operation = Console.ReadLine().DeleteSpaces();
                    }
                }
                
            }
            return 0;
        }
    }
}
