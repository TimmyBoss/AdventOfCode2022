using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day07.ConsoleApp
{
    internal class FileSystemCalculator : ITask
    {
        private Directory _directory = new Directory("/", null);
        public List<int> _directorySizes = new List<int>();

        public string GetAnswer1()
        {
            GetTotalSize(_directory);
            var amount = _directorySizes.Where(s => s < 100000).Sum();
            return amount.ToString();
        }

        public string GetAnswer2()
        {
            return "";
        }

        private void GetTotalSize(Directory directory)
        {
            foreach (var child in directory.Children)
            {
                if (child is Directory)
                {
                    var size = (child as Directory).TotalSize;
                    _directorySizes.Add(size);
                    GetTotalSize((child as Directory));
                }
            }
        }

        public void SetupPuzzleInput(List<string> puzzleInput)
        {
            var directory = new Directory("/", null);
            Directory currentNode = directory;

            foreach (var line in puzzleInput)
            {
                Console.WriteLine(line);
                var instruction = line.Split(" ");

                if (instruction[0] == "$")
                {
                    if (instruction[1] == "cd")
                    {
                        currentNode = instruction[2] == ".." ?
                            currentNode.Parent != null ? currentNode.Parent : _directory.GetDirectory(instruction[2]) :
                           _directory.GetDirectory(instruction[2]);
    
                    }
                }
                else
                {
                    if (instruction[0] == "dir")
                        currentNode.AddDirectory(new Directory(instruction[1], currentNode));
                    else
                    {
                        var size = Convert.ToInt32(instruction[0]);
                        currentNode.AddFile(new File(instruction[1], size));
                    }
                }
            }

            _directory = currentNode.Parent;
        }
    }
}
