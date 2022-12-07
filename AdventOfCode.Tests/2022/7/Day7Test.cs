using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests._2022._7
{
    public class Day7Test : TestBase
    {
        public Day7Test() : base(2022, 7)
        {
        }

        protected override int ExpectedResultPart1 => 95437;
        protected override int ExpectedResultPart2 => 24933642;

        protected override int Calculate(string[] data)
        {
            var directories = BuildFileSystem(data);

            return directories
                .Select(x => x.Size())
                .Where(x => x < 100000)
                .Sum(x => x);
        }

        private static List<Directory> BuildFileSystem(string[] data)
        {
            var directories = new List<Directory>();
            var root = new Directory("/", null);
            directories.Add(root);
            var currentDir = root;
            foreach (var line in data)
                if (line.StartsWith("$ cd "))
                {
                    var path = line.Remove(0, "$ cd ".Length);
                    currentDir = GoToDirectory(currentDir, path, root);
                }
                else if (line == "$ ls")
                {
                    // ignore
                }
                else
                {
                    if (line.StartsWith("dir"))
                    {
                        // it's a dir
                        var dir = new Directory(line.Remove(0, "dir ".Length), currentDir);
                        currentDir.Add(dir);
                        directories.Add(dir);
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
            return directories;
        }

        private static Directory GoToDirectory(Directory currentDir, string path, Directory root)
        {
            currentDir = path switch
            {
                "/" => root,
                ".." => currentDir.GoUp(),
                _ => currentDir.GoTo(path)
            };
            return currentDir;
        }

        protected override int Calculate2(string[] data)
        {
            var directories = BuildFileSystem(data);
            var rootSize = directories.Single(x => x.Name == "/").Size();
            var currentFreeSpace = 70000000 - rootSize;

            var sizes = directories.Select(x => x.Size()).OrderBy(x => x);

            return sizes.FirstOrDefault(size => currentFreeSpace + size > 30000000);
        }

        [Fact]
        public void File_ReturnsSize()
        {
            var file = new File("test", 10);

            Assert.Equal(10, file.Size());
        }

        [Fact]
        public void Directory_OnlyFiles_ReturnsSize()
        {
            var dir = new Directory("test", null);
            dir.Add(new File("a", 10));
            dir.Add(new File("b", 20));

            Assert.Equal(30, dir.Size());
        }

        [Fact]
        public void Directory_FilesAndSubdirectories_ReturnsSize()
        {
            var dir = new Directory("test", null);
            var subdir = new Directory("sub", dir);
            dir.Add(new File("a", 10));
            dir.Add(subdir);
            subdir.Add(new File("b", 20));

            Assert.Equal(30, dir.Size());
        }

        public abstract class FileSystemNode
        {
            protected FileSystemNode(string name)
            {
                Name = name;
            }

            public string Name { get; }
            public abstract int Size();
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

            public override int Size()
            {
                return _children.Values.Sum(x => x.Size());
            }
        }

        public class File : FileSystemNode
        {
            private readonly int _size;

            public File(string name, int size) : base(name)
            {
                _size = size;
            }

            public override int Size() => _size;

            public override string ToString()
            {
                return $"{Name} (file, size={_size})";
            }
        }
    }
}
