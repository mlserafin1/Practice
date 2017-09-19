using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if(aSmile && bSmile)
            {
                return true;
            }
            else if(aSmile == false && bSmile == false)
            {
                return true;
            }
            return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday)
            {
                return false;
            }
            if (isVacation)
            {
                return true;
            }
            if(!isWeekday && !isVacation)
            {
                return true;
            }
            return false;
        }

        public int SumDouble(int a, int b)
        {
            int sum;
            if (a == b)
            {
                sum = 2 * (a + b);
                return sum;
            }
            sum = a + b;
            return sum;
            
        }
        
        public int Diff21(int n)
        {
            int check = Math.Abs(21 - n);
            if (n > 21)
            {
                check *= 2;
            }
            return check;
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if(hour < 7 || hour > 20)
            {
                if (isTalking)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        
        public bool Makes10(int a, int b)
        {
            int sum = a + b;
            if(a == 10 || b == 10)
            {
                return true;
            }
            if (sum == 10)
            {
                return true;
            }
            return false;
        }
        
        public bool NearHundred(int n)
        {
            int diff = Math.Abs(100 -n);
            if (diff <= 10)
            {
                return true;
            }
            return false;
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            if (!negative)
            {
                if (a < 0 && b > 0)
                {
                    return true;
                }
                if (a > 0 && b < 0)
                {
                    return true;
                }
            }
            if (negative)
            {
                if (a < 0 && b < 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        public string NotString(string s)
        {
            if (s.Length < 3)
            {
                return string.Format("not {0}", s);
            }
            string temp = s.Substring(0, 3);
            if (temp == "not")
            {
                return string.Format("{0}", s);
            }
            return string.Format("not {0}", s);
        }
        
        public string MissingChar(string str, int n)
        {
            if (n == 0)
            {
                return string.Format("{0}", str.Substring(1));
            }
            if (n == str.Length - 1)
            {
                return string.Format("{0}", str.Substring(0, str.Length-5));
            }
            string start = str.Substring(0, n);
            string end = str.Substring(n + 1);
            return string.Format("{0}{1}", start, end);
        }
        
        public string FrontBack(string str)
        {
            if(str.Length == 1)
            {
                return string.Format("{0}", str);
            }
            if(str.Length == 2)
            {
                return string.Format("{0}{1}", str.Substring(str.Length - 1), str.Substring(0, 1));
            }
            return string.Format("{0}{1}{2}", str.Substring(str.Length - 1), str.Substring(1, str.Length - 2), str.Substring(0, 1));
        }
        
        public string Front3(string str)
        {
            if (str.Length < 3)
            {
                return string.Format("{0}{0}{0}", str);
            }
            return string.Format("{0}{0}{0}", str.Substring(0, 3));
        }
        
        public string BackAround(string str)
        {
            return string.Format("{0}{1}{0}", str.Substring(str.Length - 1), str);
        }
        
        public bool Multiple3or5(int number)
        {
            if(number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            return false;
        }
        
        public bool StartHi(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            if (str == "hi")
            {
                return true;
            }
            if (str.Substring(0, 2) == "hi")
            {
                if (str.Substring(2, 1) == "," || str.Substring(2, 1) == " ")
                {
                    return true;
                }
                if (!string.IsNullOrEmpty(str.Substring(2, 1)))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if(temp1 < 0 && temp2 > 100)
            {
                return true;
            }
            if(temp1 > 0 && temp2 < 100)
            {
                return true;
            }
            return false;
        }
        
        public bool Between10and20(int a, int b)
        {
            if ((a > 9 && a < 21) || (b > 9 && b < 21))
            {
                return true;
            }
            return false;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            if((a > 12 && a < 20) || (b > 12 && b < 20) || (b > 12 && b < 20))
            {
                return true;
            }
            return false;
        }
        
        public bool SoAlone(int a, int b)
        {
            if ((a > 12 && a < 20) && (b > 12 && b < 20))
            {
                return false;
            }
            if ((a > 12 && a < 20) || (b > 12 && b < 20))
            {
                return true;
            }
            return false;
        }
        
        public string RemoveDel(string str)
        {
            if(str.Substring(1,3) == "del")
            {
                return string.Format("{0}{1}", str.Substring(0, 1), str.Substring(4));
            }
            return str;
        }
        
        public bool IxStart(string str)
        {
            if(str.Substring(1,2) == "ix")
            {
                return true;
            }
            return false;
        }
        
        public string StartOz(string str)
        {
            if (str.Length < 2 || string.IsNullOrEmpty(str))
            {
                return "";
            }
            if ((str.Substring(0,1) == "o") && (str.Substring(1,1) == "z"))
            {
                return string.Format("{0}{1}", str.Substring(0, 1), str.Substring(1, 1));
            }
            if (str.Substring(0, 1) == "o")
            {
                return string.Format("{0}", str.Substring(0, 1));
            }
            if (str.Substring(1, 1) == "z")
            {
                return string.Format("{0}", str.Substring(1, 1));
            }
            if (str.Substring(0, 1) != "o")
            {
                return "";
            }
            return "";
        }
        
        public int Max(int a, int b, int c)
        {
            int max = a;
            if (b > a)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }
            return max;
        }
        
        public int Closer(int a, int b)
        {
            int diff1 = Math.Abs(10-a);
            int diff2 = Math.Abs(10-b);
            if(diff1 == diff2)
            {
                return 0;
            }
            if (diff1 < diff2)
            {
                return a;
            }
            if (diff1 > diff2)
            {
                return b;
            }
            return 0;
        }
        
        public bool GotE(string str)
        {
            int count = 0;
            for (int i = 0;i < str.Length; i++)
            {
                if(str.Substring(i,1) == "e")
                {
                    count += 1;
                }
            }
            if(count > 0 && count < 4)
            {
                return true;
            }
            return false;
        } 
        
        public string EndUp(string str)
        {

            if(str.Length < 3)
            {
                return string.Format("{0}", str.ToUpper());
            }
            return string.Format("{0}{1}",str.Substring(0,str.Length-3) ,str.Substring(str.Length - 3).ToUpper());
        }
        
        public string EveryNth(string str, int n)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            string temp = null;
            for(int i = 0;i < str.Length; i+=n)
            {
                temp = temp + str.Substring(i, 1);
            }
            return string.Format("{0}", temp);
        }
    }
}
