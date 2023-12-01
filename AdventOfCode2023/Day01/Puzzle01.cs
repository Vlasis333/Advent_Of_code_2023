namespace AdventOfCode2023.Day01
{
    public class Puzzle01
    {
        public void Calculation()
        {
            // For you to work just by copy paste you need to get your own input and paste it to a txt file (named input daa :P)
            string[] filePath = ReadCalibrationFile("C:\\Users\\vlasi\\Downloads\\input.txt");

            int totalCalibration = CalculateTotalCalibration(filePath);
            Console.WriteLine($"Day 01 Puzzle 01 Result: {totalCalibration}");

            // To keep the command line open
            Console.ReadLine();
        }

        private static string[] ReadCalibrationFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private int CalculateTotalCalibration(string[] calibrationDocument)
        {
            int totalCalibration = 0;

            foreach (string line in calibrationDocument)
            {
                int firstDigit = FindFirstDigit(line);
                int lastDigit = FindLastDigit(line);

                int calibrationValue = firstDigit * 10 + lastDigit;
                totalCalibration += calibrationValue;
            }

            return totalCalibration;
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
