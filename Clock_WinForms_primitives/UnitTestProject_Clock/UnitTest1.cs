using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_6_Programm;

namespace UnitTestProject_Clock
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Тестирования метода для возврата угла для часовой стрелки в радианах
        /// </summary>
        [TestMethod]
        public void TestMethod_GetHourArc()
        {
            // Arrange
            int _hour = 16;
            int _min = 49;
            string expectRes = "0,9425";
            // Act
            string gettedRes = Clock_logic.GetHourArc(_hour, _min).ToString("F4");
            // Assert
            Assert.AreEqual(expectRes, gettedRes);
        }

        /// <summary>
        /// Тестирования метода для возврата угла для минутной стрелки в радианах
        /// </summary>
        [TestMethod]
        public void TestMethod_GetMinArc()
        {
            // Arrange
            int _sec = 9;
            int _min = 50;
            string expectRes = "3,67";
            // Act
            string gettedRes = Clock_logic.GetMinArc(_min, _sec).ToString("F2");
            // Assert
            Assert.AreEqual(expectRes, gettedRes);
        }

        /// <summary>
        /// Тестирования метода для возврата угла для секундной стрелки в радианах
        /// </summary>
        [TestMethod]
        public void TestMethod_GetSecArc()
        {
            // Arrange
            int _sec = 45;
            string expectRes = "3,1416";
            // Act
            string gettedRes = Clock_logic.GetSecArc(_sec).ToString("F4");
            // Assert
            Assert.AreEqual(expectRes, gettedRes);
        }
    }
}
