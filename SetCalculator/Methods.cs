using System;
using System.Collections.Generic;
using System.Text;

namespace SetCalculator
{
    public partial class SetCalculator
    {
        private static void DoOperations(Set<int> set1, Set<int> set2)
        {
            string operation = Console.ReadLine().DeleteSpaces().CorrectCommutativeOperations();

            while (operation != close)
            {

                if (operation == "ACB" || operation == "BCA")
                {
                    bool result = DoLogicOperation(set1, set2, operation);
                    Console.WriteLine(result);
                    operation = Console.ReadLine().DeleteSpaces().CorrectCommutativeOperations();
                }
                else
                {
                    try
                    {
                        var result = DoSetOperation(set1, set2, operation);
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
                        operation = Console.ReadLine().DeleteSpaces().CorrectCommutativeOperations();
                    }
                }

            }
        }
        private static bool DoLogicOperation(Set<int> set1, Set<int> set2, string operation)
        {
            bool result;
            if (operation == "ACB") result = set1.IsSubset(set2);
            else result = set2.IsSubset(set1);
            return result;
        }

        private static Set<int> DoSetOperation(Set<int> leftOperator, Set<int> rightOperator, string operation)
        {
            Set<int> result = operation switch
            {
                "A&B" => leftOperator & rightOperator,
                "A|B" => leftOperator | rightOperator,
                "!A" => !leftOperator,
                "!B" => !rightOperator,
                "A/B" => leftOperator / rightOperator,
                "B/A" => rightOperator / leftOperator,
                _ => throw new ArgumentException("У меня нет такой операции")
            };
            return result;
        }
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
                catch (FormatException)
                {
                    Console.WriteLine("Входная строка имела неверный формат");
                }
                candidate = Console.ReadLine();
            }
            return set;
        }
        private static List<int> GetListFromConsole()
        {
            List<int> result = new List<int>();
            string candidate = Console.ReadLine();
            while (candidate != endOfInput)
            {
                int i_candidate = Convert.ToInt32(candidate);
                if (!result.Contains(i_candidate))
                {
                    result.Add(i_candidate);
                }
                else
                {
                    Console.WriteLine("Такой элемент уже содержится во множестве, повторите ввод");
                }
                candidate = Console.ReadLine();
            }
            return result;
        }
    }
}
