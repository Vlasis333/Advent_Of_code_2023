namespace AdventOfCode2023
{
    public class Day02Puzzle01 : IPuzzle
    {
        public void Initialize()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay02.txt")));

            List<Game> games = GetGames(puzzleInput);
            
            // Possible games static input
            int red = 12;
            int green = 13;
            int blue = 14;

            Console.WriteLine($"Puzzle 01 Result: {FindPossibleGames(games, red, green, blue).Sum()}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        class Game
        {
            public int ID { get; set; }
            public List<Dictionary<string, int>>? CubeSets { get; set; }
        }

        private static List<Game> GetGames(string[] input)
        {
            // Just my way of getting the same and not handling them 1 by 1 in the input file
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

        private static List<int> FindPossibleGames(List<Game> games, int targetRed, int targetGreen, int targetBlue)
        {
            // Logic of the solution
            List<int> possibleGames = new();

            foreach (Game game in games)
            {
                bool isPossible = true;

                foreach (var cubeSet in game.CubeSets)
                {
                    int redCount = cubeSet.ContainsKey("red") ? cubeSet["red"] : 0;
                    int greenCount = cubeSet.ContainsKey("green") ? cubeSet["green"] : 0;
                    int blueCount = cubeSet.ContainsKey("blue") ? cubeSet["blue"] : 0;

                    if (redCount > targetRed || greenCount > targetGreen || blueCount > targetBlue)
                    {
                        isPossible = false;
                        break;
                    }
                }

                if (isPossible)
                {
                    possibleGames.Add(game.ID);
                }
            }

            return possibleGames;
        }
    }
}
