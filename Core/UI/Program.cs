using Poker.Core.Models;
using System;

public class Program
{
    public static void Main()
    {

        Deck deck = new Deck();

        deck.listCards = Deck.SetDeckWithCards();

        deck.ShowCardsInDeck();

        deck.listCards = Deck.ShuffleCards(deck.listCards);

        deck.ShowCardsInDeck();
    }
}