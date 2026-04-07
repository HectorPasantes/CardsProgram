using Poker.Core.Models;
using System;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool roundEnded = false;
        string selectedOption;

        Deck deck = new Deck();
        Deck selectedHand = new Deck();
        ScoreBoard board = new ScoreBoard();
      
        deck.listCards = deck.SetDeckWithCards();
        deck.ShuffleCards();

        do
        {
            ShowUI(board, deck);
            selectedOption = Console.ReadLine();

            if (int.TryParse(selectedOption, out int selectedCard) &&( selectedCard < 9 && selectedCard > 0))
            {               
                deck.ChangeCardState(selectedCard, selectedHand.listCards);
            }
            else if (selectedOption == "z")
            {
                roundEnded = true;
            }
            else if (selectedOption == "x")
            {
                roundEnded = true;
            }
            else
            {
                Console.WriteLine("Input the number under the card/action letter");
                Thread.Sleep(2000);
            }
        } while (!roundEnded);
    }
    public static void ShowUI(ScoreBoard board, Deck deck)
    {
        Console.Clear();
        board.ShowScoreBoardTop();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        deck.ShowHandCard();
        Console.WriteLine("     1.         2.         3.         4.         5.         6.         7.         8.");
        Console.WriteLine();
        board.ShowScoreBoardBottom();
        Console.WriteLine("z to USE hand. x to DISCARD hand. number to SELECT card");
    }
}