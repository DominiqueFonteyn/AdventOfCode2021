using System.Collections.Generic;

namespace AdventOfCode.Tests._2022._7
{
    public class Day7Test : TestBase
    {
        public Day7Test() : base(2022, 7)
        {
        }

        protected override int ExpectedResultPart1 => 95437;
        protected override int ExpectedResultPart2 { get; }

        protected override int Calculate(string[] data)
        {
            var root = new Directory("/", null);
            var currentDir = root;
            foreach (var line in data)
                if (line.StartsWith("$ cd "))
                {
                    var path = line.Remove(0, "$ cd ".Length);
                    currentDir = path == "/" ? root : currentDir.GoTo(path);
                }
                else if (line == "$ ls")
                {
                    // ignore
                }
                else
                {
                    if (line.StartsWith("dir"))
                    {
                        // it's  dir
                        currentDir.Add(new Directory(line.Remove(0, "dir ".Length), currentDir));
                    }
                    else
                    {
                        // it's a file
                        var parts = line.Split(' ');
                        var fileName = parts[1];
                        var size = int.Parse(parts[0]);
                        currentDir.Add(new File(fileName, size));
                    }
                }

            return 0;
        }

        protected override int Calculate2(string[] data)
        {
            return 0;
        }

        public abstract class FileSystemNode
        {
            protected FileSystemNode(string name)
            {
                Name = name;
            }

            public string Name { get; }
        }

        public class Directory : FileSystemNode
        {
            private readonly Dictionary<string, FileSystemNode> _children;
            private readonly Directory _parent;

            public Directory(string name, Directory parent) : base(name)
            {
                _children = new Dictionary<string, FileSystemNode>();
                _parent = parent;
            }

            public void Add(FileSystemNode node)
            {
                _children.Add(node.Name, node);
            }

            public Directory GoUp()
            {
                return _parent;
            }

            public Directory GoTo(string directoryName)
            {
                if (!_children.ContainsKey(directoryName))
                {
                    Add(new Directory(directoryName, this));
                }
                return (Directory)_children[directoryName];
            }

            public override string ToString()
            {
                return $"{Name} (dir)";
            }
        }

        public class File : FileSystemNode
        {
            public File(string name, int size) : base(name)
            {
                Size = size;
            }

            public int Size { get; }

            public override string ToString()
            {
                return $"{Name} (file, size={Size})";
            }
        }
    }
}
