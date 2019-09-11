using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Web.Controllers;
using System.Web.Mvc;

namespace Test
{
    /// <summary>
    /// Summary description for UserController
    /// </summary>
    [TestClass]
    public class UserControllerTests
    {
        public UserControllerTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        
        [TestMethod]
        public void Create()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            ActionResult result = controller.Register() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            UserController controller = new UserController();

            // Act
            ActionResult result = controller.Login() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LogOut()
        {
            // Arrange
            UserController controller = new UserController();
            NullReferenceException nullReferenceException = new NullReferenceException();
            
            // Act
            try
            {
                ActionResult result = controller.Logout() as ActionResult;
            }
            catch (Exception ex)
            {
                nullReferenceException = (NullReferenceException)ex;
            }

            // Assert
            Assert.IsNotNull(nullReferenceException);
        }
    }
}
