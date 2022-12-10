using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022
{
    internal class Day7
    {
        internal class DirFile
        {
            public int Size { get; set; }
            public string Name { get; set; }
            public DirFile(int size, string name)
            {
                Size = size;
                Name = name;
            }
        }

        internal class Dir
        {
            public string Name { get; set; }
            public List<DirFile> Files { get; set; }
            public List<Dir> Directories { get; set; }

            public Dir? Parent { get; set; }

            public int DirSize { get => Directories.Select(x => x.DirSize).Sum() + FileSum; }

            public int FileSum { get => Files.Select(x => x.Size).Sum(); }

            public Dir(string name, Dir? parent)
            {
                Name = name;
                Files = new List<DirFile>() { };
                Directories = new List<Dir>() { };
                Parent = parent;
            }
        }

        public void Run()
        {
            List<Dir> dirs = new List<Dir> { };
            var input = File.ReadAllLines("input/input_d7.txt");
            //var input = File.ReadAllLines(@"C:\Users\maste\Downloads\test_d7.txt");
            Dir root = new Dir("/", null);
            Dir currentDir = root;
            dirs.Add(root);
            foreach(var line in input.Skip(1))
            {
                if(line[0]  == '$')
                {
                    if (line.Contains("cd"))
                    {
                        var fold = line.Substring(4).Trim();
                        if (fold == "..")
                        {
                            try
                            {
                                currentDir = currentDir.Parent;
                            }
                            catch (Exception) { }
                            
                        }
                        else
                        {
                            var existingFold = currentDir.Directories.FirstOrDefault(d => d.Name == fold);
                            if (existingFold == null)
                            {
                                Console.WriteLine($"No folder {fold}");
                                break;
                            }
                            currentDir = existingFold;
                        }
                        
                    }
                }
                else
                {
                    if (line.StartsWith("dir"))
                    {
                        var dir = new Dir(line.Substring(4).Trim(), currentDir);
                        currentDir.Directories.Add(dir);
                        dirs.Add(dir);
                    }
                    else
                    {
                        var split = line.Split(' ');
                        currentDir.Files.Add(new DirFile(int.Parse(split[0]), split[1]));
                    }
                }
            }
            
            Console.WriteLine(Part1(dirs));
            Console.WriteLine(Part2(dirs));
        }

        public int Part1(List<Dir> dirs)
        {
            int sum = 0;
            foreach (var dir in dirs)
            {
                if (dir.DirSize <= 100000)
                {
                    sum += dir.DirSize;
                }
            }

            return sum;
        }

        public int Part2(List<Dir> dirs)
        {
            var total = 70000000 - dirs[0].DirSize;
            var tooFree = 30000000 - total;

            var suggested = dirs.Where(x => x.DirSize >= tooFree).OrderByDescending(x => x.DirSize).ToList();

            return suggested.Last().DirSize;
        }
    }
}
