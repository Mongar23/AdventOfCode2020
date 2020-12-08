using System.IO;
using System;

namespace AdventOfCode.Days
{
    public class DayThree : DayBase
    {
        public override int Number => 3;

        char[,] data;

        public override void Initialize()
        {
            base.Initialize();

            string[] file = GetInputAsLines();
            data = new char[file[0].Length, file.Length];

            for (int i = 0; i < file.Length; i++)
            {
                for (int j = 0; j < file[i].Length; j++)
                {
                    data[j, i] = file[i][j];
                }
            }
        }

        public override string StarOne() => CheckPath(3, 1).ToString();

        public override string StarTwo()
        {
            int totalTreeEncounters = CheckPath(1, 1) * CheckPath(3, 1) * CheckPath(5, 1) * CheckPath(7, 1) * CheckPath(1, 2);
            return totalTreeEncounters.ToString();
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