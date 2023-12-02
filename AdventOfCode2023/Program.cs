using AdventOfCode2023.Day01;
using AdventOfCode2023.Day02;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Run the puzzle calculations
            Console.WriteLine("Day 01");
            new Day01Puzzle01().Calculation();
            new Day01Puzzle02().Calculation();
            Console.WriteLine();

            Console.WriteLine("Day 02");
            new Day02Puzzle01().Calculation();
            new Day02Puzzle02().Calculation();
            Console.WriteLine();

            Console.WriteLine("Day 03");
            new Day03Puzzle01().Calculation();
            new Day03Puzzle02().Calculation();
            Console.WriteLine();


            // Keep the command window open
            Console.ReadLine();
        }
    }
}