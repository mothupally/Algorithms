using System;
using LongestCommonSubsequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestCommonSubsequenceUnitTests
{
    [TestClass]
    public class LCSTests
    {
        [TestMethod]
        public void NotNullStrings()
        {
            // Arrange
            char[] colSequence = new char[] { 'A', 'C', 'C', 'G', 'T' };
            char[] rowSequence = new char[] { 'T', 'A', 'G', 'T' };

            // Act
            var result = Program.GetLCS(colSequence, rowSequence);

            // Assert
            Assert.AreEqual("AGT", result);
        }

        [TestMethod]
        public void SecondStringEmpty()
        {
            // Arrange
            char[] colSequence = new char[] { 'A', 'C', 'C', 'G', 'T' };
            char[] rowSequence = new char[] {  };

            // Act
            var result = Program.GetLCS(colSequence, rowSequence);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void FirstStringEmpty()
        {
            // Arrange
            char[] colSequence = new char[] { };
            char[] rowSequence = new char[] { 'T', 'A', 'G', 'T' };

            // Act
            var result = Program.GetLCS(colSequence, rowSequence);

            // Assert
            Assert.AreEqual(string.Empty, result);
        }
    }
}
