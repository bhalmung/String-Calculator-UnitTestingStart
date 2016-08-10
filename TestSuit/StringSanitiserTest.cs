using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using String_Calculator;
namespace TestSuit
{
    /// <summary>
    /// Summary description for StringSanitiserTest
    /// </summary>
    [TestClass]
    public class StringSanitiserTest
    {
        public StringSanitiserTest()
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

            public void RunTest(string input, string Expectedoutput)
        {
            var Sanitiser = new StringSanitiser(',');
            var result = Sanitiser.Sanitise(input);

            Assert.AreEqual(result, Expectedoutput);
        }

        public void GetDefaultSeperator(string input, string  expectedSeperator, string expectedOutput)
        {
            string newValue;
            var Sanitiser = new StringSanitiser(',');
            var result = Sanitiser.GetDefaultSeperator(input, out newValue);
            Assert.AreEqual(expectedSeperator, result);
            Assert.AreEqual(expectedOutput, newValue);
        }

        [TestMethod]
        public void Sanitise_StringWithNewLine_ReturnStringWithOnlyDefaultSeparator()
        {
            RunTest("1,2,3", "1,2,3");
        }
        [TestMethod]
        public void Sanitise_StringWithNewLine_ReturnStringReplaceingNewLiteWithDefaultSeparator()
        {
            RunTest("1\n2,3", "1,2,3");
        }
        [TestMethod]
        public void Sanitise_StringWithNewLine_ReturnStringReplaceingTwoNewLiteWithDefaultSeparator()
        {
            RunTest("1\n2\n3", "1,2,3");
        }

        [TestMethod]
        public void Sanitise_StringWithNewLine_ReturnStringReplaceingCustomSeperatorWithDefaultSeparator()
        {
            RunTest("//;\n1;2", "1,2");
        }

        [TestMethod]
        public void Sanitise_StringWithNewLine1_ReturnStringReplaceingCustomSeperatorWithDefaultSeparator()
        {
            RunTest("//;\n1;2,3", "1,2,3");
        }
        [TestMethod]
        public void Sanitise_StringWithNewLine2_ReturnStringReplaceingCustomSeperatorWithDefaultSeparator()
        {
            RunTest("//;\n1;2\n3", "1,2,3");
        }

        [TestMethod]
        public void GetDefaultSeperator_WithCustomSperator_ReturnString()
        {
            GetDefaultSeperator("//;\n1,2,3",";", "1,2,3");
        }
        [TestMethod]
        public void GetDefaultSeperator_WithCustomSperatorHavingSeperatorinsideNumbers_ReturnString()
        {
            GetDefaultSeperator("//;\n1;2,3", ";", "1;2,3");
        }

        [TestMethod]
        public void GetDefaultSeperator_WithCustomSperatorHavingSeperatorNewLineinsideNumbers_ReturnString()
        {
            GetDefaultSeperator("//;\n1;2\n3", ";", "1;2\n3");
        }



        [TestMethod]
        public void GetDefaultSeperator_WithCustomSperatorHavingStringSeperatorNewLineinsideNumbers_ReturnString()
        {
            GetDefaultSeperator("//***\n1;2\n3", "***", "1;2\n3");
        }

        [TestMethod]
        public void GetDefaultSeperator_WithCustomSperatorHavingStringSeperatorNewLineinsideNumbers1_ReturnString()
        {
            GetDefaultSeperator("//***\n1;2\n3***4", "***", "1;2\n3***4");
        }
    }
}
