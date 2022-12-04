using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AOC2022.Day04;

namespace AOC2022;

internal class Day05 : DayBase
{
	public Day05(string assetsDirectory) : base(assetsDirectory)
    {
	}

    public override void ExecuteTask1()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day05_input.txt"));

        for (int i = 0; i < rows.Length; i++)
        {
        }
        Console.WriteLine($"Result:");
    }

    public override void ExecuteTask2()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day05_input.txt"));

        for (int i = 0; i < rows.Length; i++)
        {
        }
        Console.WriteLine($"Result:");
    }
}
