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
        public List<double> Generate12() => FibonacciSeries(SequenceLength);
        public List<double> FibonacciSeries(int firstNItem)
        {

            List<double> store = new();
            const int stackArrSize = 25;
            Span<double> fibo = stackalloc double[stackArrSize];

            fibo[0] = 0;
            fibo[1] = 1;
            store.Add(fibo[0]);
            store.Add(fibo[1]); 

            for (int i = 2; i < firstNItem; i++)
            {
                int k = i;
                k %= stackArrSize; // loop in an array of 25 elements stored in stack

                if (k == 0)
                {
                    fibo[0] = fibo[^2] + fibo[^1];
                    fibo[1] = fibo[^1] + fibo[0];
                    store.Add(fibo[0]); store.Add(fibo[1]);
                    k = 2; // skip first two elements
                    i += 2; // skip two steps
                }

                fibo[k] = fibo[k - 1] + fibo[k - 2];
                store.Add(fibo[k]);
            }


            return store;
        }

        [Benchmark]
        public double[] Generate11() => Generate11(SequenceLength);
        public double[] Generate11(int sequenceLength)
        {
            double[] arrayFibonacci = new double[sequenceLength];

            arrayFibonacci[0] = 0;
            arrayFibonacci[1] = 1;


            for (int index = 2; index < sequenceLength; index++)
            {
                arrayFibonacci[index] = arrayFibonacci[index - 2] + arrayFibonacci[index - 1];
            }

            return arrayFibonacci;
        }

        [Benchmark]
        public Span<double> Generate10() => Generate10(SequenceLength);
        public Span<double> Generate10(int sequenceLength)
        {
            Span<double> arrayFibonacci = new Span<double>(new double[sequenceLength]);

            arrayFibonacci[0] = 0;
            arrayFibonacci[1] = 1;

            double next = 0;

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
        public double[] Generate9() => Generate9(SequenceLength);
        public double[] Generate9(int sequenceLength)
        {
            double[] arrayFibonacci = new double[sequenceLength];

            arrayFibonacci[0] = 0;
            arrayFibonacci[1] = 1;

            double next = 0;

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

            list.Add((double)0);
            list.Add((double)1);

            double next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = index; i > index - 2; i--)
                {
                    next += (double)list[i];
                }

                list.Add(next);
            }

            return list;
        }

        [Benchmark]
        public List<double> Generat7YieldTake() => Generate7Yield(SequenceLength);
        public List<double> Generate7Yield(int sequenceLength)
        {
            List<double> list = new List<double>();
            list = Generate6Yield().Take(sequenceLength).ToList();
            return list;
        }

        [Benchmark]
        public List<double> Generate6YieldToList() => Generate6Yield(SequenceLength);
        public List<double> Generate6Yield(int sequenceLength)
        {
            int index = 0;
            List<double> list = new List<double>();
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
        public IEnumerable<double> Generate6Yield()
        {
            double first = 0;
            double second = 1;

            yield return first;
            yield return second;

            while (true)
            {
                double temp = first;

                first = second;
                second = second + temp;

                yield return second;
            }
        }

        [Benchmark]
        public List<double> Generate5() => Generate5(SequenceLength);
        public List<double> Generate5(int sequenceLength)
        {
            List<double> list = new List<double>();
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
        public List<double> Generate4() => Generate4(SequenceLength);
        public List<double> Generate4(int sequenceLength)
        {
            List<double> list = new List<double>();

            list.Add(0);
            list.Add(1);

            double next = 0;

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
        public List<double> Generate3() => Generate3(SequenceLength);
        public List<double> Generate3(int sequenceLength)
        {
            List<double> list = new List<double>();

            list.Add(0);
            list.Add(1);

            double next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                IEnumerable<double> reversedList = list.AsEnumerable().Reverse();
                next += reversedList.Skip(0).First();
                next += reversedList.Skip(1).First();

                list.Add(next);
            }

            return list;
        }

        [Benchmark]
        public List<double> Generate2() => Generate2(SequenceLength);
        public List<double> Generate2(int sequenceLength)
        {
            List<double> list = new List<double>();

            list.Add(0);
            list.Add(1);

            double next = 0;

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
        public List<double> Generate1() => Generate1(SequenceLength);
        public List<double> Generate1(int sequenceLength)
        {
            List<double> list = new List<double>();

            list.Add(0);
            list.Add(1);

            double next = 0;

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