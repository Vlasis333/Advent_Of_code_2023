namespace AdventOfCode2023
{
    public class Day08Puzzle01 : IPuzzle
    {
        // Once more I use classes to make the logic easier for me
        public class Node
        {
            public string? Name { get; set; }
            public string[]? Connections { get; set; }
        }

        public class NodeList
        {
            private readonly Dictionary<string, Node> nodes;

            public NodeList()
            {
                nodes = new Dictionary<string, Node>();
            }

            public void AddNode(string name, string[] connections)
            {
                nodes[name] = new Node { Name = name, Connections = connections };
            }

            public string[]? GetNodeConnections(string name)
            {
                return nodes.TryGetValue(name, out Node node) ? node.Connections : Array.Empty<string>();
            }
        }

        public void Initialize()
        {
            string[] puzzleInput = ReadFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Inputs\inputDay08.txt")));

            Console.WriteLine($"Puzzle 01 Result: {CalculateAnswer(puzzleInput)}");
        }

        private static string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private static long CalculateAnswer(string[] fileData)
        {
            NodeList nodesList = new();

            int[] instructions = fileData[0].Select(ParseInstruction).ToArray();
            IEnumerable<string> nodeListArray = fileData.Skip(2);

            // Same typical loop almost all puzzles
            foreach (string node in nodeListArray)
            {
                string[] tokens = node.Split(new[] { ' ', ',', '(', ')', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string nodeName = tokens[0];
                string[] connections = tokens.Skip(1).ToArray();

                nodesList.AddNode(nodeName, connections);
            }

            return CalculateStepsToReachZZZ(nodesList, instructions);
        }

        private static int ParseInstruction(char x)
        {
            // L = 0, else 1
            return x switch
            {
                'L' => 0,
                _ => 1,
            };
        }

        private static long CalculateStepsToReachZZZ(NodeList nodesList, int[] instructions)
        {
            string startNode = "AAA";
            string endNode = "ZZZ";
            long result = 0;

            while (startNode != endNode)
            {
                string[] currentConnections = nodesList.GetNodeConnections(startNode);

                int currentInstruction = instructions[result % instructions.Length];

                startNode = currentConnections[currentInstruction];

                result++;
            }

            return result;
        }
    }
}
