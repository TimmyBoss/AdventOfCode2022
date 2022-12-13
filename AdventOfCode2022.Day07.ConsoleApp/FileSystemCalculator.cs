using AdventOfCode2022.Shared;

namespace AdventOfCode2022.Day07.ConsoleApp
{
    internal class FileSystemCalculator : ITask
    {
        private Directory _directory = new Directory("/", null, 0);
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
            var level = 0;
            var directory = new Directory("/", null, level);
            Directory currentNode = directory;

            foreach (var line in puzzleInput)
            {
                var instruction = line.Split(" ");

                if (instruction[0] == "$")
                {
                    if (instruction[1] == "cd")
                    {
                        if (instruction[2] == "..")
                        {
                            level--;
                            currentNode = currentNode.Parent != null ? currentNode.Parent : currentNode;
                        }
                        else
                        {
                            level++;
                            currentNode = _directory.GetDirectory(currentNode.Name + "\\" + instruction[2]);
                        }
                    }
                }
                else
                {
                    if (instruction[0] == "dir")
                        currentNode.AddDirectory(new Directory(currentNode.Name + "\\" + instruction[1], currentNode, level));
                    else
                    {
                        var size = Convert.ToInt32(instruction[0]);
                        currentNode.AddFile(new File(level, instruction[1], size));
                    }
                }
            }

            _directory = currentNode.GetRoot();
        }
    }
}
