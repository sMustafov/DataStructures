namespace Problem6.LinkedStackTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem5.LinkedStack;

    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void PushOneElementToEmptyStack_ShouldReturnCountOne()
        {
            // Arrange
            var linkedStack = new LinkedStack<int>();

            // Act
            linkedStack.Push(5);

            // Assert
            Assert.AreEqual(1, linkedStack.Count);
        }

        [TestMethod]
        public void PushThreeElementsToEmptyStack_ShouldReturnCountThree()
        {
            // Arrange
            var linkedStack = new LinkedStack<int>();

            // Act
            linkedStack.Push(5);
            linkedStack.Push(8);
            linkedStack.Push(11);

            // Assert
            Assert.AreEqual(3, linkedStack.Count);
        }

        [TestMethod]
        public void PushAndPopElement_ShouldReturnCorrectAnswer()
        {
            // Arrange
            var linkedStack = new LinkedStack<int>();

            // Act
            linkedStack.Push(5);
            linkedStack.Pop();

            // Assert
            Assert.AreEqual(0, linkedStack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStack_ShouldThrowException()
        {
            // Arrange
            var linkedStack = new LinkedStack<int>();

            // Act
            linkedStack.Pop();
            var exception = "List empty";

            // Assert
            Assert.AreEqual(exception, "List empty");
        }

        [TestMethod]
        public void PushAndPopElement_ShouldReturnEqualPushedAndPoppedElements()
        {
            // Arrange
            var numbers = new LinkedStack<int>();

            // Act
            numbers.Push(5);
            var resultNum = numbers.Pop();

            // Assert
            Assert.AreEqual(resultNum, 5);
        }
    }
}
