using System;

namespace Warmups.BLL
{
    public class Strings
    {
        /// <summary>
        /// Returns the inputted name + hello.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string SayHi(string name)
        {
            return string.Format("Hello {0}!", name);
        }

        public string Abba(string a, string b)
        {
            return ($"{a}{b}{b}{a}");
        }

        public string MakeTags(string tag, string content)
        {
            return string.Format("<{0}>{1}</{0}>", tag, content);
        }

        public string InsertWord(string container, string word) {
            string s1 = container.Substring(0, 2);
            string s2 = container.Substring(2, 2);
            return ($"{s1}{word}{s2}");
        }

        public string MultipleEndings(string str)
        {
            string temp = str.Substring(str.Length - 2);
            return temp + temp + temp;
        }

        public string FirstHalf(string str)
        {
            string temp = str.Substring(0, str.Length / 2);
            return temp;
        }

        public string TrimOne(string str)
        {
            string temp = str.Substring(1, str.Length - 2);
            return temp;
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return string.Format("{0}{1}{0}",b,a);
            }
            else
            {
                return string.Format("{0}{1}{0}",a,b);
            }
        }

        public string RotateLeft2(string str)
        {
            string temp = str.Substring(0, 2);
            string temp1 = str.Substring(2, str.Length - 2);
            return string.Format("{0}{1}",temp1,temp);
        }

        public string RotateRight2(string str)
        {
            string temp = str.Substring(str.Length - 2, 2);
            string temp1 = str.Substring(0, str.Length - 2);
            return string.Format("{0}{1}",temp,temp1);
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                string temp = str.Substring(0, 1);
                return temp;
            }
            else
            {
                string temp = str.Substring(str.Length - 1, 1);
                return temp;
            }
        }

        public string MiddleTwo(string str)
        {
            string temp = str.Substring((str.Length / 2) - 1, 2);
            return temp;
        }

        public bool EndsWithLy(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            string temp = str.Substring(str.Length - 2, 2);
            if (temp == "ly")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FrontAndBack(string str, int n)
        {
            string temp = str.Substring(0, n);
            string temp1 = str.Substring(str.Length - n, n);
            return string.Format("{0}{1}",temp,temp1);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n >= str.Length - 1)
            {
                return str.Substring(0, 2);
            }
            else
            {
                return str.Substring(n, 2);
            }
        }

        public bool HasBad(string str)
        {

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            string temp = str.Substring(0, 3);
            string temp1 = str.Substring(1, 3);
            if (temp == "bad" || temp1 == "bad")
            {
                return true;
            }
            return false;
        }

        public string AtFirst(string str)
        {
            if (str.Length >= 2)
            {
                return str.Substring(0, 2);
            }
            else if (str.Length < 2)
            {
                if (str.Length == 1)
                {
                    return string.Format("{0}@",str);
                }
                else
                {
                    return "@@";
                }
            }
            return str;
        }

        public string LastChars(string a, string b)
        {
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
            {
                return "@@";
            }
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                if (string.IsNullOrEmpty(a))
                {
                    return string.Format("@{0}",b.Substring(b.Length - 1, 1));
                }
                if (string.IsNullOrEmpty(b))
                {
                    return string.Format("{0}@",a.Substring(0, 1));
                }
            }
            return string.Format("{0}{1}",a.Substring(0, 1),b.Substring(b.Length - 1, 1));
        }
   

        public string ConCat(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
            {
                return b;
            }
            if (string.IsNullOrEmpty(b))
            {
                return a;
            }
            string temp1 = a.Substring(a.Length - 1, 1);
            string temp2 = b.Substring(0, 1);
            if(temp1 == temp2)
            {
                if (string.IsNullOrEmpty(temp1))
                {
                    return b;
                }
                if (string.IsNullOrEmpty(temp2))
                {
                    return a;
                }
                return string.Format("{0}{1}", a.Substring(0), b.Substring(1));
            }
            return string.Format("{0}{1}", a.Substring(0), b.Substring(0));
        }

        public string SwapLast(string str)
        {
            if(str.Length <= 1)
            {
                return str;
            }
            string last = str.Substring(str.Length - 1, 1);
            string secondlast = str.Substring(str.Length - 2, 1);
            string root = str.Substring(0, str.Length - 2);
            return string.Format("{0}{1}{2}",root,last,secondlast);
        }

        public bool FrontAgain(string str)
        {
            string firsttwo = str.Substring(0, 2);
            string lasttwo = str.Substring(str.Length - 2, 2);
            if(firsttwo == lasttwo)
            {
                return true;
            }
            return false;
        }

        public string MinCat(string a, string b)
        {
            if(a.Length == b.Length)
            {
                return string.Format("{0}{1}", a, b);
            }
            if (a.Length > b.Length)
            {
                string temp1 = a.Substring(a.Length - b.Length);
                return string.Format("{0}{1}", temp1, b);
            }
            string temp2 = b.Substring(b.Length - a.Length);
            return string.Format("{0}{1}", a, temp2);
        }

        public string TweakFront(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            string tempa = str.Substring(0, 1);
            string tempb = str.Substring(1, 1);
            string tempend = str.Substring(2);
            if (tempa == "a" && tempb == "b")
            {
                return str;
            }
            if (tempa == "a")
            {
                return string.Format("{0}{1}", tempa, tempend);
            }
            if (tempb == "b")
            {
                return string.Format("{0}{1}", tempb, tempend);
            }
            return string.Format("{0}", tempend);
        }

        public string StripX(string str)
        {
            
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            if (str.Length == 1 && str == "x")
            {
                return "";
            }
            if (str.Substring(0,1) == "x" && str.Substring(str.Length-1) == "x")
            {
                return str.Substring(1, str.Length - 2);
            }
            if (str.Substring(0, 1) == "x")
            {
                return string.Format("{0}", str.Substring(1));
            }
            if (str.Substring(str.Length - 1) == "x")
            {
                return string.Format("{0}",str.Substring(0, str.Length - 1));
            }
                return str;
        }
    }
}
