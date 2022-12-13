namespace AdventOfCode2022.Day07.ConsoleApp
{
    public class Directory : INode
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public List<INode> Children { get; set; }
        public Directory Parent { get; set; }

        public int TotalSize => Children.Where(c => c is File).Sum(s => (s as File).Size) + 
            Children.Where(c => c is Directory).Sum(s => (s as Directory).TotalSize);

        public Directory(string name, Directory parent, int level)
        {
            Level = level;
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

        public Directory GetRoot()
        {
            if (Parent != null)
            {
                return Parent.GetRoot();
            }

            return this;
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

        public void WriteStructure()
        {
            foreach (var child in Children)
            {
                var indent = "";

                for (int i = 0; i <= child.Level; i++)
                    indent += " ";

                Console.WriteLine(indent + " - " + child.Name);
                if (child is Directory)
                    ((Directory)child).WriteStructure();

            }
        }

        public new string ToString()
        {
            return Name;

        }
    }
}
