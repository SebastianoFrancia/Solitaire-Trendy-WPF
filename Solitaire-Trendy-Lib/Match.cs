using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace Solitaire_Trendy_WPF
{
    public class Match
    {
        private Deck _deck;
        private string _name;
        private List<Card>[] _columnsCards;
        private List<Card>[] _basesCards;
        private List<Card> _cardsThrown;


        public string Name
        {
            get { return _name; }
            set
            {
                if (value == string.Empty || value.Length <= 3) throw new ArgumentException("the name is invalid");
                _name = value;
            }
        }

        public Card 

        public Match(string name)
        {
            Name = name;
            _deck = new Deck();
            _cardsThrown = new List<Card>();
            _columnsCards = new List<Card>[5];
            _basesCards = new List<Card>[4];
        }

        private void AddThrownCard(Card extractedCard)
        {
            foreach(Card card in _cardsThrown)
            {
                if (card == extractedCard) throw new ArgumentException("the extractedCard is alrady extracted");
            }
            _cardsThrown.Add(extractedCard);
        }
        public Card ExtractCard()
        {
            if (_deck.Cards.Count <= 1)
            {
                _deck.ReallocateDeck(_cardsThrown);
                _cardsThrown.Clear();
            }
            Card extractedCard = _deck.FishFirstCard;
            bool insertable = IsInsertableCardOnBase(extractedCard);
            if (!insertable) 
            {
                AddThrownCard(extractedCard);
                AddTobase(newCard, i);
            }
            return extractedCard;
        }
        private void AddTobase(Card card)
        {
            _basesCards[card.TypeSuitToInt].Add(card);
            _cardsThrown.Remove(card);
        }


        public bool IsInsertableCardOnBase(Card newCard)
        {
            for(int i=0; i< _basesCards.Length;i++)
            {
                Card lastBaseCard = _basesCards[i][_basesCards[i].Count - 1];
                int valueNextCard = lastBaseCard.TypeValueToInt + 1;
                Card nextCard = new Card(lastBaseCard.Suit, valueNextCard);
                if (newCard == nextCard)
                {
                    return true;
                }
            }
            return false;
        }

        public void MovCardsToColumnX(int xColumn)
        {
            Card card = 
            if (xColumn < 0 && xColumn > 0) throw new ArgumentOutOfRangeException("the value of column x is invalid");
            if(IsInertableCardOnColumn(xColumn,card))
            {
                _columnsCards[xColumn].Add(card);
                _cardsThrown[]
            }
        }

        public bool IsInertableCardOnColumn(int xColumn, Card card)
        {
            if (_columnsCards[xColumn].Count != 0)
            {
                Card previousCard = _columnsCards[xColumn][_columnsCards[xColumn].Count - 1];
                TypeValue nextValueCard = (TypeValue)previousCard.TypeValueToInt + 1;
                if (previousCard.Suit != card.Suit && card.Value == nextValueCard)
                {
                    return true;
                }
            }
            else
            {
                if (card.Value == TypeValue.king) return true;
            }
            return false;
        }



    }
}