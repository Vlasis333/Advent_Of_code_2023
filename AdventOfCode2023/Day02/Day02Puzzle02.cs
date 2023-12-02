using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day02
{
    public class Day02Puzzle02
    {
        public void Calculation()
        {
            string[] puzzleInput = ReadFile(@"C:\Users\vlasi\Desktop\Main Files\Projects\Code Base\Console\AdventOfCode2023\AdventOfCode2023 Inputs\inputDay02.txt");

            List<Game> games = GetGames(puzzleInput);

            List<int> possibleGames = FindMaxOfEachCube(games);

            int finalAnswer = possibleGames.Sum();
            Console.WriteLine($"Puzzle 02 Result: {finalAnswer}");
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

        static List<Game> GetGames(string[] input)
        {
            List<Game> games = new();

            foreach (string line in input)
            {
                string[] parts = line.Split(':');
                int gameId = int.Parse(parts[0].Trim().Split(' ')[1]);

                string[] cubeSets = parts[1].Trim().Split(';');
                List<Dictionary<string, int>> sets = new();

                foreach (string set in cubeSets)
                {
                    Dictionary<string, int> cubeCounts = new();
                    string[] cubes = set.Trim().Split(',');
                    foreach (string cube in cubes)
                    {
                        string[] cubeInfo = cube.Trim().Split(' ');
                        string color = cubeInfo[1].ToLower();
                        int count = int.Parse(cubeInfo[0]);
                        cubeCounts[color] = count;
                    }
                    sets.Add(cubeCounts);
                }

                Game game = new Game { ID = gameId, CubeSets = sets };
                games.Add(game);
            }

            return games;
        }

        static List<int> FindMaxOfEachCube(List<Game> games)
        {
            // Logic of the solution (minor changes from the first puzzle)
            List<int> maxMultiplicationScore = new List<int>();

            foreach (Game game in games)
            {
                int maxRedCount = 0;
                int maxGreenCount = 0;
                int maxBlueCount = 0;

                foreach (var cubeSet in game.CubeSets)
                {
                    int redCount = cubeSet.ContainsKey("red") ? cubeSet["red"] : 0;
                    int greenCount = cubeSet.ContainsKey("green") ? cubeSet["green"] : 0;
                    int blueCount = cubeSet.ContainsKey("blue") ? cubeSet["blue"] : 0;

                    // We just get the max (same logic as before but we assume all games are valid now)
                    maxRedCount = Math.Max(maxRedCount, redCount);
                    maxGreenCount = Math.Max(maxGreenCount, greenCount);
                    maxBlueCount = Math.Max(maxBlueCount, blueCount);
                }

                // And then multiply
                maxMultiplicationScore.Add(maxRedCount * maxGreenCount * maxBlueCount);
            }

            return maxMultiplicationScore;
        }
    }
}
