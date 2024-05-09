using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire_Trendy_WPF
{
    public class WriteFile
    {
        private string _path;
        public WriteFile(string path)
        {
            _path = path;
        }

        public void WriteName(string name, int score)
        {
            ReadFile rd = new ReadFile(_path);
            if (rd.IsNewUser(name))
            {
                using (StreamWriter sw = new StreamWriter(_path, true))
                {
                    string line = $"{name};{score}";
                    sw.WriteLine(line);
                }
            }
        }

        public void WriteScore(string name, int score)
        {

        }
    }
}
