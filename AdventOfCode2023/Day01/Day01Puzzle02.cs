namespace AdventOfCode2023
{
    public class Day01Puzzle02 : IPuzzle
    {
        public void Initialize()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay01.txt")));

            Console.WriteLine($"Puzzle 02 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static int CalculateAnswer(string[] fileData)
        {
            List<int> lineValues = new ();

            foreach (var line in fileData)
            {
                int firstNumericDigit = 0, lastNumericDigit = 0, indexFirstFoundOn = line.Length, indexLastFoundOn = 0;

                for (int i = 0; i < line.Length; ++i)
                {
                    int c = line[i];
                    if (c >= '1' && c <= '9') 
                    {
                        firstNumericDigit = (int)Char.GetNumericValue((char)c);
                        indexFirstFoundOn = i;
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; --i)
                {
                    int c = line[i];
                    if (c >= '1' && c <= '9')
                    {
                        lastNumericDigit = (int)Char.GetNumericValue((char)c);
                        indexLastFoundOn = i;
                        break;
                    }
                }

                // By ref so we can update the value (and not pass copies of the variables)
                // IMPROVEMENT: make it better performance wise with fewer loops
                SearchAndSet(line, "one", 1, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);
                SearchAndSet(line, "two", 2, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);
                SearchAndSet(line, "three", 3, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);
                SearchAndSet(line, "four", 4, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);
                SearchAndSet(line, "five", 5, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);
                SearchAndSet(line, "six", 6, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);
                SearchAndSet(line, "seven", 7, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);
                SearchAndSet(line, "eight", 8, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);
                SearchAndSet(line, "nine", 9, ref firstNumericDigit, ref indexFirstFoundOn, ref lastNumericDigit, ref indexLastFoundOn);

                lineValues.Add(int.Parse(firstNumericDigit.ToString() + lastNumericDigit.ToString()));
            }

            return lineValues.Sum();
        }

        private static void SearchAndSet(string line, string word, int value, ref int firstNumericDigit, ref int indexFirstFoundOn, ref int lastNumericDigit, ref int indexLastFoundOn)
        {
            // A dum way to check if we have numbers (in text) between the 2 digits found, if yes we replace the values on the referece of the corresponding integer
            int iFirstPosition = line.IndexOf(word, StringComparison.Ordinal);
            if (iFirstPosition != -1 && iFirstPosition < indexFirstFoundOn)
            {
                firstNumericDigit = value;
                indexFirstFoundOn = iFirstPosition;
            }

            int iLastPosition = line.LastIndexOf(word, StringComparison.Ordinal);
            if (iLastPosition != -1 && iLastPosition > indexLastFoundOn)
            {
                lastNumericDigit = value;
                indexLastFoundOn = iLastPosition;
            }
        }

    }
}
