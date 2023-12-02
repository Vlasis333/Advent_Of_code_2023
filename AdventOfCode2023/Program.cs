using AdventOfCode2023.Day01;
using AdventOfCode2023.Day02;

namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Run the puzzle calculations
            new Day01Puzzle01().Calculation();
            new Day01Puzzle02().Calculation();

            new Day02Puzzle01().Calculation();

            // Keep the command window open
            Console.ReadLine();
        }
    }
}