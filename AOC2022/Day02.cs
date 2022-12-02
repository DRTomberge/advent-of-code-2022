using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022;

internal class Day02 : DayBase
{
    private Dictionary<int, int> rounds = new Dictionary<int, int>();

    private Dictionary<string, int> point = new Dictionary<string, int> {
        { "A", 1 }, //Rock
        { "B", 2 }, //Paper
        { "C", 3 }, //Scissors
        { "X", 1 }, //Rock
        { "Y", 2 }, //Paper
        { "Z", 3 }, //Scissors
    };
    private Dictionary<string, int> point2 = new Dictionary<string, int> {
        { "A", 1 }, //Rock
        { "B", 2 }, //Paper
        { "C", 3 }, //Scissors
        { "X", 0 }, //Rock
        { "Y", 3 }, //Paper
        { "Z", 6 }, //Scissors
    };

    public Day02(string assetsDirectory) : base(assetsDirectory)
    {
    }

    public override void ExecuteTask1()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day02_input.txt"));

        RPS? roPaSc = null;
        int totalScore = 0;
        for (int i = 0; i < rows.Length; i++)
        {
            roPaSc = new RPS(point[rows[i][0].ToString()], point[rows[i][2].ToString()]);
            totalScore += roPaSc.GetScore();
        }
        Console.WriteLine($"Total score: {totalScore};");
    }

    public override void ExecuteTask2()
    {
        //Read input
        string[] rows = File.ReadAllLines(Path.Combine(this.assetsDirectory, "Day02_input.txt"));

        RPS? roPaSc = null;
        int totalScore = 0;
        for (int i = 0; i < rows.Length; i++)
        {
            roPaSc = new RPS(point2[rows[i][0].ToString()], 0, point2[rows[i][2].ToString()]);
            totalScore += roPaSc.GetNewScore();
        }
        Console.WriteLine($"Total score: {totalScore};");
    }
}

//RockPaperScissor
internal class RPS
{
    private const int Draw = 3;
    private const int Win = 6;

    public int OpponentScore { get; set; }
    public int MineScore { get; set; }
    public int Outcome { get; set; }

    public RPS(int opponentScore, int mineScore)
    {
        OpponentScore = opponentScore;
        MineScore = mineScore;
    }
    public RPS(int opponentScore, int mineScore, int outcome)
    {
        OpponentScore = opponentScore;
        MineScore = mineScore;
        Outcome = outcome;
    }

    /// <summary>
    /// Rock(1) defeats Scissors(3), Scissors(3) defeats Paper(2), and Paper(2) defeats Rock(1)
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        int score = 0;

        if (OpponentScore == MineScore)
            score = Draw;
        //Rock
        else if (OpponentScore == 1 && MineScore == 2)
            score = Win;
        //Paper
        else if (OpponentScore == 2 && MineScore == 3)
            score = Win;
        //Scissors
        else if (OpponentScore == 3 && MineScore == 1)
            score = Win;

        return score + MineScore;
    }

    public int GetNewScore()
    {
        int score = 0;

        if (Outcome == Draw)
            score = Draw + OpponentScore;
        else if (Outcome == Win)
        {
            if (OpponentScore == 1) //Rock
                MineScore = 2;
            else if (OpponentScore == 2) //Paper
                MineScore = 3;
            if (OpponentScore == 3) //Scissors
                MineScore = 1;
            score = Win + MineScore;
        }
        else if (Outcome == 0)
        {
            if (OpponentScore == 1) //Rock
                MineScore = 3;
            else if (OpponentScore == 2) //Paper
                MineScore = 1;
            else if (OpponentScore == 3) //Scissors
                MineScore = 2;
            score = MineScore;
        }
        return score;
    }
}