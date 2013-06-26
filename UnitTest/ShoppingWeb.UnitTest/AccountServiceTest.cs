using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ShoppingWeb.Infrastructure;
using ShoppingWeb.Models;
using ShoppingWeb.UnitTest.TestClasses;

namespace ShoppingWeb.UnitTest
{
    [TestFixture]
    public class AccountServiceTest
    {
        [Test]
        [TestCaseSource("GenerateVerifyUserTestCases")]
        public void TestVerifyUser(string message, LoginModel loginModel, bool expected)
        {
            var service = new AccountService
                {
                    UserRepository = new FakeUserRepository()
                };

            
            var result = service.VerifyUser(loginModel);
            
            Assert.AreEqual(expected, result);
            
        }

        public void TestAddNewUser()
        {
            
        }

        private static IEnumerable<object[]> GenerateVerifyUserTestCases()
        {
            return new[]
                {
                    new object[] {"Empty Name, Empty Pass", new LoginModel {UserName = "", Password = ""}, false},
                    new object[] {"Null Name, Null Pass", new LoginModel {UserName = null, Password = null}, false},
                    new object[] {"Empty Name, Null Pass", new LoginModel {UserName = "", Password = null}, false},
                    new object[] {"Null Name, Empty Pass", new LoginModel {UserName = null, Password = ""}, false},
                    new object[] {"Valid Name, Valid Pass", new LoginModel {UserName = "Quang", Password = "password"}, true},
                    new object[] {"Valid Name, Null Pass", new LoginModel {UserName = "Khoa", Password = null}, false},
                    new object[] {"Valid Name, Empty Pass", new LoginModel {UserName = "Tham", Password = ""}, false},
                    new object[] {"Empty Name, Valid Pass", new LoginModel {UserName = "", Password = "password"}, false},
                    new object[] {"Null Name, Valid Pass", new LoginModel {UserName = null, Password = "password"}, false},
                    new object[] {"Wrong Name, Wrong Pass", new LoginModel {UserName = "Wrong", Password = "Wrong"}, false},
                    new object[] {"Wrong Name, Null Pass", new LoginModel {UserName = "Wrong", Password = null}, false},
                    new object[] {"Wrong Name, Empty Pass", new LoginModel {UserName = "Wrong", Password = ""}, false},
                    new object[] {"Null Name, Wrong Pass", new LoginModel {UserName = null, Password = "Wrong"}, false},
                    new object[] {"Empty Name, Wrong Pass", new LoginModel {UserName = "", Password = "Wrong"}, false},
                    new object[] {"Wrong Name, Valid Pass", new LoginModel {UserName = "Wrong", Password = "password"}, false},
                    new object[] {"Valid Name, Wrong Pass", new LoginModel {UserName = "Quang", Password = "Wrong"}, false}
                };
        }
    }
}
