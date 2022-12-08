using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2022;

internal class Day07 : DayBase
{
    private int maxSize = 100000;

    public Day07(string assetsDirectory) : base(assetsDirectory)
	{
	}

    public override void ExecuteTask1()
	{
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day07_input.txt"));

		Dir root = new Dir(0, "root");
		Dir currentDir = root;
        for (int i = 0; i < rows.Length; i++)
		{
			if (rows[i].StartsWith("$ cd .."))
			{
				//level back
				currentDir = currentDir.ParentDir;
				continue;
            }

            if (rows[i].StartsWith("dir "))
            {
				Dir newDir = new Dir(currentDir.Level + 1, rows[i].Replace("dir ", "").Trim());
				newDir.ParentDir = currentDir;
				currentDir.Dirs.Add(newDir);
            }
            else if (Regex.IsMatch(rows[i], "[$] cd ([a-z]+)"))
			{
				string name = rows[i].Replace("$ cd ", "").Trim();
				if (currentDir.ContainsDir(name, out int index))
					currentDir = currentDir.Dirs[index];
			}
			else if (Regex.IsMatch(rows[i], "([0-9]+)"))
			{
				string value = Regex.Match(rows[i], "[0-9]*").Value;
				if (int.TryParse(value, out int size))
					currentDir.AddFile(rows[i].Substring(value.Length).Trim(), size);
			}
		}
		int totalFileSize = CountTotalSize(root);
        Console.WriteLine($"Result: {totalFileSize}");
    }

	public override void ExecuteTask2()
	{

	}

	internal int CountTotalSize(Dir dir)
	{
		int totalSize = (dir.TotalFileSize > maxSize) ? 0 : dir.TotalFileSize;
        Console.WriteLine($"- {"".PadLeft(dir.Level, ' ')}{dir.Name}, size={dir.TotalFileSize}");
        for (int i = 0; i < dir.Dirs.Count; i++)
        {
            totalSize += CountTotalSize(dir.Dirs[i]);
        }
        for (int j = 0; j < dir.Files.Count; j++)
            Console.WriteLine($"  {"".PadLeft(dir.Level, ' ')} - {dir.Files.ElementAt(j).Key}, size={dir.Files.ElementAt(j).Value}");
        Console.WriteLine($"= {"".PadLeft(dir.Level, ' ')}(dir {dir.Name}, totalsize: {totalSize})");
        return totalSize;
    }

	internal class Dir 
	{
        public int Level { get; set; } = 0;

		public string Name { get; set; }

		public List<Dir> Dirs { get; set; } = new List<Dir>();

		public Dir? ParentDir { get; set; }

		public Dictionary<string, int> Files = new Dictionary<string, int>();

        public int TotalFileSize { get; private set; } = 0;

		//Constructor
		public Dir(int level, string name)
		{
			this.Level = level;
			this.Name = name;
		}

		public bool ContainsDir(string name, out int index)
		{
			index = this.Dirs.FindIndex(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
			return index != -1;
		}

		public void AddFile(string name, int size)
		{
			this.Files.Add(name, size);
			this.TotalFileSize += size;
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Dirs.Count})";
		}
    }
}
