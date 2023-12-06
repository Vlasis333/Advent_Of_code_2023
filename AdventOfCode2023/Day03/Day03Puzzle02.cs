namespace AdventOfCode2023
{
    public class Day03Puzzle02 : IPuzzle
    {
        public void Calculation()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay03.txt")));

            Console.WriteLine($"Puzzle 02 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static int CalculateAnswer(string[] fileData)
        {
            // Same as part 1, only changes made are related how we treat values and coordinates inside the loops
            int totalValue = 0;

            for (int row = 0; row < fileData.Length; row++)
            {
                for (int col = 0; col < fileData[row].Length; col++)
                {
                    char currentChar = fileData[row][col];

                    if (currentChar != '*')
                    {
                        continue;
                    }

                    HashSet<(int, int)> adjacentParts = FindAdjacentParts(fileData, row, col);

                    if (adjacentParts.Count == 2)
                    {
                        List<int> values = ExtractValuesFromCoordinates(fileData, adjacentParts);
                        totalValue += values[0] * values[1];
                    }
                }
            }

            return totalValue;
        }

        private static HashSet<(int, int)> FindAdjacentParts(string[] fileData, int row, int col)
        {
            // Same as part 1, but this time we want the part coordinates to reset in each loop
            HashSet<(int, int)> partCoordinates = new();

            for (int dynamicRow = row - 1; dynamicRow <= row + 1; dynamicRow++)
            {
                for (int dynamicCol = col - 1; dynamicCol <= col + 1; dynamicCol++)
                {
                    if (IsValidPartCoordinate(fileData, dynamicRow, dynamicCol))
                    {
                        int adjustedCol = AdjustColumnToPart(fileData, dynamicRow, dynamicCol);
                        partCoordinates.Add((dynamicRow, adjustedCol));
                    }
                }
            }

            return partCoordinates;
        }

        private static bool IsValidPartCoordinate(string[] fileData, int row, int col)
        {
            // Same as part 1
            return row >= 0 && row < fileData.Length && col >= 0 && col < fileData[row].Length && char.IsDigit(fileData[row][col]);
        }

        private static int AdjustColumnToPart(string[] fileData, int row, int col)
        {
            // Same as part 1
            int currentColumn = col;

            while (currentColumn > 0 && char.IsDigit(fileData[row][currentColumn - 1]))
            {
                currentColumn--;
            }

            return currentColumn;
        }

        private static List<int> ExtractValuesFromCoordinates(string[] fileData, HashSet<(int, int)> coordinates)
        {
            // Same as part 1, but this time we want the part values to reset in each loop
            List<int> partValues = new();

            foreach ((int row, int col) in coordinates)
            {
                string value = "";

                int adjustedCol = col;
                while (adjustedCol < fileData[row].Length && char.IsDigit(fileData[row][adjustedCol]))
                {
                    value += fileData[row][adjustedCol];
                    adjustedCol++;
                }

                partValues.Add(int.Parse(value));
            }

            return partValues;
        }
    }
}
