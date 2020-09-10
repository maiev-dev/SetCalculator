using System;
using System.Collections.Generic;

namespace SetCalculator { 
    public class Set<T> where T: IComparable
    {
        public List<T> setMembers { get; private set; }
        private readonly List<T> universalSetMembers;
        public List<bool> describeVector { get; private set; }
        private delegate bool op (bool leftOperand, bool rightOperand);
    
        public Set(List<T> universalSetMembers,params T[]  members)
	    {
            setMembers = new List<T>();
            this.universalSetMembers = universalSetMembers;
            this.describeVector = new List<bool>(universalSetMembers.Count);
            foreach (var _ in universalSetMembers) describeVector.Add(false);
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
                for (int i = 0; i < universalSetMembers.Count; ++i)
                {
                    if ((universalSetMembers[i] as IComparable).Equals(value))
                    {
                        describeVector[i] = true;
                    }
                }
            }
            else
            {
                if (setMembers.Contains(value)) throw new ArgumentException("Такой элемент уже есть во множестве, проверьте ввод");
                else throw new ArgumentException("Такой элемент не содержится в универсальном множестве, проверьте ввод");
            }
        }

        public static Set<T> operator &(Set<T> leftOperand, Set<T> rightOperand)
        {
            return binaryOperation(leftOperand, rightOperand, (bool left, bool right) =>
            {
                return left && right;
            }
            );
        }

        public static Set<T> operator |(Set<T> leftOperand, Set<T> rightOperand)
        {
            return binaryOperation(leftOperand, rightOperand, (bool left, bool right) =>
            {
                return left || right;
            }
            );
        }

        public static Set<T> operator /(Set<T> leftOperand, Set<T> rightOperand)
        {
            return binaryOperation(leftOperand, rightOperand, (bool left, bool right) =>
            {
                return left && (!right);
            }
            );
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

        public static bool operator== (Set<T> leftOperand, Set<T> rightOperand)
        {
            if (leftOperand.describeVector.Count != rightOperand.describeVector.Count) return false;
            for (int i = 0; i < leftOperand.describeVector.Count; ++i)
            {
                if ((leftOperand.describeVector[i] != rightOperand.describeVector[i])) return false;
            }
            return true;
        }

        public static bool operator!=(Set<T> leftOperand, Set<T> rightOperand)
        {
            return !(leftOperand == rightOperand);
        } 

        public bool IsSubset(Set<T> rightOperand)
        {
            return this == (this & rightOperand);
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
            foreach (var member in setMembers)
            { 
                for (int i = 0; i < universalSetMembers.Count; i++)
                {
                    
                    if ((universalSetMembers[i] as IComparable).Equals(member))
                    {
                        describeVector[i] = true;
                    }
                    
                }
                
            }
        }
        
        private static Set<T> binaryOperation(Set<T> leftOperand, Set<T> rightOperand, op Operation = null)
        {
            if (!leftOperand.universalSetMembers.Equals(rightOperand.universalSetMembers))
            {
                throw new ArgumentException("Множества принадлежат разным универсальным множествам");
            }
            List<bool> resultDescribeVector = new List<bool>();
            for (int i = 0; i < leftOperand.describeVector.Count; ++i)
            {
                resultDescribeVector.Add((bool)Operation?.Invoke(leftOperand.describeVector[i], rightOperand.describeVector[i]));
            }
            return Set<T>.FromDescribeVector(resultDescribeVector, leftOperand.universalSetMembers);
        }

        public override bool Equals(object obj)
        {
            return obj is Set<T> set &&
                   EqualityComparer<List<T>>.Default.Equals(setMembers, set.setMembers) &&
                   EqualityComparer<List<T>>.Default.Equals(universalSetMembers, set.universalSetMembers) &&
                   EqualityComparer<List<bool>>.Default.Equals(describeVector, set.describeVector);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(setMembers, universalSetMembers, describeVector);
        }
    }
}