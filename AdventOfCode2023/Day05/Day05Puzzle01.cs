namespace AdventOfCode2023
{

    public class Day05Puzzle01 : IPuzzle
    {
        // Used to save all the numbers and find the score
        private static readonly List<(int[] leftNumbers, int[] rightNumbers)> Cards = new();

        public void Calculation()
        {
            string[] puzzleInput = ReadFile(@"C:\Users\vlasi\Desktop\Main Files\Projects\Code Base\Console\AdventOfCode2023\AdventOfCode2023 Inputs\inputDay05.txt");

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static int CalculateAnswer(string[] fileData)
        {
            return 0;
        }

    }
}