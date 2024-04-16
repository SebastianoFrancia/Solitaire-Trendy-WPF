﻿using System;
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

        public bool Empty
        {
            get
            {
                if (_cards[_cards.Count - 1] == null) return true;
                return false;
            }
        }

        public Card FishFirstCard
        {
            get
            {
                Card card = _cards[0];
                _cards.Remove(_cards[0]);
                return card;
            }
        }

        public Deck()
        {
            _cards = GenerateDeck();
            ShuffleCards();
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

        private void ShuffleCards()
        {
            Random rnd = new Random();
            for (int i = 0; i < _cards.Count; i++)
            {
                int randomPosition = rnd.Next(_cards.Count);
                Card tmp = _cards[randomPosition];
                _cards[randomPosition] = _cards[i];
                _cards[i] = tmp;
            }
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