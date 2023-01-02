using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence.Console
{
    [RPlotExporter]
    public class FibonacciGenerator
    {
        private const int SequenceLength = 1000;

        [Benchmark]
        public ArrayList Generate8() => Generate8(SequenceLength);
        public ArrayList Generate8(int sequenceLength)
        {
            ArrayList list = new ArrayList();

            list.Add(0);
            list.Add(1);

            int next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                for (int i = index; i > index - 2; i--)
                {
                    next += (int)list[i];
                }

                list.Add(next);
            }

            return list;
        }

        [Benchmark]
        public List<int> Generat7YieldTake() => Generate7Yield(SequenceLength);
        public List<int> Generate7Yield(int sequenceLength)
        {
            List<int> list = new List<int>();
            list = Generate6Yield().Take(sequenceLength).ToList();
            return list;
        }

        [Benchmark]
        public List<int> Generate6YieldToList() => Generate6Yield(SequenceLength);
        public List<int> Generate6Yield(int sequenceLength)
        {
            int index = 0;
            List<int> list = new List<int>();
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
        public IEnumerable<int> Generate6Yield()
        {
            int first = 0;
            int second = 1;

            yield return first;
            yield return second;

            while (true)
            {
                int temp = first;

                first = second;
                second = second + temp;
                
                yield return second;
            }
        }

        [Benchmark]
        public List<int> Generate5() => Generate5(SequenceLength);
        public List<int> Generate5(int sequenceLength)
        {
            List<int> list = new List<int>();

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
        public List<int> Generate4() => Generate4(SequenceLength);
        public List<int> Generate4(int sequenceLength)
        {
            List<int> list = new List<int>();

            list.Add(0);
            list.Add(1);

            int next = 0;

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
        public List<int> Generate3() => Generate3(SequenceLength);
        public List<int> Generate3(int sequenceLength)
        {
            List<int> list = new List<int>();

            list.Add(0);
            list.Add(1);

            int next = 0;

            for (int index = 1; index < sequenceLength; index++)
            {
                next = 0;

                next += list.AsEnumerable().Reverse().Skip(0).First();
                next += list.AsEnumerable().Reverse().Skip(1).First();

                list.Add(next);
            }

            return list;
        }

        [Benchmark]
        public List<int> Generate2() => Generate2(SequenceLength);
        public List<int> Generate2(int sequenceLength)
        {
            List<int> list = new List<int>();

            list.Add(0);
            list.Add(1);

            int next = 0;

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
        public List<int> Generate1() => Generate1(SequenceLength);
        public List<int> Generate1(int sequenceLength)
        {
            List<int> list = new List<int>();

            list.Add(0);
            list.Add(1);

            int next = 0;

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