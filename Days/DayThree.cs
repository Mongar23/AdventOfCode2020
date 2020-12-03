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
            int treeEncounters = 0;
            int x = 0;

            for (int y = 0; y < data.GetLength(1); y++)
            {
                if (x >= data.GetLength(0))
                {
                    x -= data.GetLength(0);
                }

                if (data[x, y] == '#') treeEncounters++;

                x += 3;
            }

            Console.WriteLine($"STAR ONE: Awnser: {treeEncounters}");
        }

        protected override void StarTwo()
        {
            int[] treeEncountersArray = new int[5];
            int increaseAmountX = 0;
            int increaseAmountY = 0;

            for (int i = 0; i < 5; i++)
            {
                int treeEncounters = 0;
                int x = 0;

                if (increaseAmountX == 0 || increaseAmountX == 7)
                {
                    increaseAmountX = 1;
                    increaseAmountY++;
                }
                else
                {
                    increaseAmountX += 2;
                }

                for (int y = 0; y < data.GetLength(1); y += increaseAmountY)
                {
                    if (x >= data.GetLength(0))
                    {
                        x -= data.GetLength(0);
                    }

                    if (data[x, y] == '#') treeEncounters++;

                    x += increaseAmountX;
                }

                treeEncountersArray[i] = treeEncounters;
            }

            int totalTreeEncounters = 1;

            foreach (int treeEncounters in treeEncountersArray)
            {
                totalTreeEncounters *= treeEncounters;
            }

            Console.WriteLine($"STAR TWO: Awnser: {totalTreeEncounters}");
        }
    }
}