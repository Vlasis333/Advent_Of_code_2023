using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public class DayProcessor
    {
        public static void Run()
        {
            //ExecuteDay("Day 01", new Day01Puzzle01(), new Day01Puzzle02());
            //ExecuteDay("Day 02", new Day02Puzzle01(), new Day02Puzzle02());
            //ExecuteDay("Day 03", new Day03Puzzle01(), new Day03Puzzle02());
            //ExecuteDay("Day 04", new Day04Puzzle01(), new Day04Puzzle02());
            //ExecuteDay("Day 05", new Day05Puzzle01(), new Day05Puzzle02());
            //ExecuteDay("Day 06", new Day06Puzzle01(), new Day06Puzzle02());
            //ExecuteDay("Day 07", new Day07Puzzle01(), new Day07Puzzle02());
            ExecuteDay("Day 08", new Day08Puzzle01(), new Day08Puzzle02());

            // Keep the command window open
            Console.ReadLine();
        }

        private static void ExecuteDay(string day, params IPuzzle[] puzzles)
        {
            Console.WriteLine(day);

            foreach (var puzzle in puzzles)
            {
                puzzle.Initialize();
            }

            Console.WriteLine();
        }
    }
}
