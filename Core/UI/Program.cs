using Poker.Core.Models;
using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Deck deck = new Deck();
        ScoreBoard board = new ScoreBoard();

        deck.ShuffleCards();

        ShowUI(board, deck);
    }
    public static void ShowUI(ScoreBoard board, Deck deck)
    {
        Console.Clear();
        board.ShowScoreBoardTop();
        deck.ShowHandCard();
        board.ShowScoreBoardBottom();
    }
}