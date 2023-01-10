using FibonacciSequence.Console;
using System.Collections;
using System.Numerics;

namespace FibonacciSequence.Tests
{
    [TestClass]
    public class FibonacciGeneratorTests

    {
        [TestMethod]
        public void TestSequence()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            List<BigInteger> sequence = generator.Generate1(10);

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

            List<BigInteger> sequence = generator.Generate2(10);

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

            List<BigInteger> sequence = generator.Generate3(10);

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

            List<BigInteger> sequence = generator.Generate4(10);

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

            List<BigInteger> sequence = generator.Generate5(47);

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

            List<BigInteger> sequence = generator.Generate6YieldToList();

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

            List<BigInteger> sequence = generator.Generat7YieldTake();

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

            Assert.AreEqual((BigInteger)0, sequence[0]);
            Assert.AreEqual((BigInteger)1, sequence[1]);
            Assert.AreEqual((BigInteger)1, sequence[2]);
            Assert.AreEqual((BigInteger)2, sequence[3]);
            Assert.AreEqual((BigInteger)3, sequence[4]);
            Assert.AreEqual((BigInteger)5, sequence[5]);
            Assert.AreEqual((BigInteger)8, sequence[6]);
        }

        [TestMethod]
        public void TestSequence9()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            BigInteger[] sequence = generator.Generate9();

            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }

        [TestMethod]
        public void TestSequence10()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            Span<BigInteger> sequence = generator.Generate10();

            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);
        }


        [TestMethod]
        public void TestSequence11()
        {
            FibonacciGenerator generator = new FibonacciGenerator();

            BigInteger[] sequence = generator.Generate11();

            Assert.AreEqual(0, sequence[0]);
            Assert.AreEqual(1, sequence[1]);
            Assert.AreEqual(1, sequence[2]);
            Assert.AreEqual(2, sequence[3]);
            Assert.AreEqual(3, sequence[4]);
            Assert.AreEqual(5, sequence[5]);
            Assert.AreEqual(8, sequence[6]);

            Assert.AreEqual(
                "26863810024485359386146727202142923967616609318986952340123175997617981700247881689338369654483356564191827856161443356312976673642210350324634850410377680367334151172899169723197082763985615764450078474174626", 
                sequence[999].ToString());
        }
    }
}