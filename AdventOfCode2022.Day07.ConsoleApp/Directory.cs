namespace AdventOfCode2022.Day07.ConsoleApp
{
    public class Directory : INode
    {
        public string Name { get; set; }
        public List<INode> Children { get; set; }
        public Directory Parent { get; set; }

        public int TotalSize => Children.Where(c => c is File).Sum(s => (s as File).Size) + 
            Children.Where(c => c is Directory).Sum(s => (s as Directory).TotalSize);

        public Directory(string name, Directory parent)
        {
            Name = name;
            Children = new List<INode>();
            Parent = parent;
        }

        public void AddFile(File file)
        {
            Children.Add(file);
        }

        public void AddDirectory(Directory directory)
        {
            Children.Add(directory);
        }

        public Directory GetDirectory(string name)
        {
            var directory = this;

            if (name == Name)
                return directory;

            foreach (var child in Children)
            {
                if (child is Directory)
                {
                    directory = (child as Directory).GetDirectory(name);

                    if (directory.Name == name)
                        break;
                }
            }

            return directory;
        }

        public new string ToString()
        {
            return Name;

        }
    }
}
