using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class TestClass
    {
        public string[] _cards = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public string[] _randomCard = new string[10];
        public void SetRandomCardDeck()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                _randomCard[i] = _cards[i];
            }

            for (int i = _randomCard.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                var temp = _randomCard[j];
                _randomCard[j] = _randomCard[i];
                _randomCard[i] = temp;
            }
        }
    }
}
