using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest91;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest91.Tests
{
    [TestClass()]
    public class HolidayTests
    {
        private HolidayTest _holiday;

        [TestInitialize]
        public void SetUp()
        {
            _holiday = new HolidayTest();
        }
        [TestMethod()]
        public void SayHello_Xms_Yes_Test()
        {
            SetToday(12, 25);
            ResponseShouldBe("Merry Xmas");
        }

        [TestMethod()]
        public void SayHello_Xms_No_Test()
        {
            SetToday(11, 11);
            ResponseShouldBe("Today is not Xmas");

        }

        private void SetToday(int month, int day)
        {
            _holiday._toDay = new DateTime(2020,month,day);
        }

        private void ResponseShouldBe(string expected)
        {
            Assert.AreEqual(expected, _holiday.SayHello());
        }
    }

    class HolidayTest : Holiday
    {
        public DateTime _toDay;
        protected override DateTime GetToday()
        {
            return _toDay;
        }
    }
}