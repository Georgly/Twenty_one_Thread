using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Croupier
    {
        int cardsCount;
        Dictionary<int, string> deck = new Dictionary<int, string>
        {
            {3, "J"}, {4, "Q" }, {5, "K" }, {6,"6" }, {7,"7" }, { 8,"8"}, {9,"9" }, {10,"10" }, {11,"A" }
        };
        Card[] deckArr;

        public Croupier()
        {
            deckArr = Help.Shuffle(deck);
            cardsCount = 36;
        }

        void Shuffle()
        {

        }

        public void GiveCard(Player player)
        {
            cardsCount--;
            player.TakeCard(deckArr[cardsCount]);
        }
    }
}
