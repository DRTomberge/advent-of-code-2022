using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022;

internal class Day06 : DayBase
{
	public Day06(string assetsDirectory) : base(assetsDirectory)
    {
	}

    public override void ExecuteTask1()
    {
        //Read input
        int index = 0;
        char[] source = new char[4];

        string input = File.ReadAllText(Path.Combine(this.assetsDirectory, "Day06_input.txt"));
        do
        {
            source = input.Substring(index, 4).ToArray();
            if (source.Length == source.Distinct().Count())
                break;
            index++;
        } while (index < (input.Length - 4));
        Console.WriteLine($"Result: {index+4}");
    }

    public override void ExecuteTask2()
    {
        //Read input
        int index = 0;
        char[] source = new char[14];

        string input = File.ReadAllText(Path.Combine(this.assetsDirectory, "Day06_input.txt"));
        do
        {
            source = input.Substring(index, 14).ToArray();
            if (source.Length == source.Distinct().Count())
                break;
            index++;
        } while (index < (input.Length - 14));
        Console.WriteLine($"Result: {index + 14}");
    }
}
