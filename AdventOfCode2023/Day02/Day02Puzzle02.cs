using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day02
{
    public class Day02Puzzle02
    {
        public void Calculation()
        {
            string[] puzzleInput = ReadFile("C:\\Users\\vlasi\\Downloads\\input.txt");

            List<Game> games = GetGames(puzzleInput);

            // Possible games static input
            int red = 12;
            int green = 13;
            int blue = 14;

            List<int> possibleGames = FindPossibleGames(games, red, green, blue);

            int finalAnswer = possibleGames.Sum();
            Console.WriteLine($"Day 02 Puzzle 02 Result: {finalAnswer}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        class Game
        {
            public int ID { get; set; }
            public List<Dictionary<string, int>> CubeSets { get; set; }
        }
    }
}
