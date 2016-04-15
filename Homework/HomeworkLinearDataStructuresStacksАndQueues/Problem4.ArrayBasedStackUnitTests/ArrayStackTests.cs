namespace Problem4.ArrayBasedStackUnitTests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem3ImplementAnArrayBasedStack;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void EmptyArrayStack_ShouldReturnCountZero()
        {
            // Arrange
            var numbers = new ArrayStack<int>();

            // Assert
            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void PushElement_ShouldAddElementAndReturnCountOne()
        {
            // Arrange
            var numbers = new ArrayStack<int>();

            // Act
            numbers.Push(5);

            // Assert
            Assert.AreEqual(1, numbers.Count);
        }

        [TestMethod]
        public void PopPushedElement_ShouldReturnCountZero()
        {
            // Arrange
            var numbers = new ArrayStack<int>();

            // Act
            numbers.Push(5);
            numbers.Pop();

            // Assert
            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void PushAndPopElement_ShouldReturnEqualPushedAndPoppedElements()
        {
            // Arrange
            var numbers = new ArrayStack<int>();

            // Act
            numbers.Push(5);
            var resultNum = numbers.Pop();

            // Assert
            Assert.AreEqual(resultNum, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PopFromEmptyArrayStack_ShouldThrowException()
        {
            // Arrange
            var numbers = new ArrayStack<int>();

            // Act
            numbers.Pop();
            string exception = "The Array Stack is empty";

            // Assert
            Assert.AreEqual(exception, "The Array Stack is empty");
        }

        [TestMethod]
        public void Enqueue1000Elements_ToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var array = Enumerable.Range(1, 1000).ToArray();
            var stack = new ArrayStack<int>();

            // Act
            for (int i = 0; i < array.Length; i++)
            {
                stack.Push(array[i]);
            }
            var arrayFromQueue = stack.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, arrayFromQueue);
        }
    }
}
