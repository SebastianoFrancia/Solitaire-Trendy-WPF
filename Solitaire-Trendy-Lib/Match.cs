using System;
using System.Collections.Generic;
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
            AddThrownCard(extractedCard);
            return _cardsThrown[_cardsThrown.Count - 1];
        }

        public void MovCardsToColumnX(int xColumn, Card card)
        {
            
        }

        public bool IsIsertableCardOnBase(Card newCard)
        {
            foreach(List<Card> b in _basesCards)
            {
                Card lastBaseCard = b[b.Count - 1];
                int valueNextCard = lastBaseCard.TypeValueToInt()+1;
                Card nextCard = new Card(lastBaseCard.Suit, valueNextCard);
                if(newCard == nextCard)
                {
                    return true;

                }
            }
            return false;
        }


        public void AddTobase(Card card, int based)
        {

        }
    }
}