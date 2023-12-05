namespace AdventOfCode2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunDay("Day 01", new Day01Puzzle01(), new Day01Puzzle02());
            RunDay("Day 02", new Day02Puzzle01(), new Day02Puzzle02());
            RunDay("Day 03", new Day03Puzzle01(), new Day03Puzzle02());
            RunDay("Day 04", new Day04Puzzle01(), new Day04Puzzle02());
            //RunDay("Day 05", new Day05Puzzle01(), new Day05Puzzle02());

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