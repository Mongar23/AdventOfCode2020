using System;
using System.IO;
using AdventOfCode.Tools;

namespace AdventOfCode.Days
{
    public class DayOne : Day
    {
        private int[] data;

        public override void Initialize()
        {
            Debug.Info("----------------Initializing day one...");

            var file = File.ReadAllLines(@".\Days\Data\DayOne.txt");
            data = new int[file.Length];

            for (int i = 0; i < file.Length; i++)
            {
                data[i] = int.Parse(file[i]);
            }

            StarOne();
            StarTwo();
        }

        protected override void StarOne()
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (j == i) continue;

                    int sum = data[i] + data[j];
                    if (sum != 2020) continue;
                    Console.WriteLine($"STAR ONE: Awnser: {data[i] * data[j]}");
                    return;
                }
            }
        }

        protected override void StarTwo()
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (j == i) continue;

                    for (int k = 0; k < data.Length; k++)
                    {
                        if (k == i || k == j) continue;

                        int sum = data[i] + data[j] + data[k];
                        if (sum != 2020) continue;
                        Console.WriteLine($"STAR TWO: Awnser: {data[i] * data[j] * data[k]}");
                        return;
                    }
                }
            }
        }
    }
}