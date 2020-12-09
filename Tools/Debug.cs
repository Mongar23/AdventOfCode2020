using System;

namespace AdventOfCode.Tools
{
    public static class Debug
    {
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ERROR] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[INFO] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public static void Waring(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[WARNING] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public static void Awnser(string message, double completedIn)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Awnser] ");
            Console.ResetColor();
            Console.Write($"{message} ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"completed in {completedIn} ms");
            Console.ResetColor();
        }

        public static void Initalizing(int dayNumber)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[INITIALIZING] ");
            Console.ResetColor();
            Console.WriteLine($"Day {dayNumber}... ");
        }

        public static void End()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("[END] ");
            Console.ResetColor();
            Console.Write("Press any key to exit...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}