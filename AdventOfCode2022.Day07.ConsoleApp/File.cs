
namespace AdventOfCode2022.Day07.ConsoleApp
{
    public class File : INode
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }

        public File(int level, string name, int size)
        {
            Level = level;
            Name = name;
            Size = size;
        }
    }
}
