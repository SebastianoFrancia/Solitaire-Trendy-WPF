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
        private List<Card>[] _baseCards;
        private List<Card> _cardsThrown;


        public string Name
        {
            get {return _name; }
            set
            {
                if(value == string.Empty || value.Length <= 3) throw new ArgumentException("the name is invalid");
                _name = value;
            }
        }

        public Match(string name)
        {
            Name = name;
            _deck = new Deck();
            _cardsThrown = new List<Card>();
            _gameCards = new List<Card>[5];
            _baseCards = new List<Card>[4];
        }


    }
}