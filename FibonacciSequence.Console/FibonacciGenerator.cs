using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Numerics;

namespace FibonacciSequence.Console
{
    [RPlotExporter]
    [MemoryDiagnoser]
    public class FibonacciGenerator
    {
        private int SequenceLength = 1000;

        [Benchmark]
        public BigInteger[] Generate11() => Generate11(SequenceLength);
        public BigInteger[] Generate11(int sequenceLength)
        {
            BigInteger[] arrayFibonacci = new BigInteger[sequenceLength];

            arrayFibonacci[0] = 0;
            arrayFibonacci[1] = 1;


            for (int index = 2; index < sequenceLength; index++)
            {
                arrayFibonacci[index] = arrayFibonacci[index - 2] + arrayFibonacci[index - 1];
            }

            return arrayFibonacci;
        }


        [Benchmark]
        public Span<BigInteger> Generate10() => Generate10(SequenceLength);
        public Span<BigInteger> Generate10(int sequenceLength)
        {
            Span<BigInteger> arrayFibonacci = new Span<BigInteger>(new BigInteger[sequenceLength]);

            arrayFibonacci[0] = 0;
            arrayFibonacci[1] = 1;

            BigInteger next = 0;

            for (int index = 2; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = index; i > index - 3; i--)
                {
                    next += arrayFibonacci[i];
                }

                arrayFibonacci[index] = next;
            }

            return arrayFibonacci;
        }


        [Benchmark]
        public BigInteger[] Generate9() => Generate9(SequenceLength);
        public BigInteger[] Generate9(int sequenceLength)
        {
            BigInteger[] arrayFibonacci = new BigInteger[sequenceLength];

            arrayFibonacci[0] = 0;
            arrayFibonacci[1] = 1;

            BigInteger next = 0;

            for (int index = 2; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = index; i > index - 3; i--)
                {
                    next += arrayFibonacci[i];
                }

                arrayFibonacci[index] = next;
            }

            return arrayFibonacci;
        }


        [Benchmark]
        public ArrayList Generate8() => Generate8(SequenceLength);
        public ArrayList Generate8(int sequenceLength)
        {
            ArrayList list = new ArrayList();

            list.Add((BigInteger)0);
            list.Add((BigInteger)1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = index; i > index - 2; i--)
                {
                    next = (BigInteger)list[i] + next;
                }

                list.Add(next);
            }

            return list;
        }

        [Benchmark]
        public List<BigInteger> Generat7YieldTake() => Generate7Yield(SequenceLength);
        public List<BigInteger> Generate7Yield(int sequenceLength)
        {
            List<BigInteger> list = new List<BigInteger>();
            list = Generate6Yield().Take(sequenceLength).ToList();
            return list;
        }


        [Benchmark]
        public List<BigInteger> Generate6YieldToList() => Generate6Yield(SequenceLength);
        public List<BigInteger> Generate6Yield(int sequenceLength)
        {
            int index = 0;
            List<BigInteger> list = new List<BigInteger>();
            foreach (var generate in Generate6Yield())
            {
                list.Add(generate);
                index++;
                if (index == sequenceLength)
                {
                    break;
                }
            }
            return list;
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
            List<BigInteger> list = new List<BigInteger>();
            list.Add(0);
            list.Add(1);
            while (list.Count < sequenceLength)
            {
                list.Add(list.Skip(list.Count - 2).First()
                         + list.Skip(list.Count - 1).First());
            }
            return list;
        }


        [Benchmark]
        public List<BigInteger> Generate4() => Generate4(SequenceLength);
        public List<BigInteger> Generate4(int sequenceLength)
        {
            List<BigInteger> list = new List<BigInteger>();

            list.Add(0);
            list.Add(1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                next += list.Skip(list.Count - 1).First();
                next += list.Skip(list.Count - 2).First();

                list.Add(next);
            }

            return list;
        }

        [Benchmark]
        public List<BigInteger> Generate3() => Generate3(SequenceLength);
        public List<BigInteger> Generate3(int sequenceLength)
        {
            List<BigInteger> list = new List<BigInteger>();

            list.Add(0);
            list.Add(1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                IEnumerable<BigInteger> reversedList = list.AsEnumerable().Reverse();
                next += reversedList.Skip(0).First();
                next += reversedList.Skip(1).First();

                list.Add(next);
            }

            return list;
        }


        [Benchmark]
        public List<BigInteger> Generate2() => Generate2(SequenceLength);
        public List<BigInteger> Generate2(int sequenceLength)
        {
            List<BigInteger> list = new List<BigInteger>();

            list.Add(0);
            list.Add(1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = list.Count - 1; i > list.Count - 3; i--)
                {
                    next += list[i];
                }

                list.Add(next);
            }

            return list;
        }

        [Benchmark(Baseline = true)]
        public List<BigInteger> Generate1() => Generate1(SequenceLength);
        public List<BigInteger> Generate1(int sequenceLength)
        {
            List<BigInteger> list = new List<BigInteger>();

            list.Add(0);
            list.Add(1);

            BigInteger next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;
                for (int i = index; i > index - 2; i--)
                {
                    next += list[i];
                }
                list.Add(next);
            }
            return list;
        }
    }
}