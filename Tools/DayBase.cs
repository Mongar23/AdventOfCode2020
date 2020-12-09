using System.Collections.Generic;
using AdventOfCode.Tools;
using System.IO;

namespace AdventOfCode
{
    public abstract class DayBase
    {
        public abstract int Number { get; }

        protected string[] GetInputAsLines() => File.ReadAllLines($@"{Directory.GetCurrentDirectory()}\Days\Data\{GetType().Name}.txt");
        protected string GetInputAsFile() => File.ReadAllText($@"{Directory.GetCurrentDirectory()}\Days\Data\{GetType().Name}.txt");
        protected int[] GetInputAsIntArray()
        {
            List<int> data = new List<int>();

            foreach (string line in File.ReadAllLines($@"{Directory.GetCurrentDirectory()}\Days\Data\{GetType().Name}.txt"))
            {
                try
                {
                    data.Add(int.Parse(line));
                }
                catch (System.OverflowException)
                {
                    Debug.Error($"{line} is either too high or too low for an Int32");
                }
            }

            return data.ToArray();
        }

        public virtual void Initialize()
        {
            Debug.Info($"Initializing day {Number}");
        }

        public abstract string StarOne();
        public abstract string StarTwo();
    }
}