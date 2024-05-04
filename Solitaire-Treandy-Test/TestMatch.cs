using Solitaire_Trendy_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solitaire_Treandy_Test
{
    [TestClass]
    public class TestMatch
    {
        [TestMethod]
        public void NameWithInvalidValue()
        {
            Assert.ThrowsException<ArgumentException>(() => new Match(""));
            //Assert.ThrowsException<ArgumentException>(() => new Match("lol"));
        }

        [TestMethod]
        public void NameWithValidValue()
        {
            Match m = new Match("gino");
            Assert.AreEqual("gino", m.Name);
            
        }
    }
}
