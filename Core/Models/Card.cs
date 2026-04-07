using Poker.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.Models
{
    public class Card
    {
        public bool SelectedState { get; set; } = false;
        public Symbols Symbol { get; set; }
        public int Num { get; set; }
        public Card(Symbols symbol, int num)
        {
            Symbol = symbol;
            Num = num;
        }

        public static Symbols GetTypeCard(int randSymbol)
        {
            Symbols symbol = Symbols.Heart;

            switch (randSymbol)
            {
                case 1:
                    symbol = Symbols.Heart;
                    break;

                case 2:
                    symbol = Symbols.Club;
                    break;
                case 3:
                    symbol = Symbols.Diamond;
                    break;
                case 4:
                    symbol = Symbols.Spade;
                    break;
            }

            return symbol;
        }
    }
}