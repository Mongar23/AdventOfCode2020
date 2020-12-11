using Debug = AdventOfCode.Tools.Debug;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using System;

namespace AdventOfCode
{
    class Program
    {
        private static List<DayBase> days;

        static void Main(string[] args)
        {
            List<DayBase> unsortedList = new List<DayBase>();

            foreach (Type type in Assembly.GetAssembly(typeof(DayBase)).GetTypes().Where(classType => classType.IsClass && !classType.IsAbstract && classType.IsSubclassOf(typeof(DayBase))))
            {
                DayBase day = (DayBase)Activator.CreateInstance(type);
                unsortedList.Add(day);
            }

            days = unsortedList.OrderBy(day => day.Number).ToList();


            foreach (DayBase day in days)
            {
                day.Initialize();

                try
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    Debug.Awnser($"STAR 1: {day.StarOne()}", stopwatch.Elapsed.TotalMilliseconds);
                }
                catch (NotImplementedException) { Debug.Waring("Star one is not implemented."); }

                try
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    Debug.Awnser($"STAR 2: {day.StarTwo()}", stopwatch.Elapsed.TotalMilliseconds);
                }
                catch (NotImplementedException) { Debug.Waring("Star two is not implemented."); }

                Console.Write("\n");
            }

            try
            {
                Debug.End();
            }
            catch (InvalidOperationException) { }
        }
    }
}
