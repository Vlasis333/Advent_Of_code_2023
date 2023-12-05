namespace AdventOfCode2023
{
    public class Day05Puzzle02 : IPuzzle
    {
        // Same as part 1, byt added cardId and a count of copies
        private static readonly List<(int id, int[] leftNumbers, int[] rightNumbers, int countOfCopies)> Cards = new();

        public void Calculation()
        {
            string[] puzzleInput = ReadFile(@"C:\Users\vlasi\Desktop\Main Files\Projects\Code Base\Console\AdventOfCode2023\AdventOfCode2023 Inputs\inputDay05.txt");

            Console.WriteLine($"Puzzle 02 Result: {CalculateAnswer(puzzleInput)}");
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