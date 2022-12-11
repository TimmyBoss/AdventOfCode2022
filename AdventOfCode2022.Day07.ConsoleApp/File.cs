
namespace AdventOfCode2022.Day07.ConsoleApp
{
    public class File : INode
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public File(string name, int size)
        { 
            Name = name;
            Size = size;
        }
    }
}
