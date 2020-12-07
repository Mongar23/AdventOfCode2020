using AdventOfCode.Tools;
using System.IO;
using System;

namespace AdventOfCode.Days
{
    public class DayThree : Day
    {
        char[,] data;

        public override void Initialize()
        {
            Debug.Info("----------------Initializing day three...");

            string[] file = File.ReadAllLines(@".\Days\Data\DayThree.txt");
            data = new char[file[0].Length, file.Length];

            for (int i = 0; i < file.Length; i++)
            {
                for (int j = 0; j < file[i].Length; j++)
                {
                    data[j, i] = file[i][j];
                }
            }

            StarOne();
            StarTwo();
        }

        protected override void StarOne()
        {
            Console.WriteLine($"STAR ONE: Awnser: {CheckPath(3, 1)}");
        }

        protected override void StarTwo()
        {
            int totalTreeEncounters = CheckPath(1, 1) * CheckPath(3, 1) * CheckPath(5, 1) * CheckPath(7, 1) * CheckPath(1, 2);

            Console.WriteLine($"STAR TWO: Awnser: {totalTreeEncounters}");
        }

        private int CheckPath(int right, int down)
        {
            int treeEncounters = 0;

            for (int y = 0, x = 0; y < data.GetLength(1); y += down, x += right)
            {
                if (x >= data.GetLength(0))
                {
                    x -= data.GetLength(0);
                }

                if (data[x, y] == '#') treeEncounters++;
            }

            return treeEncounters;
        }
    }
}