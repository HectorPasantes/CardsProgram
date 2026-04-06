using Poker.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Models
{
    public class Deck
    {
        public Card[] listCards { get; set; } = Array.Empty<Card>();

        public static Card[] ShuffleCards(Card[] deck)
        {
            const int StartOfArray = 0;
            int EndOfArray = deck.Length;

            Random rnd = new Random();

            bool cardInserted = true;
            int newPosition;

            Card[] newDeck = new Card[deck.Length];

            foreach (Card card in deck)
            {
                do
                {
                    newPosition = rnd.Next(StartOfArray, EndOfArray);
                    cardInserted = true;
                    if (newDeck[newPosition] == null)
                    {
                        newDeck[newPosition] = card;
                    }
                    else
                    {
                        cardInserted = false;
                    }

                } while (!cardInserted);
            }
            deck = newDeck;
            return deck;
        }
        public void ShowCardsInDeck()
        {
            foreach (Card card in listCards)
            {
                Console.WriteLine($"My card is: {card.Num} of {card.Symbol}");
            }
            Console.WriteLine("End of deck");
        }

        public static Card[] SetDeckWithCards()
        {
            const int minNum = 1, maxNum = 13, minSymbol = 1, maxSymbol = 5;

            Random rnd = new Random();

            int num, randSymbol;
            bool correctCard;

            Card[] deck = new Card[(maxNum - 1) * (maxSymbol - 1)];


            deck[0] = new Card(Symbols.Heart, 1);
            for (int i = 1; i < deck.Length; i++)
            {
                do
                {
                    correctCard = true;
                    num = rnd.Next(minNum, maxNum);
                    randSymbol = rnd.Next(minSymbol, maxSymbol);

                    for (int j = 1; j < deck.Length; j++)
                    {
                        if (num == deck[j - 1]?.Num && randSymbol == (int)deck[j - 1].Symbol)
                        {
                            correctCard = false;
                        }
                    }

                } while (!correctCard);

                deck[i] = new Card(Card.GetTypeCard(randSymbol), num);


            }
            return deck;
        }
    }
}