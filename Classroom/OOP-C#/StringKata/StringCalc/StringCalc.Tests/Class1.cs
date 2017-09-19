using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StringCalc;

namespace StringCalc.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void EmptyZero()
        {
            
            StringCalc calc = new StringCalc();
            
            int actual = calc.Add("");
            Assert.AreEqual(0, actual);

        }

        [Test]
        public void OneNumberIsNumber()
        {
            StringCalc calc = new StringCalc();

            int actual = calc.Add("7");
            Assert.AreEqual(7, actual);
        }
    }
}
