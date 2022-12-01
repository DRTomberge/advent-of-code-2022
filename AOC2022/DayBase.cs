using System;

namespace AOC2022;

internal abstract class DayBase
{
    protected readonly string assetsDirectory = Environment.CurrentDirectory;

    public DayBase(string assetsDirectory)
	{
        this.assetsDirectory = assetsDirectory ?? Environment.CurrentDirectory;
    }

    public virtual void Run(int part)
    {
        Console.WriteLine("Start task");
        if (part == 1)
            ExecuteTask1();
        else
            ExecuteTask2();
        Console.WriteLine("Finished task");
    }

    public virtual void ExecuteTask1()
    {
    }

    public virtual void ExecuteTask2()
    {
    }
}
