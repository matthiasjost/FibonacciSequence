using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Numerics;

namespace FibonacciSequence.Console
{
    [MemoryDiagnoser]
    public class FibonacciGenerator
    {
        private int SequenceLength = 1000;

        [Benchmark]
        public BigInteger[] Generate11() => Generate11(SequenceLength);
        public BigInteger[] Generate11(int sequenceLength)
        {
            BigInteger[] fibonacci = new BigInteger[sequenceLength];

            fibonacci[0] = 0;
            fibonacci[1] = 1;

            for (int index = 2; index < sequenceLength; index++)
            {
                fibonacci[index] = fibonacci[index - 2] + fibonacci[index - 1];
            }

            return fibonacci;
        }

        [Benchmark]
        public Span<BigInteger> Generate10() => Generate10(SequenceLength);
        public Span<BigInteger> Generate10(int sequenceLength)
        {
            Span<BigInteger> fibonacci = new Span<BigInteger>(new BigInteger[sequenceLength]);

            fibonacci[0] = 0;
            fibonacci[1] = 1;

            BigInteger next = 0;

            for (int index = 2; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = index; i > index - 3; i--)
                {
                    next += fibonacci[i];
                }

                fibonacci[index] = next;
            }

            return fibonacci;
        }


        [Benchmark]
        public BigInteger[] Generate9() => Generate9(SequenceLength);
        public BigInteger[] Generate9(int sequenceLength)
        {
            BigInteger[] fibonacci = new BigInteger[sequenceLength];

            fibonacci[0] = 0;
            fibonacci[1] = 1;

            BigInteger next = 0;

            for (int index = 2; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = index; i > index - 3; i--)
                {
                    next += fibonacci[i];
                }

                fibonacci[index] = next;
            }
            return fibonacci;
        }


        [Benchmark]
        public ArrayList Generate8() => Generate8(SequenceLength);
        public ArrayList Generate8(int sequenceLength)
        {
            ArrayList fibonacci = new ArrayList();

            fibonacci.Add((BigInteger)0);
            fibonacci.Add((BigInteger)1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = index; i > index - 2; i--)
                {
                    next = (BigInteger)fibonacci[i] + next;
                }

                fibonacci.Add(next);
            }

            return fibonacci;
        }

        [Benchmark]
        public List<BigInteger> Generat7YieldTake() => Generate7Yield(SequenceLength);
        public List<BigInteger> Generate7Yield(int sequenceLength)
        {
            List<BigInteger> fibonacci = new List<BigInteger>();
            fibonacci = Generate6Yield().Take(sequenceLength).ToList();
            return fibonacci;
        }


        [Benchmark]
        public List<BigInteger> Generate6YieldToList() => Generate6Yield(SequenceLength);
        public List<BigInteger> Generate6Yield(int sequenceLength)
        {
            int index = 0;
            List<BigInteger> fibonacci = new List<BigInteger>();
            foreach (var generate in Generate6Yield())
            {
                fibonacci.Add(generate);
                index++;
                if (index == sequenceLength)
                {
                    break;
                }
            }
            return fibonacci;
        }
        public IEnumerable<BigInteger> Generate6Yield()
        {
            BigInteger first = 0;
            BigInteger second = 1;

            yield return first;
            yield return second;

            while (true)
            {
                BigInteger temp = first;

                first = second;
                second = second + temp;

                yield return second;
            }
        }


        [Benchmark]
        public List<BigInteger> Generate5() => Generate5(SequenceLength);
        public List<BigInteger> Generate5(int sequenceLength)
        {
            List<BigInteger> fibonacci = new List<BigInteger>();
            fibonacci.Add(0);
            fibonacci.Add(1);
            while (fibonacci.Count < sequenceLength)
            {
                fibonacci.Add(fibonacci.Skip(fibonacci.Count - 2).First()
                         + fibonacci.Skip(fibonacci.Count - 1).First());
            }
            return fibonacci;
        }


        [Benchmark]
        public List<BigInteger> Generate4() => Generate4(SequenceLength);
        public List<BigInteger> Generate4(int sequenceLength)
        {
            List<BigInteger> fibonacci = new List<BigInteger>();

            fibonacci.Add(0);
            fibonacci.Add(1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                next += fibonacci.Skip(fibonacci.Count - 1).First();
                next += fibonacci.Skip(fibonacci.Count - 2).First();

                fibonacci.Add(next);
            }

            return fibonacci;
        }

        [Benchmark]
        public List<BigInteger> Generate3() => Generate3(SequenceLength);
        public List<BigInteger> Generate3(int sequenceLength)
        {
            List<BigInteger> fibonacci = new List<BigInteger>();

            fibonacci.Add(0);
            fibonacci.Add(1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                IEnumerable<BigInteger> reversedList = fibonacci.AsEnumerable().Reverse();
                next += reversedList.Skip(0).First();
                next += reversedList.Skip(1).First();

                fibonacci.Add(next);
            }

            return fibonacci;
        }


        [Benchmark]
        public List<BigInteger> Generate2() => Generate2(SequenceLength);
        public List<BigInteger> Generate2(int sequenceLength)
        {
            List<BigInteger> fibonacci = new List<BigInteger>();

            fibonacci.Add(0);
            fibonacci.Add(1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = fibonacci.Count - 1; i > fibonacci.Count - 3; i--)
                {
                    next += fibonacci[i];
                }

                fibonacci.Add(next);
            }

            return fibonacci;
        }

        [Benchmark(Baseline = true)]
        public List<BigInteger> Generate1() => Generate1(SequenceLength);
        public List<BigInteger> Generate1(int sequenceLength)
        {
            List<BigInteger> fibonacci = new List<BigInteger>();

            fibonacci.Add(0);
            fibonacci.Add(1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;
                for (int i = index; i > index - 2; i--)
                {
                    next += fibonacci[i];
                }
                fibonacci.Add(next);
            }
            return fibonacci;
        }
    }
}