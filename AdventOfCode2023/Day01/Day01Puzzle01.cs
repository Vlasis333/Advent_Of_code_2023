namespace AdventOfCode2023
{
    public class Day01Puzzle01 : IPuzzle
    {
        public void Initialize()
        {
            // For you to work just by copy paste you need to get your own input and paste it to a txt file (named input daa :P)
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay01.txt")));

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static int CalculateAnswer(string[] fileData)
        {
            int totalValue = 0;

            foreach (string line in fileData)
            {
                int firstDigit = FindFirstDigit(line);
                int lastDigit = FindLastDigit(line);

                int currentLineValue = int.Parse(firstDigit.ToString() + lastDigit.ToString());
                totalValue += currentLineValue;
            }

            return totalValue;
        }

        private static int FindFirstDigit(string line)
        {
            // Basic and simple -> Faster results -> More points hehe
            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    return int.Parse(c.ToString());
                }
            }

            return -1;
        }

        private static int FindLastDigit(string line)
        {
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    return int.Parse(line[i].ToString());
                }
            }

            return -1;
        }

    }
}
