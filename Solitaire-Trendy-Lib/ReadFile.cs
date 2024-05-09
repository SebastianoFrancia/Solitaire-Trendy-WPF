using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire_Trendy_WPF
{
    public class ReadFile
    {
        private string _percorso;
        public ReadFile(string percorso)
        {
            _percorso = percorso;
        }

        public List<User> ReadUsers()
        {
            List<User> users = new List<User>();
            using (StreamReader sr = new StreamReader(_percorso))
            {

                string line;
                User user;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] split = line.Split(';');
                    string name = split[0];
                    int score = int.Parse(split[1]);
                    user = new User(name, score);
                    users.Add(user);
                }
            }
            return users;
        }
    }
}
