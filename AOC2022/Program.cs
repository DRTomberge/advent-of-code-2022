using System;
using System.Diagnostics;
using System.IO;
using AOC2022;

//Assets directory
int dayToRun = 2;
string dir = Path.Combine(Environment.CurrentDirectory, "assets");
Console.WriteLine($"Started for day {dayToRun}; Asset dir: {dir}");

Stopwatch stopwatch = new Stopwatch();

//Day 1
if (dayToRun == 1)
{
    Day01 day01 = new Day01(dir);
    stopwatch.Start();
    day01.Run(2);
    stopwatch.Stop();
}
//Day 2
else if (dayToRun == 2)
{
    Day02 day02 = new Day02(dir);
    stopwatch.Start();
    day02.Run(2);
    stopwatch.Stop();
}

Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds.ToString()}ms" + Environment.NewLine);
Console.WriteLine("Done");
Console.Read();