using System;
using System.CodeDom.Compiler;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string temp = null;
            for (int i = 0; i < n; i++)
            {
                temp = temp + str;
            }
            return temp;
        }

        public string FrontTimes(string str, int n)
        {
            string temp = null;
            if (str.Length < 3)
            {
                for (int i = 0; i < n; i++)
                {
                    temp = temp + str;
                }
            }
            for (int i = 0; i < n; i++)
            {
                temp = temp + str.Substring(0, 3);
            }
            return temp;
        }

        public int CountXX(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 2) == "xx")
                {
                    count = count + 1;
                }
            }
            return count;
        }

        public bool DoubleX(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 1) == "x")
                {
                    count += 1;
                }
                if (count == 1 && str.Substring(i, 1) == "x" && str.Substring(i + 1, 1) == "x")
                {
                    return true;
                    
                }
            }
            return false;
        }

        public string EveryOther(string str)
        {
            string temp = null;
            for (int i = 0; i < str.Length; i += 2)
            {
                temp = temp + str.Substring(i, 1);
            }
            return temp;
        }

        public string StringSplosion(string str)
        {
            string temp = null;
            for (int i = 1; i < str.Length+1; i++)
            {
                temp = temp + str.Substring(0, i);
            }
            return temp;
        }

        public int CountLast2(string str)
        {
            int count = 0;
            string temp = str.Substring(str.Length - 2, 2);
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str.Substring(i, 2) == temp)
                {
                    count++;
                }
            }
            return count;
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] numbers)
        {
            if (numbers.Length < 4)
            {
                for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] == 9)
                        {
                            return true;
                        }
                    }
                return false;
            }
            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] == 9)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int count = 0;
            for (int i = 0; i < a.Length-1; i++)
            {
                for (int j = 0; j < b.Length-1; j++)
                {
                    if (a.Substring(i, 2) == b.Substring(j, 2))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public string StringX(string str)
        {
            string temp = null;
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, 1) != "x")
                {
                    temp = temp + str.Substring(i, 1);
                }
            }
            if (str.Substring(0, 1) == "x")
            {
                temp = "x" + temp;
            }
            if (str.Substring(str.Length - 1, 1) == "x")
            {
                temp = temp + "x";
            }
            return temp;
        }

        public string AltPairs(string str)
        {
            string temp = null;
            int count = 1;
            for (int i =0; i < str.Length; i+=4)
                {
                    if (!string.IsNullOrEmpty(str.Substring(i, 1)))
                    {
                        temp = temp + str.Substring(i, 1);
                    }
                    if (count<str.Length)
                    {
                        temp = temp + str.Substring(count, 1);
                        count += 4;
                    }
                }
            return temp;
        }

        public string DoNotYak(string str)
        {
            string temp = null;
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str.Substring(i, 1) == "y" && str.Substring(i + 2, 1) == "k")
                {
                    temp = temp + str.Remove(i, 3);
                }
            }
            return temp;
        }

        public int Array667(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6)
                {
                    if (numbers[i + 1] == 6 || numbers[i + 1] == 7)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public bool NoTriples(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i + 1] == numbers[i + 2])
                {
                    return false;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] + 5 == numbers[i + 1] && numbers[i] - 1 == numbers[i + 2])
                {
                    return true;
                }
            }
            return false;
        }

    }
}
