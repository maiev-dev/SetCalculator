using System;
using System.Collections.Generic;

namespace SetCalculator { 
    public class Set<T>
    {
        public List<T> setMembers { get; private set; }
        private List<T> universalSetMembers;
        public List<bool> describeVector { get; private set; }
    
        public Set(List<T> universalSetMembers = null,params T[]  members)
	    {
            setMembers = new List<T>();
            this.universalSetMembers = universalSetMembers;
            foreach (var member in members)
            {
                this.Push(member);
            }
            InitializeDeskribeVector();
	    }

        public static Set<T> FromDescribeVector(List<bool> describeVector, List<T> universalSetMembers)
        {
            List<T> members = new List<T>();

            for (int i = 0; i < describeVector.Count; ++i)
            {
                if (describeVector[i])
                {
                    members.Add(universalSetMembers[i]);
                }
            }
            return new Set<T>(universalSetMembers, members.ToArray());
        }

        public void Push(T value)
        {
            if (!setMembers.Contains(value) && universalSetMembers.Contains(value))
            {
                setMembers.Add(value);
            }
            else
            {
                throw new ArgumentException("Такой элемент уже есть во множестве или он не содержится в универсальном множестве, проверьте ввод");
            }
        }

        public void Print()
        {
            for(int i = 0; i < describeVector.Count; ++i)
            {
                if (describeVector[i])
                {
                    Console.Write(universalSetMembers[i] + " ");
                }
            }
            Console.Write("\n");
        }

        public void PrintDescribeVector()
        {
            foreach (var element in describeVector)
            {
                if (element)
                    Console.Write(1 + " ");
                else
                    Console.Write(0 + " ");
            }
            Console.Write("\n");
        }

        private void InitializeDeskribeVector()
        {
            this.describeVector = new List<bool>(universalSetMembers.Count);
            foreach (var _ in universalSetMembers) describeVector.Add(false);
            foreach (var member in setMembers)
            {
                for (int i = 0; i < universalSetMembers.Count; i++)
                {
                    if ((dynamic)universalSetMembers[i] == (dynamic)member) describeVector[i] = true;
                }
            }
        }

        public static Set<T> operator& (Set<T> leftOperand, Set<T> rightOperand)
        {
            List<bool> resultDescribeVector = new List<bool>();
            for (int i = 0; i < leftOperand.describeVector.Count; ++i)
            {
                resultDescribeVector.Add(leftOperand.describeVector[i] && rightOperand.describeVector[i]);
            }
            return Set<T>.FromDescribeVector(resultDescribeVector, leftOperand.universalSetMembers);
        }

        public static Set<T> operator| (Set<T> leftOperand, Set<T> rightOperand)
        {
            List<bool> resultDescribeVector = new List<bool>();
            for (int i = 0; i < leftOperand.describeVector.Count; ++i)
            {
                resultDescribeVector.Add(leftOperand.describeVector[i] || rightOperand.describeVector[i]);
            }
            return Set<T>.FromDescribeVector(resultDescribeVector, leftOperand.universalSetMembers);
        }

        public static Set<T> operator !(Set<T> operand)
        {
            List<bool> resultDescribeVector = new List<bool>();
            for (int i = 0; i < operand.describeVector.Count; ++i)
            {
                resultDescribeVector.Add(!operand.describeVector[i]);
            }
            return Set<T>.FromDescribeVector(resultDescribeVector, operand.universalSetMembers);
        }

    }
}