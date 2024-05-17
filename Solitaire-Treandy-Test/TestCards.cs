using Solitaire_Trendy_LIB;
using System.Security.Cryptography;

namespace Solitaire_Treandy_Test
{
    [TestClass]
    public class TestCards
    {
        [TestMethod]
        public void SuitWithInvalidValue()
        {
            Assert.ThrowsException<ArgumentException>(() => new Card((TypeSuit)4, 8));

        }

        [TestMethod]
        public void ValueWithInvalidValue()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Card(TypeSuit.Denara, 11));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Card(TypeSuit.Denara, 0));

        }

        [TestMethod]
        public void GetFilenameTest()
        {
            Card c;
           c = new Card(TypeSuit.Bastone,1);
           Assert.AreEqual("1A.jpg", c.GetImgName );

            c = new Card(TypeSuit.Denara, 1);
            Assert.AreEqual("1B.jpg", c.GetImgName);
        }

        [TestMethod]
        public void TypeValueToIntCorrect()
        {
            Card c = new Card(TypeSuit.Bastone, 1);
            Assert.AreEqual(1, c.TypeValueToInt);

            c = new Card( TypeSuit.Bastone, 2 );
            Assert.AreEqual( 2, c.TypeValueToInt );
        }

        [TestMethod]
        public void TypeSuitToIntCorrect()
        {
            Card c = new Card(TypeSuit.Bastone, 1);
            Assert.AreEqual( 0, c.TypeSuitToInt );

            c = new Card(TypeSuit.Coppe, 1);
            Assert.AreEqual(2, c.TypeSuitToInt);
        }
    }
}
