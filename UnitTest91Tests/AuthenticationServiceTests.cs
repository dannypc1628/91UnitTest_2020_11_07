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
        private IProfile _stubProfile;
        private IToken _stubToken;
        private AuthenticationService _target;

        [TestInitialize]
        public void SetUp()
        {
            _stubProfile = Substitute.For<IProfile>();
            _stubToken = Substitute.For<IToken>();
            _target = new AuthenticationService(_stubProfile, _stubToken);

        }
        [TestMethod()]
        public void Given_joey_actual_password()
        {
            GivenPassword("joey","91");
            GivenToken("000000");

            ShouldBeValid("joey", "91000000");
        }

        [TestMethod()]
        public void Given_joey_wrong_password()
        {
            GivenPassword("joey", "91");
            GivenToken("000000");

            ShouldBeInvalid("joey", "wrongPassword91000000");
        }

        private void ShouldBeValid(string account,string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsTrue(actual);
        }
        private void ShouldBeInvalid(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsFalse(actual);
        }

        private void GivenToken(string token)
        {
            _stubToken.GetRandom("").ReturnsForAnyArgs(token);
        }

        private void GivenPassword(string account, string password)
        {
            _stubProfile.GetPassword(account).Returns(password);
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