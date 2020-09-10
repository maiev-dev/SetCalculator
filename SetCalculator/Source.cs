using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SetCalculator
{
    partial class SetCalculator
    {
        
        private const string endOfInput = "eof";
        private const string close = "close";
        public static int Main()
        {
            Console.Write("Добро пожаловать в калькулятор множеств! \n" +
                            "Текущая версия приложения - 0.9.6 \n" +
                            "Автор - Гурков Денис \n" +
                            "Последняя версия проекта доступна по ссылке - https://github.com/maiev-dev/SetCalculator \n" +
                            "\n");

            Console.WriteLine("Введите члены универсального множества, ввод закончите символом eof");

            List<int> UniversalSet = GetListFromConsole();

            Console.WriteLine("Введите множество A");

            Set<int> setA = GetSetFromConsole(UniversalSet);
            setA.Print();
            setA.PrintDescribeVector();

            Console.WriteLine("Введите множество B");
            Set<int> setB = GetSetFromConsole(UniversalSet);
            setB.Print();
            setB.PrintDescribeVector();

            Console.WriteLine(
                "\n" +
                "Время выполнять операции, доступны следующие операции: \n" +
                "A & B - Пересечение множеств \n" +
                "A | B - Объединение множеств \n" +
                "!A - Дополнение множества A до универсального \n" +
                "A / B - Разность множеств \n" +
                "A C B - A является подмножеством B \n",
                "Когда надоест введите close"
                );

            DoOperations(setA, setB);
            return 0;
        }

    }
}
