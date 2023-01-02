using FibonacciSequence.Console;
using System.Collections;

namespace FibonacciSequence.Tests
{
    [TestClass]
    public class FibonacciGeneratorTests
    {
        [TestMethod]
        public void TestSequence()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            List<int> sequence = generator.Generate1(10);


            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }

        [TestMethod]
        public void TestSequence2()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            List<int> sequence = generator.Generate2(10);


            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }

        [TestMethod]
        public void TestSequence3()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            List<int> sequence = generator.Generate3(10);


            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }
        [TestMethod]
        public void TestSequence4()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            List<int> sequence = generator.Generate4(10);


            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }
        [TestMethod]
        public void TestSequence5()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            List<int> sequence = generator.Generate5(10);


            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }

        [TestMethod]
        public void TestSequence6()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            List<int> sequence = generator.Generate6YieldToList();

            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }

        [TestMethod]
        public void TestSequence7()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            List<int> sequence = generator.Generat7YieldTake();

            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }

        [TestMethod]
        public void TestSequence8()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            ArrayList sequence = generator.Generate8();

            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }
    }
}