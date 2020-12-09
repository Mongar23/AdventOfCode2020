using System.Collections.Generic;
using AdventOfCode.Tools;
using System.Linq;
using System.IO;

namespace AdventOfCode.Days
{
    public class DayNine : DayBase
    {
        public override int Number => 9;

        private long[] data;
        private int preamble = 25;
        private long invalidValue = 0;
        private long invalidIndex = 0;

        public override void Initialize()
        {
            base.Initialize();

            string[] file = File.ReadAllLines($@"{Directory.GetCurrentDirectory()}\Days\Data\{GetType().Name}.txt");
            data = new long[file.Length];

            for (int i = 0; i < file.Length; i++)
            {
                data[i] = long.Parse(file[i]);
            }
        }

        public override string StarOne()
        {
            for (int i = preamble; i < data.Length; i++)
            {
                if (!isValid(i))
                {
                    invalidIndex = i;
                    invalidValue = data[i];
                    return invalidValue.ToString();
                }
            }

            bool isValid(int toCheck)
            {
                List<long> combinations = new List<long>();

                for (int i = toCheck - preamble; i < toCheck; i++)
                {
                    for (int j = toCheck - preamble; j < toCheck; j++)
                    {
                        if (i == j) continue;
                        combinations.Add(data[i] + data[j]);
                    }
                }

                foreach (long combination in combinations)
                {
                    if (combination == data[toCheck]) return true;
                }

                return false;
            }

            return "NO AWNSER FOUND";
        }

        public override string StarTwo()
        {
            int firstIndex = 0;
            int lastIndex = 1;

            while (firstIndex < invalidIndex)
            {
                List<long> checking = data.ToList().GetRange(firstIndex, (lastIndex - firstIndex) + 1);
                long sum = checking.Sum();

                if (sum == invalidValue)
                {
                    checking.Sort();
                    return (checking.First() + checking.Last()).ToString();
                }

                if (lastIndex < invalidIndex - 1)
                {
                    lastIndex++;
                }
                else
                {
                    firstIndex++;
                    lastIndex = firstIndex + 1;
                }
            }

            return "NO AWNSER FOUND";
        }

        private bool isValid(int toCheck)
        {
            List<long> combinations = new List<long>();

            for (int i = toCheck - preamble; i < toCheck; i++)
            {
                for (int j = i; j < toCheck; j++)
                {
                    if (i == j) continue;
                    combinations.Add(data[i] + data[j]);
                }
            }

            foreach (long combination in combinations)
            {
                if (combination == data[toCheck]) return true;
            }

            return false;
        }
    }
}