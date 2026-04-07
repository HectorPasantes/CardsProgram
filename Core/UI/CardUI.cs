using Poker.Core.Models;
using Poker.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core.UI
{
    public static class CardUI
    {
        public static string[] GetCardUI(Card card)
        {
            string numStr = card.Num.ToString();
            string topNum = card.Num < 10 ? numStr + " " : numStr;
            string botNum = card.Num < 10 ? " " + numStr : numStr;

            char symbol;
            switch (card.Symbol)
            {
                case Models.Enum.Symbols.Heart:
                    symbol = '♥';
                    break;
                case Models.Enum.Symbols.Diamond:
                    symbol = '♦';
                    break;
                case Models.Enum.Symbols.Club:
                    symbol = '♣';
                        break;
                case Models.Enum.Symbols.Spade:
                    symbol = '♠';
                    break;
                default:
                    symbol = 'A';
                    break;
            }

            return
            [
                " .-------. ",
                $" |{topNum}     | ",
                " |       | ",
                $" |   {symbol}   | ",
                " |       | ",
                $" |     {botNum}| ",
                " '-------' "
            ];
        }
    }
}
