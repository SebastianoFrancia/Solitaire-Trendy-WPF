using System;
using System.Collections.Generic;
using System.Data.Common;
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
        private List<Card> _drawnCards;


        public string Name
        {
            get { return _name; }
            set
            {
                if (value == string.Empty /*|| value.Length <= 3*/) throw new ArgumentException("the name is invalid");
                _name = value;
            }
        }

        public Card LastCardDrawn
        {
            get{ return _drawnCards[_drawnCards.Count -1]; }
        }

        public List<Card>[] ColumnsCards
        {
            get{ return _columnsCards; }
        }

        public List<Card> CardsOfColumnX(int ColumnX)
        {
            return _columnsCards[ColumnX];
        }
        public Match(string name)
        {
            Name = name;
            _deck = new Deck();
            _drawnCards = new List<Card>();
            _columnsCards = new List<Card>[5];
            InitilizeColumns();
            _basesCards = new List<Card>[4];
            InitilizeBase();
        }
        private void InitilizeColumns()
        {
            for(int i=0; i<_columnsCards.Length; i++)
            {
                _columnsCards[i] = new List<Card>();

                for (int j=0; j<=i;j++)
                {
                    Card extractedCard = _deck.FishFirstCard;
                    if(j == i)
                    {
                        extractedCard.UncoverImgCard();
                    }
                    _columnsCards[i].Add(extractedCard);
                }
            }
        }

        private void InitilizeBase()
        {
            for(int i=0; i<_basesCards.Length; i++)
            {
                _basesCards[i] = new List<Card>();
            }
        }
        private void AddThrownCard(Card extractedCard)
        {
            foreach(Card card in _drawnCards)
            {
                if (card == extractedCard) throw new ArgumentException("the extractedCard is alrady extracted");
            }
            _drawnCards.Add(extractedCard);
        }
        public Card CardDraw()
        {
            if (_deck.Cards.Count == 1)
            {
                _deck.ReallocateDeck(_drawnCards);
                _drawnCards.Clear();
            }
            Card extractedCard = _deck.FishFirstCard;
            if (IsInsertableCardOnBase(extractedCard)) 
            {
                AddTobase(extractedCard);
            }
            else
            {
                AddThrownCard(extractedCard);
            }
            extractedCard.UncoverImgCard();
            return extractedCard;
        }
        /// <summary>
        /// l'indice delle basi è fisso e corrisponde al valore del seme
        /// </summary>
        /// <param name="card"></param>
        private void AddTobase(Card card)
        {
            _basesCards[card.TypeSuitToInt].Add(card);
        }


        public bool IsInsertableCardOnBase(Card newCard)
        {
            int baseValue = newCard.TypeSuitToInt;
            if (_basesCards[baseValue].Count == 0 )
            {
                if (newCard.Value == (TypeValue)1) return true;
                return false;
            }
            
            Card lastBaseCard = _basesCards[baseValue][_basesCards[baseValue].Count -1]; // l'utlima carta nella bse dello stesso seme
            int valueNextCard = lastBaseCard.TypeValueToInt + 1;
            Card nextCard = new Card(lastBaseCard.Suit, valueNextCard);
            if (newCard == nextCard)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// sposta la carta in una specifica colonna
        /// </summary>
        /// <param name="xColumn"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void MovDrawnCardsToColumnX(int xColumn, Card card)
        {
            if (xColumn < 0 && xColumn > 0) throw new ArgumentOutOfRangeException("the value of column x is invalid");
            if (card == LastCardDrawn)
            {
                if (!IsInertableCardOnColumn(xColumn, card)) throw new ArgumentOutOfRangeException("card can't be add in the column");
                
                _columnsCards[xColumn].Add(card);
                _drawnCards.Remove(LastCardDrawn);
            }
            
        }
        /*
        private bool ThersCardInColumn(int xColumn, Uri cardPath)
        {
            foreach (Card card in _columnsCards[xColumn])
            {
                if (card.ImagePathCard == cardPath)
                {

                }
            }
        }*/
        
        public void MovCardsToColumnX(int fromColumnX, int toColumnX, Card card)
        {
            if (_columnsCards[fromColumnX].Contains(card) && 
                !_columnsCards[toColumnX].Contains(card))
            {
                if (!IsInertableCardOnColumn(toColumnX, card)) throw new ArgumentOutOfRangeException("card can't be add in the column");

                if (_columnsCards[toColumnX][_columnsCards[toColumnX].Count - 1] == card)
                {
                    _columnsCards[fromColumnX].Remove(card);
                    _columnsCards[toColumnX].Add(card);
                }
                else
                {
                    int baseIndexCards = _columnsCards[fromColumnX].IndexOf(card);
                    if (baseIndexCards < _columnsCards[fromColumnX].Count)
                    {
                        for (int i = baseIndexCards; i < _columnsCards[fromColumnX].Count; i++)
                        {
                            Card cardToMove = _columnsCards[fromColumnX][i];
                            _columnsCards[fromColumnX].Remove(cardToMove);
                            _columnsCards[toColumnX].Add(cardToMove);
                        }
                    }
                    else throw new ArgumentOutOfRangeException("card index is invalid");

                }
            }
            else throw new ArgumentOutOfRangeException("card isn't in the columns");

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

        public bool IsWin()
        {
            bool isWin = true;
            for(int i=0; i<_basesCards.Length;i++)
            {
                if (_basesCards[i].Count != 10)
                {
                    isWin = false ; 
                    break;
                }
            }
            return isWin;
        }
        /*
        public bool IsLost()
        {
            if
        }*/

        

    }
}