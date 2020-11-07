using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest91;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest91.Tests
{
    [TestClass()]
    public class HoliidayTests
    {
        [TestMethod()]
        public void SayHello_Xms_Yes_Test()
        {
            var expect = "Merry Xmas";
            var holiday = new HoliidayTest(){ _toDay = DateTime.Now};
            var actual = holiday.SayHello();

            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void SayHello_Xms_No_Test()
        {
            var expect = "Today is not Xmas";
            var holiday = new HoliidayTest() { _toDay = DateTime.Now };
            var actual = holiday.SayHello();

            Assert.AreEqual(expect, actual);
        }
    }

    class HoliidayTest : Holiiday
    {
        public DateTime _toDay;
        protected override DateTime GetToday()
        {
            return _toDay;
        }
    }
}