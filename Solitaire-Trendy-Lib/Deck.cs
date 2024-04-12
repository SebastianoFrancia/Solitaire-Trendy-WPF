using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solitaire_Trendy_WPF
{
    public class Deck
    {
        private List<Card> _cards;

        public List<Card> Cards
        {
            get { return _cards; }
        }
        
        public Card ViewFirstCard
        {
            get
            {
                if (_cards.Count > 0) throw new Exception("the countreCard is invalid");
                Card card = _cards[_cards.Count];
                return card;
            }
        }

        public bool Empty
        {
            get
            {
                if (_cards[_cards.Count - 1] == null) return true;
                return false;
            }
        }
        public Deck()
        {
            _cards = GenerateDeck();
        }

        private List<Card> GenerateDeck()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < (int)TypeSuit.Coppe; i++)
            {
                for (int j = 1; j < (int)TypeValue.king; j++)
                {
                    cards.Add(new Card((TypeSuit)i, j));
                }
            }
            return cards;
        }

        public Card FishFirstCard()
        {
            Card card = _cards[0];
            _cards.Remove(_cards[0]);
            return card;
        }

        Random rnd = new Random();
        public void ShuffleCards()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                int randomPosition = rnd.Next(_cards.Count);
                Card tmp = _cards[randomPosition];
                _cards[randomPosition] = _cards[i];
                _cards[i] = tmp;
            }
        }

        public void Shift()
        {
            Card temp = _cards[0];
            for (int i = 0; i < _cards.Count - 1; i++)
            {
                _cards[i] = _cards[i + 1];
            }
            _cards[_cards.Count - 1] = temp;
        }


        public override string ToString()
        {
            string result = "";     // "---- List of Cards ----"
            for (int i = 0; i < _cards.Count; i++)
            {
                result += $"{i + 1}. suit {_cards[i].Suit} value {_cards[i].Value} \n";
            }
            return result;
        }

    }
}