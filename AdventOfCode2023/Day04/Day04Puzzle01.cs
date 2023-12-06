namespace AdventOfCode2023
{

    public class Day04Puzzle01 : IPuzzle
    {
        // Used to save all the numbers and find the score
        private static readonly List<(int[] leftNumbers, int[] rightNumbers)> Cards = new();

        public void Calculation()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay04.txt")));

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static int CalculateAnswer(string[] fileData)
        {
            PopulateCardsEntity(fileData);

            int totalValue = 0;
            for (int cardIndex = 0; cardIndex < Cards.Count; cardIndex++)
            {
                var (leftNumbers, rightNumbers) = Cards[cardIndex];
                int score = CalculateCurrentCommonCards(leftNumbers, rightNumbers);

                totalValue += score;
            }

            return totalValue;
        }

        private static void PopulateCardsEntity(string[] fileData)
        {
            // Again very typical same loop :P
            foreach (string line in fileData)
            {
                string currentLine = string.Join(' ', line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string[] numbersData = currentLine.Split(": ")[1].Split(" | ");

                int[] leftNumbers = GetNumbersFromString(numbersData[0].Split(' '));
                int[] rightNumbers = GetNumbersFromString(numbersData[1].Split(' '));

                Cards.Add((leftNumbers, rightNumbers));
            }
        }

        private static int CalculateCurrentCommonCards(int[] leftNumbers, int[] rightNumbers)
        {
            var commonNumbers = rightNumbers.Intersect(leftNumbers).ToArray();
            return (commonNumbers.Length > 0) ? (int)Math.Pow(2, commonNumbers.Length - 1) : 0;
        }

        private static int[] GetNumbersFromString(string[] arr)
        {
            // Convert string to int
            return arr.Select(int.Parse).ToArray();
        }
    }
}