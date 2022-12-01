using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022;

internal class Day01 : DayBase
{
	public Day01(string assetsDirectory) : base(assetsDirectory)
	{
	}

	public override void ExecuteTask1()
	{
        int elfCounter = 0;
        int totalCalories = 0;
        Dictionary<int, int> elfs = new Dictionary<int, int>();

        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day01_input.txt"));
        for (int i = 0; i < rows.Length; i++)
        {
            if (int.TryParse(rows[i], out int calorie))
                totalCalories += calorie;
            if (String.IsNullOrEmpty(rows[i]))
            {
                elfs.Add(++elfCounter, totalCalories);
                totalCalories = 0;
            }

        }

        KeyValuePair<int, int> result = elfs.Where(x => x.Value == elfs.Max(x => x.Value)).First();
        Console.WriteLine($"Max: {result.Value}; Key: {result.Key}");
    }

    public override void ExecuteTask2()
    {
        int elfCounter = 0;
        int totalCalories = 0;
        Dictionary<int, int> elfs = new Dictionary<int, int>();

        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day01_input.txt"));
        for (int i = 0; i < rows.Length; i++)
        {
            if (int.TryParse(rows[i], out int calorie))
                totalCalories += calorie;
            if (String.IsNullOrEmpty(rows[i]))
            {
                elfs.Add(++elfCounter, totalCalories);
                totalCalories = 0;
            }

        }

        KeyValuePair<int, int> result1 = elfs.Where(x => x.Value == elfs.Max(x => x.Value)).First();
        elfs.Remove(result1.Key);
        KeyValuePair<int, int> result2 = elfs.Where(x => x.Value == elfs.Max(x => x.Value)).First();
        elfs.Remove(result2.Key);
        KeyValuePair<int, int> result3 = elfs.Where(x => x.Value == elfs.Max(x => x.Value)).First();

        Console.WriteLine($"Total top 3: {result1.Value + result2.Value + result3.Value};");
    }
}
