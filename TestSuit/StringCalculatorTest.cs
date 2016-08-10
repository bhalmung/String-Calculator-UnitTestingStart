using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using String_Calculator;
namespace TestSuit
{
    [TestClass]
    public class StringCalculatorTest
    {  

      
        public  void  InitMethod (string input,int expectedOutput)
        {
            //Arrange
            var StringCalculatorObject = new StringCalculator();
            //Act
            var result = StringCalculatorObject.Add(input);
            //Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void StringCalculator_EmptyString_Returns0()
        {
            InitMethod("", 0);
        }

        [TestMethod]
        public void StringCalculator_OneChar_ReturnsSum()
        {
            InitMethod("1",1);
        }
        [TestMethod]
        public void StringCalculator_ThreeChar_ReturnsSum()
        {
            InitMethod("1,2,3",6);
        }

        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperator_ReturnsSum()
        {
            InitMethod("1,2\n3", 6);
        }


        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperator1_ReturnsSum()
        {
            InitMethod("//;\n1,2\n3", 6);
        }

        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperator2_ReturnsSum()
        {
            InitMethod("//;\n1,2\n3;4;5", 15);

        }

              [TestMethod]
              [ExpectedException(typeof( Exception),"-4")]
              
        public void StringCalculator_ThreeCharWitnNewLineSeperatorwithNegativeNumber_ReturnsError()
        {
            InitMethod("//;\n1,2\n3;-4;5", 15);
        }


        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperatorWithNumberGreaterThan1000_ReturnsSum()
        {
            InitMethod("//;\n1,2\n3;5000", 6);
        }

        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperatorWithAllNumbersGreaterThan1000_ReturnsSum()
        {
            InitMethod("//;\n1000,2000\n3000;5000", 0);
        }

        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperator3_ReturnsSum()
        {
            InitMethod("//***\n1,2\n3***4***5", 15);

        }


        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperator4_ReturnsSum()
        {
            InitMethod("//[***]\n1,2\n3***4***5", 15);

        }

        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperator5_ReturnsSum()
        {
            InitMethod("//[***][bbb]\n1,2\n3***4bbb5", 15);

        }
        [TestMethod]
        public void StringCalculator_ThreeCharWitnNewLineSeperator6_ReturnsSum()
        {
            InitMethod("//[*][%]\n1*2%3", 6);

        }
    }
}
