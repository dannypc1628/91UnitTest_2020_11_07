using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTest91;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;

namespace UnitTest91.Tests
{
    [TestClass()]
    public class AuthenticationServiceTests
    {
        [TestMethod()]
        public void AuthenticationServiceTest()
        {
            var stubProfile = Substitute.For<IProfile>();
            stubProfile.GetPassword("joey").Returns("91");
            var stubToken = Substitute.For<IToken>();
            stubToken.GetRandom("").ReturnsForAnyArgs("000000");

            var target = new AuthenticationService(stubProfile, stubToken);
            var actual = target.IsValid("joey", "91000000");
            Assert.IsTrue(actual);
        }

        //internal class FakeProfile : IProfile
        //{
        //    public string GetPassword(string account)
        //    {
        //        if (account == "joey")
        //        {
        //            return "91";
        //        }

        //        return "";
        //    }
        //}

        //internal class FakeToken : IToken
        //{
        //    public string GetRandom(string account)
        //    {
        //        return "000000";
        //    }
        //}
    }
}