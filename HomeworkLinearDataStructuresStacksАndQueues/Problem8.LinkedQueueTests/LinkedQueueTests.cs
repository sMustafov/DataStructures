namespace Problem8.LinkedQueueTests
{
    using System;
    using Problem7.LinkedQueue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void EnqueueOneElementToEmptyStack_ShouldReturnCountOne()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act
            linkedQueue.Enqueue(5);

            // Assert
            Assert.AreEqual(1, linkedQueue.Count);
        }

        [TestMethod]
        public void EnqueueThreeElementsToEmptyStack_ShouldReturnCountThree()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act
            linkedQueue.Enqueue(5);
            linkedQueue.Enqueue(8);
            linkedQueue.Enqueue(11);

            // Assert
            Assert.AreEqual(3, linkedQueue.Count);
        }

        [TestMethod]
        public void EnqueueAndDequeueElement_ShouldReturnCorrectAnswer()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act
            linkedQueue.Enqueue(5);
            linkedQueue.Dequeue();

            // Assert
            Assert.AreEqual(0, linkedQueue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueFromEmptyStack_ShouldThrowException()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act
            linkedQueue.Dequeue();
            var exception = "List empty";

            // Assert
            Assert.AreEqual(exception, "List empty");
        }

        [TestMethod]
        public void EnqueueAndDequeueElement_ShouldReturnEqualEnqueuedAndDequeuedElements()
        {
            // Arrange
            var numbers = new LinkedQueue<int>();

            // Act
            numbers.Enqueue(5);
            var resultNum = numbers.Dequeue();

            // Assert
            Assert.AreEqual(resultNum, 5);
        }
    }
}
