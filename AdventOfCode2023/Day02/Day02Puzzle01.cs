using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day02
{
    public class Day02Puzzle01
    {
        public void Calculation()
        {
            string[] filePath = ReadFile("C:\\Users\\vlasi\\Downloads\\input.txt");

            int finalAnswer = CalculateAnswer(filePath);
            Console.WriteLine($"Day 01 Puzzle 02 Result: {finalAnswer}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private int CalculateAnswer(string[] filePath)
        {
            return -1;
        }

    }
}
