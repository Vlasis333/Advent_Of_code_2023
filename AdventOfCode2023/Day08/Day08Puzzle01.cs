namespace AdventOfCode2023
{
    public class Day08Puzzle01 : IPuzzle
    {
        enum HandType
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            FullHouse,
            FourOfAKind,
            FiveOfAKind,
        };

        private class HandData
        {
            public string Hand { get; set; }
            public HandType HandType { get; set; }
            public int Weight { get; set; }
            public int Bid { get; set; }
        }

        public void Calculation()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay07.txt")));

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static long CalculateAnswer(string[] fileData)
        {
            int totalValue = 0;
            return totalValue;
        }
    }
}
