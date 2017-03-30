using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Card
    {
        public int _cost;
        public string _content;

        public Card(int cost, string content)
        {
            _content = content;
            _cost = cost;
        }
    }
}
