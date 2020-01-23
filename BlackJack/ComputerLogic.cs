using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJack
{
    class ComputerLogic
    {
        Card[] _computerCards;
        CardDeck _cardDeck = new CardDeck();
        Card[] _cardBalance;

        public ComputerLogic(Card[] computerCards)
        {
            _computerCards = computerCards;
            CountCardDeckBalance();
        }

        public bool TakeOrNotTakeCard()
        {
            Random random = new Random();
            
            int winCombination = NumberOfWinning();
            int randomValue = random.Next(_cardBalance.Length);

            if (randomValue <= winCombination)
                return true;


            return false;
        }

        private int NumberOfWinning()
        {
            int computerPoint = ComputerPoint();
            int numberOfVictories = 0;

            foreach (var cardBalance in _cardBalance)
            {
                if (21 - computerPoint >= cardBalance.Point)
                {
                    numberOfVictories += 1;
                }
            }

            return numberOfVictories;
        }

        private int ComputerPoint()
        {
            int computerPoint = 0;

            foreach (var card in _computerCards)
            {
                computerPoint += card.Point;
            }
            return computerPoint;
        }

        private void CountCardDeckBalance()
        {
            int indexCardBalance = 0;

            for(int i = 0; i< _cardDeck.Cards.Length; i++)
            {
                var findOrNotFind = FindOrNotFindEquals(_cardDeck.Cards[i]);
                if (findOrNotFind == false)
                {
                    _cardBalance = PlusOneArrCell(_cardBalance);
                    _cardBalance[indexCardBalance] = _cardDeck.Cards[i];
                    indexCardBalance += 1;
                }
            }
        }

        private bool FindOrNotFindEquals(Card card)
        {
            foreach (var computerCards in _computerCards)
            {
                //if (card.Equals(computerCards) == true)
                if (card.Name == computerCards.Name && card.Suit == computerCards.Suit && card.Point == computerCards.Point)
                    return true;
            }
            return false;
        }

        private Card[] PlusOneArrCell(Card[] cards)
        {
            if (cards == null)
            {
                cards = new Card[1];
                return cards;
            }
            Card[] intermediateArr = new Card[cards.Length + 1];

            for (int i = 0; i < cards.Length; i++)
            {
                intermediateArr[i] = cards[i];
            }

            cards = intermediateArr;

            return cards;
        }
    }
}
