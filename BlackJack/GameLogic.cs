using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class GameLogic
    {
        CardDeck _cardDeck = new CardDeck();
        Card[] _playerCards;
        Card[] _computerCards;

        public GameLogic(Card[] playerCards, Card[] computerCards)
        {
            _playerCards = playerCards;
            _computerCards = computerCards;
        }

        public bool WinnerFound()
        {
            int playerPoint = CountOfPoint(_playerCards);
            int computerPoint = CountOfPoint(_computerCards);
            #region WhoWin
            if (WinCombination(_playerCards)==true)
            {
                Console.WriteLine("!!!Player Win!!!");
                return true;
            }
            if (WinCombination(_computerCards) == true)
            {
                Console.WriteLine("!!!Computer Win!!!");
                return true;
            }
            if (MoreThanLimit(playerPoint) == true)
            {
                Console.WriteLine("!!!Computer Win!!!");
                return true;
            }
            if (MoreThanLimit(computerPoint) == true)
            {
                Console.WriteLine("!!!Player Win!!!");
                return true;
            }
            
            if (playerPoint == computerPoint)
            {
                Console.WriteLine("!!!Draw!!!");
                return true;
            }
            if (playerPoint > computerPoint)
            {
                Console.WriteLine("!!!Player Win!!!");
                return true;
            }
            //if (playerPoint < computerPoint)
            //{
            //    Console.WriteLine("!!!Computer Win!!!");
            //    return true;
            //}
            #endregion

            return false;
        }

        private int CountOfPoint(Card[] cards)
        {
            int point = 0;
            foreach (var card in cards)
            {
                point += card.Point;
            }
            return point;
        }

        private bool MoreThanLimit(int point)
        {
            if (point > 21)
            {
                return true;
            }

            return false;
        }

        private bool WinCombination(Card[] cards)
        {
            if(cards[0].Name == _cardDeck.NameCard[0] || cards[1].Name == _cardDeck.NameCard[0])
                return true;
            if (CountOfPoint(cards) == 21)
                return true;
            else
                return false;
        }
    }
}
