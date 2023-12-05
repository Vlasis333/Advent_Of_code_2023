namespace AdventOfCode2023
{
    public class Day04Puzzle02 : IPuzzle
    {
        // Same as part 1, byt added cardId and a count of copies
        private static readonly List<(int id, int[] leftNumbers, int[] rightNumbers, int countOfCopies)> Cards = new();

        public void Calculation()
        {
            string[] puzzleInput = ReadFile(@"C:\Users\vlasi\Desktop\Main Files\Projects\Code Base\Console\AdventOfCode2023\AdventOfCode2023 Inputs\inputDay04.txt");

            Console.WriteLine($"Puzzle 02 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static int CalculateAnswer(string[] fileData)
        {
            PopulateCardsEntity(fileData);

            return CalculateFinalScore();
        }

        private static void PopulateCardsEntity(string[] fileData)
        {
            // Same as part 1, but this time we also add the IDs and the count of copies
            foreach (string line in fileData)
            {
                string currentLine = string.Join(' ', line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string[] cardData = currentLine.Split(": ");
                string[] numbersData = cardData[1].Split(" | ");

                int cardId = int.Parse(cardData[0].Remove(0, 5));
                int[] leftNumbers = GetNumbersFromString(numbersData[0].Split(' '));
                int[] rightNumbers = GetNumbersFromString(numbersData[1].Split(' '));

                Cards.Add((cardId, leftNumbers, rightNumbers, 1));
            }
        }

        private static int CalculateFinalScore()
        {
            for (int cardIndex = 0; cardIndex < Cards.Count; cardIndex++)
            {
                var (_, leftNumbers, rightNumbers, count) = Cards[cardIndex];

                for (int i = 1; i <= CalculateCurrentCommonCards(leftNumbers, rightNumbers); i++)
                {
                    int copyIndex = cardIndex + i;
                    if (copyIndex >= Cards.Count)
                        break;

                    Cards[copyIndex] = (Cards[copyIndex].id, Cards[copyIndex].leftNumbers, Cards[copyIndex].rightNumbers, Cards[copyIndex].countOfCopies + count);
                }
            }
            return Cards.Sum(card => card.countOfCopies);
        }

        private static int CalculateCurrentCommonCards(int[] leftNumbers, int[] rightNumbers)
        {
            // Same as part 1, but this time we do not care about the score only for the count
            return rightNumbers.Intersect(leftNumbers).Count();
        }

        private static int[] GetNumbersFromString(string[] arr)
        {
            // Same as part 1
            return arr.Select(int.Parse).ToArray();
        }
    }
}