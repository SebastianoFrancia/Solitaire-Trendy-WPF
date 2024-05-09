using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire_Trendy_WPF
{ 
    public class User
    {
        private string _name;
        private int _score;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public int Score
        {
            get { return _score; }
            private set { 
                if(value < 0) throw new ArgumentOutOfRangeException("the actual score is invlaid");
                _score = value; 
            }
        }
        public User(string name, int score) 
        { 
            Name = name;
            Score = score;
        }

        public void AddScorPoint()
        {
            _score++;
        }

        public override bool Equals(object obj)
{
if ( obj is User)
{
User user = obj as User
if (user != null)
{
if (user.Name == Name) retun true
}
}
return false
}
    }
}
