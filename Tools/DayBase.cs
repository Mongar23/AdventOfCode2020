using AdventOfCode.Tools;
using System.IO;
using System;

namespace AdventOfCode
{
    public abstract class DayBase
    {
        public abstract int Number { get; }

        protected string[] GetInputAsLines() => File.ReadAllLines($@"{Directory.GetCurrentDirectory()}\Days\Data\{GetType().Name}.txt");
        protected string GetInputAsFile() => File.ReadAllText($@"{Directory.GetCurrentDirectory()}\Days\Data\{GetType().Name}.txt");

        public virtual void Initialize()
        {
            Debug.Info($"Initializing day {Number}");
        }

        public abstract string StarOne();
        public abstract string StarTwo();
    }
}