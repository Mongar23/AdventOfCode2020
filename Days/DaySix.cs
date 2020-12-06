using System.Collections.Generic;
using AdventOfCode.Tools;
using System.Linq;
using System.IO;
using System;

namespace AdventOfCode.Days
{
    public class DaySix : Day
    {
        private string[] data;

        public override void Initialize()
        {
            Debug.Info("----------------Initializing day six...");

            data = File.ReadAllText(@".\Days\Data\DaySix.txt").Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            StarOne();
            StarTwo();
        }

        protected override void StarOne()
        {
            int sumOfYes = 0;

            foreach (string group in data)
            {
                string trimmedGroup = String.Concat(group.Where(c => !Char.IsWhiteSpace(c)));

                sumOfYes += trimmedGroup.Distinct().Count();
            }

            Console.WriteLine($"STAR ONE: Awnser: {sumOfYes}");
        }

        protected override void StarTwo()
        {
            int sumOfSimmilarAwnsers = 0;

            foreach (string group in data)
            {
                string[] persons = group.Split(new[] { '\n', '\r', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<char, int> awnsers = new Dictionary<char, int>();

                foreach (string person in persons)
                {
                    int simmilarAwnsers = 0;

                    foreach (char awnser in person)
                    {
                        if (awnsers.ContainsKey(awnser))
                        {
                            awnsers[awnser]++;
                            continue;
                        }

                        awnsers.Add(awnser, 1);
                        continue;
                    }

                    foreach (KeyValuePair<char, int> keyValuePair in awnsers)
                    {
                        if (keyValuePair.Value != persons.Count()) continue;

                        simmilarAwnsers++;
                    }

                    sumOfSimmilarAwnsers += simmilarAwnsers;
                }
            }

            Console.WriteLine($"STAR Two: Awnser: {sumOfSimmilarAwnsers}");
        }
    }
}