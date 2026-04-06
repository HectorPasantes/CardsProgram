using Poker.Core.Models.Enum;
using Poker.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Models
{
    public class Deck
    {
        public Card[] listCards { get; set; } = Array.Empty<Card>();
        public Deck()
        {
            listCards = SetDeckWithCards();            
        }

        public Card[] ShuffleCards()
        {
            const int StartOfArray = 0;
            int EndOfArray = listCards.Length;

            Random rnd = new Random();

            bool cardInserted = true;
            int newPosition;

            Card[] newDeck = new Card[listCards.Length];

            foreach (Card card in listCards)
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
            listCards = newDeck;
            return listCards;
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
        public void ShowHandCard()
        {
            List<string[]> allCardsLines = new List<string[]>();

            for (int i = 0; i < 5; i++)
            {
                allCardsLines.Add(CardUI.GetCardUI(listCards[i]));
            }

            for (int row = 0; row < 7; row++)
            {
                for (int cardId = 0; cardId < 5; cardId++)
                {
                    Console.Write(allCardsLines[cardId][row]);
                }
                Console.WriteLine();
            }
        }
    }
}