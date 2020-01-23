using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Card[] playerCards = new Card[1];
            Card[] computerCards = new Card[1];
            CardDeck cardDeck = new CardDeck();
            GameLogic gameLogic;
            ComputerLogic computerLogic;

            cardDeck.SetRandomCardDeck();

            int indexRandomCards = 0;

            bool win = false;
            bool playerTake = true;
            bool computerTake = true;

            do
            {

                if (indexRandomCards < 4)
                {
                    while (indexRandomCards < 4)
                    {
                        playerCards = SetPlayerCards(playerCards, cardDeck,ref indexRandomCards);
                        computerCards = SetPlayerCards(computerCards, cardDeck,ref indexRandomCards);
                    }
                }
                else
                {
                    playerCards = SetPlayerCards(playerCards, cardDeck, ref indexRandomCards);
                    computerCards = SetPlayerCards(computerCards, cardDeck, ref indexRandomCards);
                }

                gameLogic = new GameLogic(playerCards, computerCards);
                win = gameLogic.WinnerFound();

                playerTake = PlayerTake(playerCards);
                computerLogic = new ComputerLogic(computerCards);
                //computerTake = computerLogic.TakeOrNotTakeCard();

                if(playerTake == false || computerTake == false)
                {
                    WhoWin(playerCards, computerCards);
                    win = true;
                }


            } while (win == false);

            Console.ReadKey();
        }

        static void WhoWin(Card[] player, Card[] computer)
        {
            int playerPoint = 0;
            int computerPoint = 0;
            Console.WriteLine("Player");
            foreach (var card in player)
            {
                Console.WriteLine($"Name:{card.Name}; Suit:{card.Suit}; Point:{card.Point}");
                playerPoint += card.Point;
            }
            Console.WriteLine();
            Console.WriteLine("Computer");
            foreach (var card in computer)
            {
                Console.WriteLine($"Name:{card.Name}; Suit:{card.Suit}; Point:{card.Point}");
                computerPoint += card.Point;
            }
            if(playerPoint> computerPoint)
            {
                Console.WriteLine("!!!Player Win!!!");
                return;
            }
            else if (playerPoint < computerPoint)
            {
                Console.WriteLine("!!!Computer Win!!!");
                return;
            }
            Console.WriteLine("!!!Draw!!!");
        }

        static Card[] SetPlayerCards(Card[] cards, CardDeck cardDeck, ref int index)
        {
            cards = PlusOneArrCell(cards, index);

            cards[cards.Length - 1] = cardDeck.RandomCards[index];

            index += 1;

            return cards;
        }

        static Card[] PlusOneArrCell (Card[] cards, int index)
        {
            if (index < 2)
            {
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

        static bool PlayerTake(Card[] cards)
        {
            int point = 0;
            foreach(var card in cards)
            {
                Console.WriteLine($"Name:{card.Name}; Suit:{card.Suit}; Point:{card.Point}");
                point += card.Point;
            }

            Console.WriteLine(point);
            Console.WriteLine("Do you want take next card? if yes put 1; if not put other button");
            string playerButt = Console.ReadLine();

            if(playerButt == "1")
            {
                return true;
            }

            return false;
        }
    }
}
