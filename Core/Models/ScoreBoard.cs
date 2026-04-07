using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Models
{
    public class ScoreBoard
    {
        public int ScoreGoal { get; set; } = 200;
        public int ActualScore { get; set; } = 0;
        public int Multiplier { get; set; } = 1;
        public int Hands { get; set; } = 3;
        public int Discards { get; set; } = 3;

        public ScoreBoard()
        {            
        }
        public void ShowScoreBoardTop()
        {
            Console.WriteLine($"Goal: {ScoreGoal}p");
            Console.WriteLine($"Score: {ActualScore}p");
            Console.WriteLine($"Multiplier: {Multiplier}x");
        }
        public void ShowScoreBoardBottom()
        {
            Console.WriteLine($"Hands: {Hands}");
            Console.WriteLine($"Discards: {Discards}");
        }
    }
}
