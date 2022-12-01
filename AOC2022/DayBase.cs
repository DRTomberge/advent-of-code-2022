using System;

namespace AOC2022;

internal abstract class DayBase
{
    protected readonly string assetsDirectory = Environment.CurrentDirectory;

    public DayBase(string assetsDirectory)
	{
        this.assetsDirectory = assetsDirectory ?? Environment.CurrentDirectory;
    }

    public virtual void Run()
    {
        Console.WriteLine("Start task");
        ExecuteTask();
        Console.WriteLine("Finished task");
    }

    public virtual void ExecuteTask()
    {
    }
}
