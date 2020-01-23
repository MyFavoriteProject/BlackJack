using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        public string Name { get; set; }
        public string Suit { get; set; }
        public int Point { get; set; }

        public Card() { }
        public Card(string name, string suit, int point)
        {
            Name = name;
            Suit = suit;
            Point = point;
        }
    }
}
