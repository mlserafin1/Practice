using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if(numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if(numbers.Length >= 1)
            {
                if (numbers[0] == numbers[numbers.Length-1])
                {
                    return true;
                }
            }
            return false;
        }
        public int[] MakePi(int n)
        {

            double temp = Math.PI;
            string holder = temp.ToString();
            holder = holder.Remove(1,1);
            int[] temp2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                temp2[i] = int.Parse(holder.Substring(i, 1));
            }
            return temp2;

        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
            {
                return true;
            }
            return false;
        }
        
        public int Sum(int[] numbers)
        {
            int sum = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public int[] RotateLeft(int[] numbers)
        {
            int[] temp = new int[numbers.Length];
            for(int i = numbers.Length-1; i > 0; i--)
            {
                temp[i - 1] = numbers[i];
            }
            temp[numbers.Length - 1] = numbers[0];
            return temp;
        }
        
        public int[] Reverse(int[] numbers)
        {
            if(numbers.Length % 2 == 0)
            {
                int count = numbers.Length-1;
                for(int i = 0;i < ((numbers.Length / 2)); i++)
                {
                    int temp = numbers[count];
                    numbers[count] = numbers[i];
                    numbers[i] = temp;
                    count--;

                }
                return numbers;
            }
            for (int i = 0; i < ((numbers.Length - 1)/2); i++)
            {
                int temp = numbers[numbers.Length - 1];
                numbers[numbers.Length - 1] = numbers[i];
                numbers[i] = temp;
            }
            return numbers;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            if (numbers[0] > numbers[numbers.Length - 1])
            {
                for(int i=1;i < numbers.Length; i++)
                {
                    numbers[i] = numbers[0];
                }
                return numbers;
            }
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                numbers[i] = numbers[numbers.Length - 1];
            }
            return numbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] temp = new int[2];
            temp[0] = a[1];
            temp[1] = b[1];
            return temp;
        }
        
        public bool HasEven(int[] numbers)
        {
            bool test = false;
            for(int i = 0;i < numbers.Length; i++)
            {
                if(numbers[i]%2 == 0)
                {
                    test = true;
                }
            }
            return test;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] dub = new int[numbers.Length*2];
            dub[dub.Length - 1] = numbers[numbers.Length - 1];
            return dub;
        }
        
        public bool Double23(int[] numbers)
        {
            int count2 = 0;
            int count3 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == 2)
                {
                    count2 += 1;
                }
                if(numbers[i] == 3)
                {
                    count3 += 1;
                }
            }
            if(count2 == 2 || count3 == 2)
            {
                return true;
            }
            return false;
        }
        
        public int[] Fix23(int[] numbers)
        {
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                if(numbers[i] == 2 && numbers[i+1] == 3)
                {
                    numbers[i + 1] = 0;
                }
            }
            return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            for (int i = 0; i < 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 3)
                {
                    return true;
                }
            }
            return false;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] knew = new int[2];
            if (a.Length >= 2)
            {
                knew[0] = a[0];
                knew[1] = a[1];
            }
            if (a.Length == 1)
            {
                knew[0] = a[0];
                knew[1] = b[0];
            }
            if (a.Length == 0)
            {
                knew[0] = b[0];
                knew[1] = b[1];
            }
            return knew;
        }

    }
}
