namespace AdventOfCode2023
{
    public class Day06Puzzle01 : IPuzzle
    {
        public void Calculation()
        {
            string[] puzzleInput = ReadFile(@"C:\Users\vlasi\Desktop\Main Files\Projects\Code Base\Console\AdventOfCode2023\AdventOfCode2023 Inputs\inputDay06.txt");

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static long CalculateAnswer(string[] fileData)
        {
            return 0;
        }
    }
}
