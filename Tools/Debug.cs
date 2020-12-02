using System;

namespace AdventOfCode.Tools
{
    public static class Debug
    {
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }

        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }
    }
}