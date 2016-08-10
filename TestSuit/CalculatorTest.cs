using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using String_Calculator;
using Moq;
namespace TestSuit
{

    [TestClass]
    public class CalculatorTest
    {
        
        Calculator Calculator;

       
        public void  CalculatorTestInit(string input,string Expected)
        {

            Mock<IConsole> ConsoleMoq = new Mock<IConsole>();
            ConsoleMoq.Setup(x => x.ReadLine()).Returns(input);
            IConsole Console=ConsoleMoq.Object;
          
            var StringCalculator = new StringCalculator();
           
            Calculator = new Calculator(Console,StringCalculator);
            Calculator.Calculate();
            ConsoleMoq.Verify(x => x.Write($"Result is : {Expected}"));
        }
        [TestMethod]
        public void InitTestMock()
        {
            CalculatorTestInit("","0");           
        }

        [TestMethod]
        public void InitTestMock1()
        {
            CalculatorTestInit("5", "5");
        }
    }
}
