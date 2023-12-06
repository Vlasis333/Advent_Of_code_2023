namespace AdventOfCode2023
{
    public class Day03Puzzle01 : IPuzzle
    {
        public void Calculation()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay03.txt")));

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static int CalculateAnswer(string[] fileData)
        {
            List<int> partValues = new();
            HashSet<(int, int)> partCoordinates = new();

            for (int row = 0; row < fileData.Length; row++)
            {
                for (int col = 0; col < fileData[row].Length; col++)
                {
                    char currentChar = fileData[row][col];

                    // Skip digits and dots
                    if (char.IsDigit(currentChar) || currentChar == '.')
                    {
                        continue;
                    }

                    FindAdjacentParts(fileData, ref partCoordinates, row, col);
                }
            }

            ExtractPartValues(fileData, partCoordinates, ref partValues);

            return partValues.Sum();
        }

        private static void FindAdjacentParts(string[] fileData, ref HashSet<(int, int)> partCoordinates, int row, int col)
        {
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
        }

        private static bool IsValidPartCoordinate(string[] fileData, int row, int col)
        {
            return row >= 0 && row < fileData.Length && col >= 0 && col < fileData[row].Length && char.IsDigit(fileData[row][col]);
        }

        private static int AdjustColumnToPart(string[] fileData, int row, int col)
        {
            int currentColumn = col;

            while (currentColumn > 0 && char.IsDigit(fileData[row][currentColumn - 1]))
            {
                currentColumn--;
            }

            return currentColumn;
        }

        private static void ExtractPartValues(string[] fileData, HashSet<(int, int)> partCoordinates, ref List<int> partValues)
        {
            foreach ((int row, int col) in partCoordinates)
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
        }
    }
}
