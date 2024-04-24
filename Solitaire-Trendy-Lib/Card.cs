using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace Solitaire_Trendy_WPF
{   
    public enum TypeSuit
    {
        Bastone,
        Denara,
        Spada,
        Coppe
    }

    public enum TypeValue
    {
        jack = 8,
        horse,
        king,
    }

    public class Card
    {
        private TypeSuit _suit;
        private TypeValue _value;

        public TypeSuit Suit
        {
            get { return _suit; }
            private set
            {
                if ((int)value < 0 || (int)value > 3) throw new ArgumentException("seme non accettabile");
                _suit = value;
            }
        }
        public TypeValue Value
        {
            get { return _value; }
            private set
            {
                if (value < (TypeValue)1 || value > (TypeValue)10) throw new ArgumentOutOfRangeException("valore non accettabile");
                _value = value;
            }
        }
        public Card(TypeSuit suit, int value)
        {
            Suit = suit;
            Value = (TypeValue)value;
        }

        public int TypeValueToInt
        {
            get
            {
                if (_value == TypeValue.jack) return 8;
                if (_value == TypeValue.horse) return 9;
                if (_value == TypeValue.king) return 10;
                return int.Parse(_value.ToString());
            }
        }

        public int TypeSuitToInt
        {
            get
            {
                if (_suit == TypeSuit.Bastone) return 0;
                if (_suit == TypeSuit.Coppe) return 1;
                if (_suit == TypeSuit.Spada) return 2;
                if (_suit == TypeSuit.Denara) return 3;
                throw new ArgumentOutOfRangeException("the suit of card is invalid");
            }
        }

        public bool IsFigure()
        {
            if (Value > (TypeValue)7) return true;
            else return false;
        }
        public override string ToString()
        {
            return $"{Value} {Suit}\n";
        }
    }
}