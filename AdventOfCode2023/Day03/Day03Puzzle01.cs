using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdventOfCode2023.Day02
{
    public class Day03Puzzle01 : IPuzzle
    {
        public void Calculation()
        {
            string[] puzzleInput = ReadFile(@"C:\Users\vlasi\Desktop\Main Files\Projects\Code Base\Console\AdventOfCode2023\AdventOfCode2023 Inputs\inputDay03.txt");

            // Calculate the sum of part numbers
            int finalAnswer = CalculateAnswer(puzzleInput);

            Console.WriteLine($"Puzzle 01 Result: {finalAnswer}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }


        private int CalculateAnswer(string[] fileData)
        {
            // I know same loop as in puzzle of Day 01 but with vanila loop to be able to get previous and next row
            int totalValue = 0;

            for (int i = 0; i < fileData.Length; i++)
            {
                totalValue += GetAllPartNumbers(fileData[i - 1], fileData[i], fileData[i + 1]);
            }

            return totalValue;
        }

        private int GetAllPartNumbers(string previousRow, string currentRow, string nextRow)
        {
            int symbolIndex = FindSymbolIndex(currentRow);
            if (symbolIndex >= 0)
            {

            }

            return 0;
        }

        private int FindPartNumbers()
        {

        }

        private int FindSymbolIndex(string input)
        {
            string pattern = @"[!@#$%^&*()_+{}\[\]:;<>,.?~\\/\-|=]";

            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                return match.Index;
            }

            return -1;
        }
    }
}
