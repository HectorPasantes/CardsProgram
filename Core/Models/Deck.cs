using Poker.Core.Models.Enum;
using Poker.Core.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Models
{
    public class Deck
    {
        public List<Card> listCards { get; set; } = new List<Card>();
        public List<List<string>> allCardsSprite { get; set; } = new List<List<string>>();
        public List<Card> ShuffleCards()
        {
            const int StartOfArray = 0;
            int EndOfArray = listCards.Count;

            Random rnd = new Random();

            bool cardInserted = true;
            int newPosition;

            Card[] newDeck = new Card[listCards.Count];

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
            listCards = newDeck.ToList();
            return listCards;
        }
        private int DiscardCount = 0;

        public List<Card> SetDeckWithCards()
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
            List<Card> recreatedList = deck.ToList();
            return recreatedList;
        }
        public void ShowHandCard()
        {
            allCardsSprite.Clear();
            for (int i = 0; i < 8; i++)
            {                
                allCardsSprite.Add(CardUI.GetCardUI(listCards[i]));
            }

            for (int row = 0; row < 7; row++)
            {
                for (int cardId = 0; cardId < 8; cardId++)
                {
                    if (listCards[cardId].SelectedState)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(allCardsSprite[cardId][row]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(allCardsSprite[cardId][row]);
                    }
                }
                Console.WriteLine();
            }
        }
        public void ChangeCardState(int num, List<Card> deck)
        {
            Card card = listCards[num - 1];

            if (card.SelectedState)
            {
                card.SelectedState = false;
                deck.Remove(card);
            }
            else
            {
                if (deck.Count < 5)
                {
                    card.SelectedState = true;
                    deck.Add(card);
                }
                else
                {
                    Console.WriteLine("You can only select 5 cards");
                    Thread.Sleep(1500);
                }
            }
        }        
        public void DiscardCards(ScoreBoard board, Deck deck)
        {
            List<Card> notSelected = listCards.Where(a => !a.SelectedState).ToList();
            List<Card> selected = listCards.Where(a => a.SelectedState).ToList();

            foreach (var card in selected)
            {
                card.SelectedState = false;
                DiscardCount++;
            }

            notSelected.AddRange(selected);
            listCards = notSelected;

            board.Discards--;

            if(DiscardCount >= 48)
            {
                deck.ShuffleCards();
            }
        }
    }
}