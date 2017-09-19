using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (isWeekend)
            {
                if (cigars > 39)
                {
                    return true;
                }
            }
            if (!isWeekend)
            {
                if (cigars > 39 && cigars < 61)
                {
                    return true;
                }
            }
            return false;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }
            if (yourStyle >= 8 || dateStyle >= 8)
            {
                return 2;
            }
            return 1;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (isSummer)
            {
                if (temp > 59 && temp < 101)
                {
                    return true;
                }
                return false;
            }
            if (temp > 59 && temp < 91)
            {
                return true;
            }
            return false;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (isBirthday)
            {
                if (speed < 66)
                {
                    return 0;
                }
                if (speed > 65 && speed < 86)
                {
                    return 1;
                }
                return 2;
            }
            if (speed < 61)
            {
                return 0;
            }
            if (speed > 60 && speed < 81)
            {
                return 1;
            }
            return 2;
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if (sum > 9 && sum < 20)
            {
                return 20;
            }
            return sum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            if (vacation)
            {
                if (day > 0 && day < 6)
                {
                    return "10:00";
                }
                if (day == 0 || day == 6)
                {
                    return "off";
                }
            }
            if (day > 0 && day < 6)
            {
                return "7:00";
            }
            return "10:00";
        }
        
        public bool LoveSix(int a, int b)
        {
            int sum = a + b;
            int diff = Math.Abs(a - b);
            if (a == 6 || b == 6)
            {
                return true;
            }
            if (sum == 6)
            {
                return true;
            }
            if (diff == 6)
            {
                return true;
            }
            return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode)
            {
                if (n <= 1 || n >= 10)
                {
                    return true;
                }
            }
            if (n > 0 && n < 11)
            {
                return true;
            }
            return false;
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0)
            {
                return true;
            }
            if ((n - 1) % 11 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool Mod20(int n)
        {
            if ((n - 1) % 20 == 0)
            {
                return true;
            }
            if ((n - 2) % 20 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 == 0)
            {
                return false;
            }
            if (n % 3 == 0)
            {
                return true;
            }
            if (n % 5 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep)
            {
                return false;
            }
            if (isMorning)
            {
                if (isMom)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c)
            {
                return true;
            }
            if (b + c == a)
            {
                return true;
            }
            if (a + c == b)
            {
                return true;
            }
            return false;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (bOk)
            {
                if (c > b)
                {
                    return true;
                }
            }
            if (b > a && c > b)
            {
                return true;
            }
            return false;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk)
            {
                if (a == b && c > a)
                {
                    return true;
                }
                if (b == c && b > a)
                {
                    return true;
                }
                if (a == b && b == c)
                {
                    return true;
                }
            }
            if (b > a && c > b)
            {
                return true;
            }
            return false;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            string first = a.ToString();
            string second = b.ToString();
            string third = c.ToString();
            if (first.Length > 1 && second.Length > 1 && third.Length > 1)
            {
                if (first.Substring(first.Length-1) == second.Substring(second.Length-1))
                {
                    return true;
                }
                if (first.Substring(first.Length - 1) == third.Substring(third.Length-1))
                {
                    return true;
                }
                if (second.Substring(second.Length - 1) == third.Substring(third.Length-1))
                {
                    return true;
                }
            }
            if (first.Length == 1)
            {
                if (first.Substring(0) == second.Substring(second.Length - 1))
                {
                    return true;
                }
                if (first.Substring(0) == third.Substring(third.Length - 1))
                {
                    return true;
                }
            }
            if (second.Length == 1)
            {
                if (second.Substring(0) == first.Substring(first.Length - 1))
                {
                    return true;
                }
                if (second.Substring(0) == third.Substring(third.Length - 1))
                {
                    return true;
                }
            }
            if (third.Length == 1)
            {
                if (third.Substring(0) == second.Substring(second.Length - 1))
                {
                    return true;
                }
                if (third.Substring(0) == first.Substring(first.Length - 1))
                {
                    return true;
                }
            }
            return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum;
            if (noDoubles)
            {
                if (die1 == die2)
                {
                    if (die1 == 6)
                    {
                        sum = 1 + die2;
                        return sum;
                    }
                    die1 += 1;
                    sum = die1 + die2;
                    return sum;
                }
                sum = die1 + die2;
                return sum;
            }
            sum = die1 + die2;
            return sum;
        }

    }
}
