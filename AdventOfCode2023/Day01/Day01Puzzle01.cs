using System.Collections.Generic;

namespace AdventOfCode2023.Day01
{
    public class Day01Puzzle01
    {
        public void Calculation()
        {
            // For you to work just by copy paste you need to get your own input and paste it to a txt file (named input daa :P)
            string[] filePath = ReadFile("C:\\Users\\vlasi\\Downloads\\input.txt");

            int finalAnswer = CalculateAnswer(filePath);
            Console.WriteLine($"Day 01 Puzzle 01 Result: {finalAnswer}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private int CalculateAnswer(string[] fileData)
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

            return -1; // If no digit is found
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

            return -1; // If no digit is found
        }

    }
}
