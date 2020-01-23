using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class CardDeck
    {
        private Card[] _cards = new Card[36];
        private Card[] _randomCard = new Card[36];
        private string[] _name = { "Ace", "Ten", "Nine", "Eight", "Seven", "Six", "King", "Queen", "Jack" };
        private string[] _suit = { "Diamond", "Heart", "Spade", "Club" };
        private int _indexNameCard;

        public string[] NameCard 
        { 
            get=>_name;
        }
        public Card[] Cards
        {
            get => _cards;
        }
        public Card[] RandomCards
        {
            get => _randomCard;
        }

        public CardDeck()
        {
            SetCardDeck();
        }

        public void SetCardDeck()
        {
            for (int indexCard = 0; indexCard < _cards.Length; indexCard++)
            {
                if (indexCard < 9)
                {
                    _cards[indexCard] = new Card(_name[_indexNameCard], _suit[0], GetPoint(_indexNameCard));
                }
                if (indexCard >= 9 && indexCard < 18)
                {
                    _cards[indexCard] = new Card(_name[_indexNameCard], _suit[1], GetPoint(_indexNameCard));
                }
                if (indexCard >= 18 && indexCard < 27)
                {
                    _cards[indexCard] = new Card(_name[_indexNameCard], _suit[2], GetPoint(_indexNameCard));
                }
                if (indexCard >= 27 && indexCard < 36)
                {
                    _cards[indexCard] = new Card(_name[_indexNameCard], _suit[3], GetPoint(_indexNameCard));
                }

                if (_indexNameCard == 8)
                    _indexNameCard = 0;
                else
                    _indexNameCard += 1;
            }
            RandomCardDeckEquallyCaedDeck();
        }

        private int GetPoint(int indexNameCard)
        {
            if (indexNameCard < 6)
                return 11 - indexNameCard;
            else
                return 10 - indexNameCard;
        }

        public void SetRandomCardDeck()
        {
            Random random = new Random();
            for (int i = _cards.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                var temp = _cards[j];
                _randomCard[j] = _cards[i];
                _randomCard[i] = temp;
            }
        }

        private void RandomCardDeckEquallyCaedDeck()
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                _randomCard[i] = _cards[i];
            }
        }
    }
}
