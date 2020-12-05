using System.Collections.Generic;
using AdventOfCode.Tools;
using System.IO;
using System;

namespace AdventOfCode.Days
{
    public class DayFive : Day
    {
        private string[] data;
        private List<BoardingPass> boardingPasses = new List<BoardingPass>();

        public override void Initialize()
        {
            Debug.Info("----------------Initializing day five...");

            data = File.ReadAllLines(@".\Days\Data\DayFive.txt");

            StarOne();
            StarTwo();
        }

        private struct BoardingPass
        {
            public int Row { get; private set; }
            public int Column { get; private set; }
            public int Id { get; private set; }

            public BoardingPass(int row, int column)
            {
                Row = row;
                Column = column;

                Id = row * 8 + column;
            }
        }

        protected override void StarOne()
        {
            int FindRow(string row)
            {
                int min = 0;
                int max = 127;

                foreach (char character in row)
                {
                    int difference = max - min;

                    if (character == 'F')
                    {
                        max = min + ((int)(Math.Floor(difference * 0.5f)));
                        continue;
                    }

                    if (character == 'B')
                    {
                        min += ((int)(Math.Ceiling(difference * 0.5f)));
                        continue;
                    }

                    Debug.Error($"{character} is not a valid in put!");
                }

                if (min != max) Debug.Error($"{min} != {max}");

                return max;
            }

            int FindColumn(string column)
            {
                int min = 0;
                int max = 7;

                foreach (char character in column)
                {
                    int difference = max - min;

                    if (character == 'L')
                    {
                        //Floor
                        max = min + ((int)(Math.Floor(difference * 0.5f)));
                        continue;
                    }

                    if (character == 'R')
                    {
                        //Ceiling
                        min += ((int)(Math.Ceiling(difference * 0.5f)));
                        continue;
                    }

                    Debug.Error($"{character} is not a valid in put!");
                }

                if (min != max) Debug.Error($"{min} != {max}");

                return max;
            }

            foreach (string line in data)
            {
                int row = FindRow(line.Substring(0, 7));
                int column = FindColumn(line.Substring(7, 3));

                boardingPasses.Add(new BoardingPass(row, column));
            }

            int highestId = 0;

            foreach (BoardingPass boardingPass in boardingPasses)
            {
                if (boardingPass.Id <= highestId) continue;

                highestId = boardingPass.Id;
            }

            Console.WriteLine($"STAR ONE: Awnser: {highestId}");
        }

        protected override void StarTwo()
        {
            List<int> boardingPassIds = boardingPasses.ConvertAll(boardingPass => boardingPass.Id);
            int seatId = 0;

            for (int i = 0; i < boardingPassIds.Count; i++)
            {
                if (boardingPassIds.Contains(boardingPasses[i].Id + 1) || !boardingPassIds.Contains(boardingPasses[i].Id)) continue;

                seatId = boardingPasses[i].Id + 1;
            }

            Console.WriteLine($"STAR TWO: Awnser: {seatId}");
        }
    }
}