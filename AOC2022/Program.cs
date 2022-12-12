using System;
using System.Diagnostics;
using System.IO;
using AOC2022;

//Assets directory
int dayToRun = 7;
string dir = Path.Combine(Environment.CurrentDirectory, "assets");
Console.WriteLine($"Started for day {dayToRun}; Asset dir: {dir}");

Stopwatch stopwatch = new Stopwatch();

//Get class to activate
string typeName = $"AOC2022.Day{dayToRun.ToString("00")}";
DayBase? day = Activator.CreateInstance(Type.GetType(typeName), new object[] { dir }) as DayBase;

if (day != null)
{
    stopwatch.Start();
    day.Run(2);
    stopwatch.Stop();
}

Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds.ToString()}ms" + Environment.NewLine);
Console.WriteLine("Done");
Console.Read();