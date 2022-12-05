using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static AOC2022.Day04;
using static AOC2022.Day05;

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

        Cargo cargo = new Cargo(9);
        for (int i = 8; i >= 0; i--)
        {
            char[] stackInput = rows[i].ToCharArray();
            int pos = 1;
            for (int colNr = 0; colNr < cargo.Stacks.Count; colNr++)
            {
                if (char.IsAsciiLetterUpper(stackInput[pos]))
                    cargo.AddToStack(colNr, stackInput[pos]);
                pos += 4;
            }
        }

        for (int i = 10; i < rows.Length; i++)
        {
            Match match = Regex.Match(rows[i], "^[a-z ]*([0-9]+)[a-z ]*([0-9])[a-z ]*([0-9])");
            if (match.Success && match.Groups.Count > 3)
                cargo.Move(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value) - 1, int.Parse(match.Groups[3].Value) - 1);
        }

        for (int colNr = 0; colNr < cargo.Stacks.Count; colNr++)
            Console.WriteLine($"Result: {cargo.Stacks[colNr].Peek()}");
    }

    public override void ExecuteTask2()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day05_input.txt"));

        Cargo cargo = new Cargo(9);
        for (int i = 8; i >= 0; i--)
        {
            char[] stackInput = rows[i].ToCharArray();
            int pos = 1;
            for (int colNr = 0; colNr < cargo.Stacks.Count; colNr++)
            {
                if (char.IsAsciiLetterUpper(stackInput[pos]))
                    cargo.AddToStack(colNr, stackInput[pos]);
                pos += 4;
            }
        }

        for (int i = 10; i < rows.Length; i++)
        {
            Match match = Regex.Match(rows[i], "^[a-z ]*([0-9]+)[a-z ]*([0-9])[a-z ]*([0-9])");
            if (match.Success && match.Groups.Count > 3)
                cargo.MoveMultiple(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value) - 1, int.Parse(match.Groups[3].Value) - 1);
        }

        for (int colNr = 0; colNr < cargo.Stacks.Count; colNr++)
            Console.WriteLine($"Result: {cargo.Stacks[colNr].Peek()}");
    }

    internal class Cargo
    {
        public List<Stack<char>> Stacks = new List<Stack<char>>();

        public Cargo(int numberOfStack)
        {
            for (int i = 0; i < numberOfStack; i++)
            {
                this.Stacks.Add(new Stack<char>());
            }
        }

        public void AddToStack(int stackNr, char crate)
        {
            this.Stacks[stackNr].Push(crate);
        }

        public void Move(int amount, int fromStack, int toStack)
        {
            for (int i = 0; i < amount; i++)
            {
                char crate = Stacks[fromStack].Pop();
                Stacks[toStack].Push(crate);
            }
        }

        public void MoveMultiple(int amount, int fromStack, int toStack)
        {
            if (amount == 1)
            {
                char crate = Stacks[fromStack].Pop();
                Stacks[toStack].Push(crate);
            }
            else
            {
                List<char> creates = new List<char>();
                for (int i = 0; i < amount; i++)
                    creates.Add(Stacks[fromStack].Pop());
                for (int j = (creates.Count-1); j >= 0 ; j--)
                    Stacks[toStack].Push(creates[j]);
            }
        }
    }
}
