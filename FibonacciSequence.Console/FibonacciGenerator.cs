using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence.Console
{
    public class FibonacciGenerator
    {

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