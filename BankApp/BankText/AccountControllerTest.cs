using BankUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankText
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void TestIndexViewWithNoLogin()
        {
            //AAA- Arrange,Act,Assert
            //Arrange
            var controller = new AccountController();
            //Act and Assert
            Assert.ThrowsException<NullReferenceException>(() => controller.Index());
        }
    }
}
