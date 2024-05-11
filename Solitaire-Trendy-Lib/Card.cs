using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;


namespace Solitaire_Trendy_LIB
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
        private Uri _imgPathCard;

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
        
        public Uri imagePathCard
        {
            get { return _imgPathCard; }
        }

        public BitmapImage ImageCard
        {
            get 
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = _imgPathCard;
                img.EndInit();
                return img;
            }
        }
        /// <summary>
        /// restituisce il nome del file che rapresenta la carta
        /// </summary>
        public string GetImgName
        {
            get {
                string fileName = "";
                
                fileName += $"{TypeValueToInt}";

                if (_suit == TypeSuit.Bastone)
                {
                    fileName += "A";
                }
                else if (_suit == TypeSuit.Denara)
                {
                    fileName += "B";
                }
                else if (_suit == TypeSuit.Spada)
                {
                    fileName += "C";
                }
                else if (_suit == TypeSuit.Coppe)
                {
                    fileName += "D";
                }
                else throw new ArgumentException("the card suit isn't initialize");
                return fileName += ".jpg";
            }
        }

        public Card(TypeSuit suit, int value)
        {
            Suit = suit;
            Value = (TypeValue)value;
            CoverImgCard();
        }

        public void UncoverImgCard()
        {
            _imgPathCard = new Uri($@"source/Cards/{GetImgName}", UriKind.Relative);
        }

        public void CoverImgCard()
        {
            _imgPathCard = new Uri(@"source/Cards/RETRO.jpg", UriKind.Relative);
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
        /*
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Card card = obj as Card;
                if (card.Suit == Suit && card.Value == Value) return true;
            }
            return false;
        }*/

        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                Card card = obj as Card;
                if (card != null)
                {
                    if (card.Suit == Suit && card.Value == Value) return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Value} {Suit}\n";
        }
    }
}