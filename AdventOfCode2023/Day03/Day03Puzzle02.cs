using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day02
{
    public class Day03Puzzle02 : IPuzzle
    {
        public void Calculation()
        {
            string[] puzzleInput = ReadFile(@"C:\Users\vlasi\Desktop\Main Files\Projects\Code Base\Console\AdventOfCode2023\AdventOfCode2023 Inputs\inputDay03.txt");

            int finalAnswer = 0;
            Console.WriteLine($"Puzzle 02 Result: {finalAnswer}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

    }
}
