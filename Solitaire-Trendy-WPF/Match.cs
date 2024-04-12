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
        private List<Card>[] _gameCards;

        public string Name
        {
            get {return _name; }
            set
            {
                if(value == string.Empty && value.Length < 3) throw new ArgumentException("the name is invalid");
                _name = value;
            }
        }

        public Match(string name)
        {
            Name = name;
            _deck = new Deck();
            _gameCards = new List<Card>[5];
            InitializeGameCards();
        }

        private void InitializeGameCards()
        {
            for(int i = 0; i<_gameCards.Length; i++)
            {
                for(int j=0;j<i+1;j++)
                {
                    _gameCards[i].Add(_deck.FishFirstCard());
                }
            }
        }

        public bool MoveCard()
        {
            
        }

    }
}