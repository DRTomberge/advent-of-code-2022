using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022;

internal class Day04 : DayBase
{
	public Day04(string assetsDirectory) : base(assetsDirectory)
	{
	}

    public override void ExecuteTask1()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day04_input.txt"));

        int sum = 0;
        for (int i = 0; i < rows.Length; i++)
        {
            Assignment assignment = new Assignment(rows[i].Split(','));
            if ((assignment.SecondRange.Start >= assignment.FirstRange.Start
                && assignment.SecondRange.End <= assignment.FirstRange.End)
               || (assignment.FirstRange.Start >= assignment.SecondRange.Start
                && assignment.FirstRange.End <= assignment.SecondRange.End))
                sum++;
        }
        Console.WriteLine($"Total sum: {sum}");
    }

    public override void ExecuteTask2()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day04_input.txt"));

        int sum = 0;
        for (int i = 0; i < rows.Length; i++)
        {
            Assignment assignment = new Assignment(rows[i].Split(','));
            if ((assignment.SecondRange.Start >= assignment.FirstRange.Start
                 && assignment.SecondRange.Start <= assignment.FirstRange.End)
               || (assignment.FirstRange.Start >= assignment.SecondRange.Start
                 && assignment.FirstRange.Start <= assignment.SecondRange.End)
               || (assignment.SecondRange.End <= assignment.FirstRange.End
                 && assignment.SecondRange.End >= assignment.FirstRange.Start)
               || (assignment.FirstRange.End <= assignment.SecondRange.End
                 && assignment.FirstRange.End >= assignment.SecondRange.Start))
                sum++;
        }
        Console.WriteLine($"Total sum: {sum}");
    }

    internal struct Assignment
    {
        public (int Start, int End) FirstRange = (Start: 0, End: 0);

        public (int Start, int End) SecondRange = (Start: 0, End: 0);

        public Assignment(string[] parts)
        {
            string[] firstParts = parts[0].Split('-');
            if (firstParts.Length >= 1)
                this.FirstRange = (int.Parse(firstParts[0]), int.Parse(firstParts[1]));
            string[] secondParts = parts[1].Split('-');
            if (secondParts.Length >= 1)
                this.SecondRange = (int.Parse(secondParts[0]), int.Parse(secondParts[1]));
        }
    }
}
