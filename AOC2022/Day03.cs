using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AOC2022;

internal class Day03 : DayBase
{
	public Day03(string assetsDirectory) : base(assetsDirectory)
    {
    }

    public override void ExecuteTask1()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day03_input.txt"));

        int total = 0;
        for (int i = 0; i < rows.Length; i++)
        {
            string firstPart = rows[i].Substring(0, Convert.ToInt32(rows[i].Length / 2));
            IEnumerable<char> results = firstPart.ToCharArray().Intersect(rows[i].Substring(firstPart.Length).ToCharArray());
            if (results != null && results.Count() > 0)
            {
                byte number = Encoding.ASCII.GetBytes(results.ToArray(), 0, 1).First();
                total += Char.IsAsciiLetterLower(results.First()) ? number - 96 : number - 38;
            }
        }
        Console.WriteLine($"Total: {total}");
    }

    public override void ExecuteTask2()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day03_input.txt"));

        int total = 0;
        for (int i = 0; i < rows.Length; i++)
        {
            char[] firstPart = rows[i].ToCharArray();
            IEnumerable<char> results = firstPart.Intersect(rows[++i].ToCharArray()).Intersect(rows[++i].ToCharArray());
            if (results != null && results.Count() > 0)
            {
                byte number = Encoding.ASCII.GetBytes(results.ToArray(), 0, 1).First();
                total += Char.IsAsciiLetterLower(results.First()) ? number - 96 : number - 38;
            }
        }
        Console.WriteLine($"Total: {total}");
    }
}