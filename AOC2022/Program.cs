using System;
using System.Diagnostics;
using System.IO;
using AOC2022;

//Assets directory
int dayToRun = 1;
string dir = Path.Combine(Environment.CurrentDirectory, "assets");
Console.WriteLine($"Started for day {dayToRun}; Asset dir: {dir}");

Stopwatch stopwatch = new Stopwatch();

//Day 1
if (dayToRun == 1)
{
    Day01 day01 = new Day01(dir);
    stopwatch.Start();
    day01.Run();
    stopwatch.Stop();
}

Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds.ToString()}ms" + Environment.NewLine);
Console.WriteLine("Done");
Console.Read();