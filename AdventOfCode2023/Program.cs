using AdventOfCode2023.Day01;
using AdventOfCode2023.Day02;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunDay("Day 01", new Day01Puzzle01(), new Day01Puzzle02());
            RunDay("Day 02", new Day02Puzzle01(), new Day02Puzzle02());
            RunDay("Day 03", new Day03Puzzle01(), new Day03Puzzle02());

            // Keep the command window open
            Console.ReadLine();
        }

        static void RunDay(string day, params IPuzzle[] puzzles)
        {
            Console.WriteLine(day);

            foreach (var puzzle in puzzles)
            {
                puzzle.Calculation();
            }

            Console.WriteLine();
        }
    }
}