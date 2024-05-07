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

        public Card LastDrawnCard
        {
            get
            {
                if (_drawnCards.Count <= 0) throw new ArgumentOutOfRangeException("there isn't drawn card");
                return _drawnCards[_drawnCards.Count -1]; }
        }

        public List<Card>[] ColumnsCards
        {
            get{ return _columnsCards; }
        }

        public List<Card>[] BaseCards
        {
            get { return _basesCards; }
        }

        public List<Card> DrawnCards
        {
            get { return _drawnCards; }
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
                    Card extractedCard = _deck.DrawnFirstCard;
                    if (j == i)
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
            if (_drawnCards.Contains(extractedCard)) throw new ArgumentException("the extractedCard is alrady extracted");
            _drawnCards.Add(extractedCard);
        }

        public bool DrawCard()
        {
            bool isAddedToBase = false;
            if (_deck.Cards.Count == 0)
            {
                _deck.ReallocateDeck(_drawnCards);
                _drawnCards.Clear();
            }
            Card extractedCard = _deck.DrawnFirstCard;
            if (IsInsertableCardOnBase(extractedCard))
            {
                AddTobase(extractedCard);
                isAddedToBase = true;
            }
            else
            {
                AddThrownCard(extractedCard);
            }
            extractedCard.UncoverImgCard();
            return isAddedToBase;
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
                if (newCard.Value == (TypeValue)1)
                {
                    return true;
                }
                return false;
            }
            
            Card lastBaseCard = _basesCards[baseValue][_basesCards[baseValue].Count -1]; // l'utlima carta nella bse dello stesso seme

            int valueNextCard = lastBaseCard.TypeValueToInt + 1;
            Card nextCard = new Card(lastBaseCard.Suit, valueNextCard);
            newCard.UncoverImgCard();

            if (newCard.Value == nextCard.Value && newCard.Suit == newCard.Suit)
            {
                return true;
            }
            return false;
        }

        public void MoveLastDrawnCardsToColumnX(int toColumnX)
        {
            Card drawnCard = LastDrawnCard;
            if (IsIsertableCardOnColumn(toColumnX, drawnCard) == false) throw new ArgumentOutOfRangeException("card can't be add in the column");
            _drawnCards.Remove(drawnCard);
            _columnsCards[toColumnX].Add(drawnCard);
        }

        public void MoveColumnCardToBase(Card card, int columnX)
        {
            if (columnX < 0 && columnX > 4) throw new ArgumentOutOfRangeException("the columnX is invalid");
            if (_columnsCards[columnX].Contains(card) == false) throw new ArgumentException("the card isn't contains in the column X");
            if (_columnsCards[columnX][_columnsCards[columnX].Count - 1] != card) throw new ArgumentException("you can only add the last card of the column to the base");

            _columnsCards[columnX].Remove(card);
            AddCardToBase(card);
            if (_columnsCards[columnX].Count > 0 &&
                _columnsCards[columnX][_columnsCards[columnX].Count - 1].imagePathCard == new Uri(@"source/Cards/RETRO.jpg", UriKind.Relative))
            {
                _columnsCards[columnX][_columnsCards[columnX].Count - 1].UncoverImgCard();
            }
        }

        public void AddCardToBase(Card card)
        {
            if (card.imagePathCard == new Uri(@"source/Cards/RETRO.jpg", UriKind.Relative)) throw new ArgumentException("you can't insert coverde card to base");
            if (IsInsertableCardOnBase(card) == false) throw new ArgumentException("you can't insert this card in the base");
            AddTobase(card);
            if (_drawnCards.Count > 0 && card == LastDrawnCard)
            {
                _drawnCards.Remove(LastDrawnCard);
            }
        }


        /// <summary>
        /// sposta la carta in una specifica colonna
        /// </summary>
        /// <param name="xColumn"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void MoveCardsToColumnX(int fromColumnX, int toColumnX, Card card)
        {
            if ((fromColumnX < 0 && fromColumnX > 4) ||
                (toColumnX < 0 && toColumnX > 4) &&
                fromColumnX == toColumnX) throw new ArgumentOutOfRangeException("the value of column x is invalid");

            if (card.imagePathCard == new Uri(@"source/Cards/RETRO.jpg", UriKind.Relative)) throw new ArgumentException("you can't insert coverde card to base");

            if (_columnsCards[fromColumnX].Contains(card) && 
                !_columnsCards[toColumnX].Contains(card))
            {
                if (IsIsertableCardOnColumn(toColumnX, card) == false) throw new ArgumentOutOfRangeException("card can't be add in the column");

                // se l'ulima carta della colonna è uguale alla carta selezionata allora la sposto
                if (_columnsCards[fromColumnX][_columnsCards[fromColumnX].Count - 1] == card)
                {
                    _columnsCards[fromColumnX].Remove(card);
                    if (_columnsCards[fromColumnX].Count > 0)
                    {
                        _columnsCards[fromColumnX][_columnsCards[fromColumnX].Count -1].UncoverImgCard();
                    }
                    _columnsCards[toColumnX].Add(card);
                }
                else // se invece la carta selezionata non è l'ultima sposto anche tutte le sucessive
                {
                    int baseIndexCards = _columnsCards[fromColumnX].IndexOf(card);
                    if (baseIndexCards < _columnsCards[fromColumnX].Count)
                    {
                        int nCard = _columnsCards[fromColumnX].Count;
                        for (int i = baseIndexCards; i < nCard; i++)
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

        public bool IsIsertableCardOnColumn(int xColumn, Card card)
        {
            if (_columnsCards[xColumn].Count != 0)
            {
                Card previousCard = _columnsCards[xColumn][_columnsCards[xColumn].Count - 1];
                TypeValue nextValueCard = (TypeValue)previousCard.TypeValueToInt - 1;
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